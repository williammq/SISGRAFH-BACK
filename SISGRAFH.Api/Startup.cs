using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SISGRAFH.Core.Interfaces;
using SISGRAFH.Core.Services;
using SISGRAFH.Infraestructure.Data;
using SISGRAFH.Infraestructure.Data.Interfaces;
using SISGRAFH.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SISGRAFH.Api", Version = "v1" });
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
            services.AddSingleton<MongoContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IMaquinaService, MaquinaService>();
            services.AddTransient<ICotizacionService, CotizacionService>();
            services.AddTransient<IInsumoService, InsumoService>();
            services.AddTransient<IProductoService, ProductoService>();
            services.AddTransient<ISolicitudService, SolicitudService>();
            services.AddTransient<IMovimientoService, MovimientoService>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
