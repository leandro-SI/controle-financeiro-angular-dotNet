using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Infra.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfraEstructureAPI(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
                ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<Usuario, Funcao>().AddEntityFrameworkStores<ApplicationDbContext>();


            return services;
        }
    }
}
