using System.Threading.Tasks;
using ClinicaApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ClinicaApi.Models.DTO;
using ClinicaApi.Models;
using System.Collections.Generic;

namespace ClinicaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServices clienteServices;
        private readonly IUsuarioServices usuarioServices;

        public ClienteController(IClienteServices clienteServices, IUsuarioServices usuarioServices)
        {
            this.clienteServices = clienteServices;
            this.usuarioServices = usuarioServices;
        }

        [Authorize, HttpPost("")]
        public async Task<IActionResult> Create(ClienteDTO clienteDTO)
        {
            if (ModelState.IsValid)
            {
                var userLogged = await usuarioServices.GetUserAsync();

                var trueCliente = new Cliente
                {
                    CPF = clienteDTO.CPF,
                    Nome = clienteDTO.Nome,
                    Birthday = clienteDTO.Birthday,
                    Sexo = clienteDTO.Sexo,
                    Contato = new Contato
                    {
                        Email = clienteDTO.Contato.Email,
                        Telefone = clienteDTO.Contato.Telefone
                    },
                    UsuarioId = userLogged.Id
                };
                clienteServices.AddAsync(trueCliente);
                return Ok(clienteDTO);
            }
            return UnprocessableEntity(ModelState);
        }

        [Authorize, HttpPut("")]
        public async Task<IActionResult> Update(ClienteDTO clienteDTO)
        {
            if (ModelState.IsValid)
            {
                Cliente cliente = await clienteServices.GetAsync(clienteDTO.CPF);
                if (cliente == null)
                {
                    return NotFound();
                }

                cliente.Nome = clienteDTO.Nome;
                cliente.Sexo = clienteDTO.Sexo;
                cliente.Birthday = clienteDTO.Birthday;
                await clienteServices.UpdateAsync(cliente);

                return Ok(cliente);
            }
            return UnprocessableEntity(ModelState);

        }

        [Authorize, HttpDelete("logical/{cpf}")]
        public async Task<IActionResult> DeleteLogical(string cpf)
        {
            Cliente cliente = await clienteServices.GetAsync(cpf);
            if (cliente == null)
            {
                return NotFound();
            }
            await clienteServices.DeleteLogicallyAsync(cliente);
            return Ok();
        }

        [Authorize, HttpDelete("{cpf}")]
        public async Task<IActionResult> Delete(string cpf)
        {
            Cliente cliente = await clienteServices.GetAsync(cpf);
            if (cliente == null)
            {
                return NotFound();
            }
            clienteServices.DeleteAsync(cliente);
            return Ok();
        }

        [Authorize, HttpGet("{cpf}")]
        public async Task<IActionResult> Get(string cpf)
        {
            Cliente cliente = await clienteServices.GetAsync(cpf);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [Authorize, HttpGet("deleted")]
        public async Task<IActionResult> GetAllDeleted()
        {
            List<Cliente> cliente = await clienteServices.GetAllDeletedAsync();
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [Authorize, HttpGet("")]
        public async Task<IActionResult> GetAllNoDeleted()
        {
            List<Cliente> cliente = await clienteServices.GetAllAsync();
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpGet("teste")]
        public IActionResult GetJson()
        {
            return Ok(new ClienteDTO());
        }

    }
}