using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaApi.Models;
using ClinicaApi.Respository.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ClinicaApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UsuarioRepository(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<List<string>> CreateAsync(ApplicationUser user, string senha)
        {
            var result = await userManager.CreateAsync(user, senha);
            if (!result.Succeeded)
            {
                List<string> sb = new List<string>();
                foreach (var erro in result.Errors)
                {
                    sb.Add(erro.Description);
                }
                return sb;
            }
            return new List<string>();
        }

        public async Task<ApplicationUser> GetUserAsync(string email, string senha)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (await userManager.CheckPasswordAsync(user, senha))
                return user;

            return null;
        }


    }
}