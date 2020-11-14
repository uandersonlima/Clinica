using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaApi.Models;

namespace ClinicaApi.Services.Interfaces
{
    public interface IUsuarioServices
    {
        Task<ApplicationUser> GetUserAsync(string email, string senha);
        Task<List<string>> CreateAsync(ApplicationUser user, string senha);
        Task<ApplicationUser> GetUserAsync();

    }
}