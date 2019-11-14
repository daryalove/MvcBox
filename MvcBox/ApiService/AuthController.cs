using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.ViewModels;
using Entities.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Http;
using Entities.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;

namespace MvcBox.ApiService
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        UserManager<User> _userManager;
        SignInManager<User> _signInManager;
        RoleManager<IdentityRole> _roleManager;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        //Получение сформированного ответа регистрации: "успешно" или описание ошибки...
        //...,а также получение фамилии,имени, логина
        //http://iot-tmc-cen.1gb.ru//api/auth/register
        [HttpPost]
        [Route("Register")]
        public async Task<ServiceResponseObject<AuthResponse>> Register(RegisterViewModel model)
        {
            AuthMethods AuthData = new AuthMethods(_userManager, _signInManager, _roleManager);
            var Result = await AuthData.Register(model);
            return Result;
        }

        //Получение сформированного ответа авторизации: "Авторизация прошла успешно!" или ...
        //... "Неправильный логин и(или) пароль",а также получение фамилии,имени,логина
        //http://iot-tmc-cen.1gb.ru//api/auth/login
        [HttpPost]
        [Route("Login")]
        public async Task<ServiceResponseObject<AuthResponse>> Login(LoginViewModel model)
        {
            AuthMethods AuthData = new AuthMethods(_userManager, _signInManager, _roleManager);
            var Result = await AuthData.Login(model);
            return Result;
        }
        // GET: api/Auth
        [HttpGet]
        [Route("Get")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        
    }
}
