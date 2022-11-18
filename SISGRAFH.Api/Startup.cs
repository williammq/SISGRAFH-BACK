using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SISGRAFH.Core.Interfaces;
using SISGRAFH.Core.Interfaces.Login;
using SISGRAFH.Core.Services;
using SISGRAFH.Core.Services.Login;
using SISGRAFH.Core.Utils.BlobStorage;
using SISGRAFH.Infraestructure.Data.BlobStorage;
using SISGRAFH.Infraestructure.Data.Interfaces;
using SISGRAFH.Infraestructure.Data.MongoDB;
using SISGRAFH.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string PolizaCORSSISGEM = "_polizaCORSSISGEM";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            //need default token provider
            services.AddAuthentication(JwtBearerDefaults
             .AuthenticationScheme)
                 .AddJwtBearer(options =>
              options.TokenValidationParameters =
              new TokenValidationParameters
              {
                  ValidateIssuer = false,
                  ValidateAudience = false,
                  ValidateLifetime = true,
                  ValidateIssuerSigningKey = true,
                  IssuerSigningKey = new SymmetricSecurityKey(
                 //llave secreta que dice si el token es valido
                 Encoding.UTF8.GetBytes(Configuration.GetSection("jwt:key").Value)),
                  ClockSkew = TimeSpan.Zero
              });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SISGRAFH.Api", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Autorizacion para la entradas a las apis que generan la cabecera",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                  {  new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                   }
                });
            });
            //cualquier cliente desplegado localmente en el puerto
            //logico 8080 podra consumir las APIS de SISGEM-BACK
            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: PolizaCORSSISGEM,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:8080")
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .SetIsOriginAllowed((host) => true)
                                .AllowCredentials();
                    });
            });

            //Automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Inyección de dependencias de MongoDB debe ir antes de la I.D. de los servicios
            services.Configure<MongoDbSettings>(Configuration.GetSection("MongoConnection"));
            services.Configure<AzureBlobStorageSettings>(Configuration.GetSection("AzureBlobStorage"));
            services.AddSingleton<MongoContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IFileStorage, AzureFileStorage>();

            //Login
            services.AddTransient<ILoginService, LoginService>();

            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IMaquinaService, MaquinaService>();
            services.AddTransient<ICotizacionService, CotizacionService>();
            services.AddTransient<IInsumoService, InsumoService>();
            services.AddTransient<IProductoService, ProductoService>();
            services.AddTransient<ISolicitudService, SolicitudService>();
            services.AddTransient<IMovimientoService, MovimientoService>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<ICatalogoService, CatalogoService>();
            services.AddTransient<ITrabajadorService, TrabajadorService>();
            services.AddTransient<IPagoService, PagoService>();
            services.AddTransient<IOrden_TrabajoService, Orden_TrabajoService>();
            services.AddTransient<IUbigeoService, UbigeoService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SISGRAFH.Api v1"));
            }

            //configuracion de la poliza Cross Origin Request Side
            app.UseCors(PolizaCORSSISGEM);

            app.UseHttpsRedirection();

            app.UseRouting();

            //Autorizacion y auntenticacion mediante tokens JWT
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
