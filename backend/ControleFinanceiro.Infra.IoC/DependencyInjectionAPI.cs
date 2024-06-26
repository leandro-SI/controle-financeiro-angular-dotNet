﻿using ControleFinanceiro.Application.Dtos;
using ControleFinanceiro.Application.Interfaces;
using ControleFinanceiro.Application.Mappings;
using ControleFinanceiro.Application.Services;
using ControleFinanceiro.Application.Validations;
using ControleFinanceiro.Domain.Account;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Infra.Data.Context;
using ControleFinanceiro.Infra.Data.Identity;
using ControleFinanceiro.Infra.Data.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ControleFinanceiro.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfraEstructureAPI(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
                ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 0;
                options.SignIn.RequireConfirmedAccount = false;
            });

            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthenticate, AuthenticateService>();

            services.AddTransient<IValidator<CategoriaDTO>, CategoriaValidator>();
            services.AddTransient<IValidator<FuncaoDTO>, FuncaoValidator>();
            services.AddTransient<IValidator<RegisterDTO>, RegisterValidator>();
            services.AddTransient<IValidator<LoginDTO>, LoginValidator>();
            services.AddTransient<IValidator<CartaoDTO>, CartaoValidator>();
            services.AddTransient<IValidator<DespesaDTO>, DespesaValidator>();
            services.AddTransient<IValidator<UsuarioUpdateDTO>, UsuarioUpdateValidator>();

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<ITipoRepository, TipoRepository>();
            services.AddScoped<ITipoService, TipoService>();
            services.AddScoped<IFuncaoRepository, FuncaoRepository>();
            services.AddScoped<IFuncaoService, FuncaoService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ICartaoRepository, CartaoRepository>();
            services.AddScoped<ICartaoService, CartaoService>();
            services.AddScoped<IDespesaRepository, DespesaRepository>();
            services.AddScoped<IDespesaService, DespesaService>();
            services.AddScoped<IMesRepository, MesRepository>();
            services.AddScoped<IMesService, MesService>();
            services.AddScoped<IGanhoRepository, GanhoRepository>();
            services.AddScoped<IGanhoService, GanhoService>();
            services.AddScoped<IGraficoRepository, GraficoRepository>();
            services.AddScoped<IGraficoService, GraficoService>();
            

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}
