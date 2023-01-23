using FluentMigrator.Runner;
using LivroDeReceitas.Domain.Extension;
using LivroDeReceitas.Domain.Repositories;
using LivroDeReceitas.Infrastructure.RepositoryAccess;
using LivroDeReceitas.Infrastructure.RepositoryAccess.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace LivroDeReceitas.Infrastructure
{
    public static class Bootstrapper
    {
        public static void AddRepository(this IServiceCollection services, IConfiguration configurationManager)
        {
            AddFluentMigrator(services, configurationManager);
            AddContext(services, configurationManager);
            AddUnidadeDeTrabalho(services);
            AddRepositories(services);
        }

        public static void AddContext(IServiceCollection services, IConfiguration configurationManager)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
            var connectionString = configurationManager.GetFullConnection();

            services.AddDbContext<LivroDeReceitasContext>(options =>
            {
                options.UseMySql(connectionString, serverVersion);
            });
        }

        private static void AddUnidadeDeTrabalho(IServiceCollection services)
        {
            services.AddScoped<IUnidadeDeTrabalho, UnidadeDeTrabalho>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUsuarioWriteOnlyRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioReadOnlyRepository, UsuarioRepository>();
        }

        private static void AddFluentMigrator(IServiceCollection services, IConfiguration configurationManager)
        {
            var connection = configurationManager.GetConnection();
            var database = configurationManager.GetDatabaseName();

            services.AddFluentMigratorCore().ConfigureRunner(c =>
                c.AddMySql5()
                .WithGlobalConnectionString(configurationManager.GetFullConnection()).ScanIn(Assembly.Load("LivroDeReceitas.Infrastructure"))
                .For.All());
        }
    }
}
