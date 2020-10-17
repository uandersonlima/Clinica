using ClinicaApi.Models;
using ClinicaApi.Models.Associativas;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClinicaApi.Data
{
    public class ClinicaContext : IdentityDbContext<ApplicationUser>
    {
        public ClinicaContext(DbContextOptions<ClinicaContext> options) : base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MedicoEspecialidade>().HasKey(cfg => new { cfg.MedicoCRM, cfg.EspecialidadeCodigo });
        }

    }
}