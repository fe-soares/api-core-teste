using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using De.Api.ViewModels;
using De.Business.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace De.Api.Controllers
{
    [Route("api")]
    public class AuthController : MainController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        protected AuthController(INotificador notificador,
                                 SignInManager<IdentityUser> signInManager,
                                 UserManager<IdentityUser> userManager) : base(notificador)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("nova-conta")]
        public async Task<ActionResult> Registrar(RegisterUserViewModel registerUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new IdentityUser
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);//segundo param, quardar infor para facilitar o login 
                return CustomResponse(registerUser);
            }
            foreach (var error in result.Errors)
            {
                NotificarError(error.Description);
            }

            return CustomResponse(registerUser);
        }

        [HttpPost("entrar")]
        public async Task<ActionResult> Login(LoginUserViewModel loginUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);
            //3° param tem que ser falso, pois a aplicação é webapi
            //4 ° para lockar o user caso tenha muita tentativa de acesso, por default acho que é 5min de lock

            if (result.Succeeded)
            {
                return CustomResponse(loginUser);
            }
            if (result.IsLockedOut)
            {
                NotificarError("Usuário temporariamente bloqueado, tente novamente mais tarde");
                return CustomResponse(loginUser);
            }

            NotificarError("Usuário ou senha incorretos");
            return CustomResponse(loginUser);
        }
    }
}
