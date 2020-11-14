using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaApi.Data;
using ClinicaApi.Models;
using ClinicaApi.Respository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicaApi.Repository
{
    public class ClienteRepository : IClienteRespository
    {
        private readonly ClinicaContext context;

        public ClienteRepository(ClinicaContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(Cliente cliente)
        {
            await context.Clientes.AddAsync(cliente);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Cliente cliente)
        {
            context.Clientes.Remove(cliente);
            await context.SaveChangesAsync();         
        }
        public async Task<List<Cliente>> GetAllAsync(string userLoggedId)
        {
            return await context.Clientes.Where(cliente => !cliente.isDeleted).ToListAsync();
        }
        public async Task<List<Cliente>> GetAllDeletedAsync(string userLoggedId)
        {
            return await context.Clientes.Where(cliente => cliente.isDeleted).ToListAsync();
        }
        public async Task<Cliente> GetAsync(string cpf, string userLoggedId)
        {
            return await context.Clientes.Where(cliente => cliente.CPF == cpf && cliente.UsuarioId == userLoggedId).FirstOrDefaultAsync();
        }
        public async Task<List<Cliente>> GetUserByCPFAsync(string cpf)
        {
            return await context.Clientes.Where(cliente => cliente.CPF == cpf).ToListAsync();
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            context.Clientes.Update(cliente);
            await context.SaveChangesAsync();
        }
    }
}