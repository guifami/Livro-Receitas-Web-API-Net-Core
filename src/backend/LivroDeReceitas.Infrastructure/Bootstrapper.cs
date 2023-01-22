using FluentMigrator.Runner;
using LivroDeReceitas.Domain.Extension;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LivroDeReceitas.Infrastructure
{
    public static class Bootstrapper
    {
        public static void AddRepository(this IServiceCollection services, IConfiguration configurationManager)
        {
            AddFluentMigrator(services, configurationManager);
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
