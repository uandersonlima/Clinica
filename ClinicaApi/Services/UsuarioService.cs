using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaApi.Models;
using ClinicaApi.Respository.Interfaces;
using ClinicaApi.Services.Interfaces;

namespace ClinicaApi.Services
{
    public class UsuarioService : IUsuarioServices
    {
        private IUsuarioRepository usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public async Task<List<string>> CreateAsync(ApplicationUser user, string senha)
        {
            return await usuarioRepository.CreateAsync(user, senha);
        }

        public async Task<ApplicationUser> GetUserAsync(string email, string senha)
        {
            return await usuarioRepository.GetUserAsync(email, senha);
        }
    }
}