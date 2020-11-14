using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaApi.Models;

namespace ClinicaApi.Services.Interfaces
{
    public interface IClienteServices
    {
        Task AddAsync(Cliente cliente);
        Task<List<Cliente>> GetUserByCPFAsync(string cpf);
        Task<Cliente> GetAsync(string cpf);
        Task<List<Cliente>> GetAllAsync();
        Task<List<Cliente>> GetAllDeletedAsync();
        Task DeleteLogicallyAsync(string cpf);
        Task DeleteLogicallyAsync(Cliente cliente);
        Task DeleteAsync(string cpf);
        Task DeleteAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);

    }
}