using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaApi.Models;

namespace ClinicaApi.Respository.Interfaces
{
    public interface IClienteRespository
    {
        Task AddAsync(Cliente cliente);
        Task<List<Cliente>> GetUserByCPFAsync(string cpf);
        Task<Cliente> GetAsync(string cpf, string userLoggedId);
        Task<List<Cliente>> GetAllAsync(string userLoggedId);
        Task<List<Cliente>> GetAllDeletedAsync(string userLoggedId);
        Task DeleteAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);

    }
}