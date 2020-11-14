using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaApi.Models;
using ClinicaApi.Respository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ClinicaApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHttpContextAccessor context;

        public UsuarioRepository(UserManager<ApplicationUser> userManager, IHttpContextAccessor context)
        {
            this.userManager = userManager;
            this.context = context;
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
        public async Task<ApplicationUser> GetUserAsync()
        {
            return await userManager.GetUserAsync(context.HttpContext.User);
        }
    }
}