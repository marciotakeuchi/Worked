using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Worked.Application.Interfaces;
using Worked.Application.Services;
using Worked.Domain.Interfaces;
using Worked.Infra.Data;
using Worked.Infra.Models;
using Worked.Infra.Repositories;

namespace Worked.Infra.IoC
{
    public static class DependencyInjection
    {

        public static WebApplicationBuilder AddInfrastruture(this WebApplicationBuilder builder)//this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("CoonectionString DefaultConnection nao encontrado");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            //builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options => { options.SignIn.RequireConfirmedAccount = false; })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            builder.Services.AddScoped<ICargoRepository, CargoRepository>();
            builder.Services.AddScoped<IRegimeTrabalhistaRepository, RegimeTrabalhistaRepository>();
            builder.Services.AddScoped<IFuncionarioServices, FuncionarioServices>();
            builder.Services.AddScoped<ICargoServices, CargoServices>();
            builder.Services.AddScoped<IRegimeTrabalhistaServices, RegimeTrabalhistaServices>();


            return builder;
        }
    }
}
