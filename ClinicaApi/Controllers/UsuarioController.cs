using System.Threading.Tasks;
using ClinicaApi.Models;
using ClinicaApi.Models.DTO;
using ClinicaApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUsuarioServices usuarioServices;

        public UsuarioController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IUsuarioServices usuarioServices)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.usuarioServices = usuarioServices;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioDTO usuarioDTO)
        {
            ModelState.Remove("ConfirmacaoSenha");
            if (ModelState.IsValid)
            {
                ApplicationUser usuario = await usuarioServices.GetUserAsync(usuarioDTO.Email, usuarioDTO.Senha);
                if (usuario != null)
                {
                    await signInManager.SignInAsync(usuario, false); //gera cookies
                    //retorna JWT
                    // var token = BuildToken(usuario);
                    // var tokenModel = new Token()
                    // {
                    //     RefreshToken = token.RefreshToken,
                    //     ExpirationToken = token.Expiration,
                    //     ExpirationRefreshToken = token.ExpirationRefreshToken,
                    //     Usuario = usuario,
                    //     Criado = DateTime.Now,
                    //     Utilizado = false
                    // };
                    // _tokenRepository.Cadastrar(tokenModel);
                    return Ok(await userManager.GetUserAsync(HttpContext.User));
                }
                else
                {
                    return NotFound("Usuario não localizado");
                }

            }
            else
            {
                return UnprocessableEntity(ModelState);
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> Cadastro([FromBody] UsuarioDTO usuarioDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await usuarioServices.CreateAsync(UsuarioInAppUser(usuarioDTO), usuarioDTO.Senha);

                if (result.Count > 0)
                {
                    return UnprocessableEntity(result);
                }
                else
                {
                    return Ok(usuarioDTO);
                }
            }
            else
            {
                return UnprocessableEntity(ModelState);
            }
        }
        private ApplicationUser UsuarioInAppUser(UsuarioDTO usuarioDTO)
        {
            return new ApplicationUser
            {
                Email = usuarioDTO.Email,
                UserName = usuarioDTO.Email
            };
        }
        
        [Authorize, HttpGet("")]
        public async Task<IActionResult> Get()
        {
            return Ok(await usuarioServices.GetUserAsync());
        } 

        [Authorize, HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            return Ok(signInManager.SignOutAsync());
        }
    }
}