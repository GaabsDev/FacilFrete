using EasyFreteApp.Application.Service;
using EasyFreteApp.Domain.Repository;
using EasyFreteApp.Domain.Service;
using EasyFreteApp.Infra.Data;
using EasyFreteApp.Infra.Data.Interface;
using EasyFreteApp.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EasyFreteApp.Infra.CrossCutting
{
    public class BootStrapper
    {
        private static readonly string DATABASE_HOST = Environment.GetEnvironmentVariable("HOST");
        private static readonly string DATABASE_PORT = Environment.GetEnvironmentVariable("PORT");
        private static readonly string DATABASE_USER = Environment.GetEnvironmentVariable("USER");
        private static readonly string DATABASE_PASS = Environment.GetEnvironmentVariable("PASS");
        private static readonly string DATABASE_NAME = Environment.GetEnvironmentVariable("DATABASE_NAME");

        public static void RegisterServices(IServiceCollection services)
        {
            // Service
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ICepService, CepService>();
            services.AddScoped<IRaioPrecoService, RaioPrecoService>();
            services.AddScoped<IGeospatialService, GeospatialService>();

            // Repository
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ICepRepository, CepRepository>();
            services.AddScoped<IRaioPrecoRepository, RaioPrecoRepository>();


            //connectionString
            var connectionString = $"Server={DATABASE_HOST}{(string.IsNullOrEmpty(DATABASE_PORT) ? "" : "," + DATABASE_PORT)};Database={DATABASE_NAME};User Id={DATABASE_USER};Password={DATABASE_PASS}";

            services.AddHealthChecks()
                    .AddSqlServer(connectionString);

            //Context
            services.AddScoped<IContext, Context>();
            services.AddDbContext<Context>(options => options
                    .UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.CommandTimeout(30)));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
