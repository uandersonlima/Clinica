using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaApi.Models;
using ClinicaApi.Respository.Interfaces;
using ClinicaApi.Services.Interfaces;

namespace ClinicaApi.Services
{
    public class ClienteService : IClienteServices
    {
        private readonly IClienteRespository clienteRepos;
        private readonly IUsuarioRepository usuarioRepos;

        public ClienteService(IClienteRespository clienteRepos, IUsuarioRepository usuarioRepos)
        {
            this.clienteRepos = clienteRepos;
            this.usuarioRepos = usuarioRepos;
        }

        public async Task AddAsync(Cliente cliente)
        {
            await clienteRepos.AddAsync(cliente);
        }

        public async Task DeleteAsync(string cpf)
        {
            var cliente = await GetAsync(cpf);
            await DeleteAsync(cliente);
        }

        public async Task DeleteAsync(Cliente cliente)
        {
            await clienteRepos.DeleteAsync(cliente);
        }

        public async Task DeleteLogicallyAsync(string cpf)
        {
            var cliente = await GetAsync(cpf);
            await DeleteLogicallyAsync(cliente);
        }

        public async Task DeleteLogicallyAsync(Cliente cliente)
        {
            cliente.isDeleted = !cliente.isDeleted;
            await UpdateAsync(cliente);
        }

        public async Task<List<Cliente>> GetAllAsync()
        {
            return await clienteRepos.GetAllAsync(usuarioRepos.GetUserAsync().Result.Id);
        }

        public async Task<List<Cliente>> GetAllDeletedAsync()
        {
            return await clienteRepos.GetAllDeletedAsync(usuarioRepos.GetUserAsync().Result.Id);
        }

        public async Task<Cliente> GetAsync(string cpf)
        {
            return await clienteRepos.GetAsync(cpf, usuarioRepos.GetUserAsync().Result.Id);
        }

        public async Task<List<Cliente>> GetUserByCPFAsync(string cpf)
        {
            return await clienteRepos.GetUserByCPFAsync(cpf);
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            await clienteRepos.UpdateAsync(cliente);
        }
    }
}