
using System.Threading.Tasks;
using ClinicaApi.Data;
using ClinicaApi.Models;
using ClinicaApi.Repository;
using ClinicaApi.Respository.Interfaces;
using ClinicaApi.Services;
using ClinicaApi.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace ClinicaApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(op =>
            {
                op.SuppressModelStateInvalidFilter = true;
            });

            services.AddControllers();
            services.AddHttpContextAccessor();

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ClinicaContext>().AddDefaultTokenProviders();
            services.AddDbContext<ClinicaContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("ClinicaContext"), builder =>
                       builder.MigrationsAssembly("ClinicaApi"))
            );
            services.AddScoped<ClinicaContext>();

            #region Services
            services.AddScoped<IClienteServices, ClienteService>();
            services.AddScoped<IConsultaServices, ConsultaService>();
            services.AddScoped<IContatoServices, ContatoService>();
            services.AddScoped<IEspecialidadeServices, EspecialidadeService>();
            services.AddScoped<IMedicoServices, MedicoService>();
            services.AddScoped<IUsuarioServices, UsuarioService>();
            #endregion

            #region Repository
            services.AddScoped<IClienteRespository, ClienteRepository>();
            services.AddScoped<IConsultaRespository, ConsultaRepository>();
            services.AddScoped<IContatoRespository, ContatoRepository>();
            services.AddScoped<IEspecialidadeRespository, EspecialidadeRepository>();
            services.AddScoped<IMedicoRespository, MedicoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            #endregion
            services.AddScoped<ClinicaContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = false;
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseStatusCodePages();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
