using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SISGRAFH.Api.Responses;
using SISGRAFH.Core.DTOs.Login;
using SISGRAFH.Core.DTOs.Usuario;
using SISGRAFH.Core.Entities;
using SISGRAFH.Core.Interfaces.Login;
using SISGRAFH.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SISGRAFH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private static ILoginService _loginService;
        private static IMapper _mapper;
        public LoginController(ILoginService loginService, IMapper mapper)
        {
            _loginService = loginService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthUserToken>> Login([FromBody] AuthUserInfo userInfo)
        {
            try
            {
                if(userInfo == null || string.IsNullOrEmpty(userInfo.useremail) || string.IsNullOrEmpty(userInfo.password))
                {
                    return BadRequest("No se enviaron los datos requeridos para la autorización");
                }
                var result = await _loginService.GetAuthorization(userInfo);

                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }


    }
}
