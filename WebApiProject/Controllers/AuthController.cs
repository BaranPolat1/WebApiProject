using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Services.Abstract;
using Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utility.Auth.VM;

namespace WebApiProject.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService authService;
        public AuthController(IAuthService _authService)
        {
            authService = _authService;
        }
        [HttpPost("login")]
        public IActionResult Login(LoginVM loginVM)
        {
            var userLogin = authService.Login(loginVM);
            if (!userLogin.Success)
            {
                return BadRequest(userLogin.Message);
            }
           var result = authService.CreateAccesToken(userLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterVM registerVM)
        {
            var userExist = authService.GetByEmail(registerVM.Email);
            //if (userExist!=null)
            //{
            //    return BadRequest(userExist.Message);
            //}
            var register = authService.Register(registerVM, registerVM.Password);
            var result = authService.CreateAccesToken(register.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

    }
}