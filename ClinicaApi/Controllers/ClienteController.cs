using ClinicaApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController:ControllerBase
    {
        private readonly IClienteServices clienteServices;

        public ClienteController(IClienteServices clienteServices)
        {
            this.clienteServices = clienteServices;
        }

        [HttpPost("")]
        [Authorize]
        public IActionResult TESTEDELOGIN()
        {
            return Ok("Você tem permissão");
        }


    }
}