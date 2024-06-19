﻿using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.Interfaces;
using ControleFinanceiro.Application.Mappings;
using ControleFinanceiro.Application.Services;
using ControleFinanceiro.Application.Validations;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Infra.Data.Context;
using ControleFinanceiro.Infra.Data.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
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

            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();

            services.AddTransient<IValidator<CategoriaDTO>, CategoriaValidator>();

            services.AddIdentity<Usuario, Funcao>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<ITipoRepository, TipoRepository>();
            services.AddScoped<ITipoService, TipoService>();
            services.AddScoped<IFuncaoRepository, FuncaoRepository>();
            services.AddScoped<IFuncaoService, FuncaoService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));



            return services;
        }
    }
}
