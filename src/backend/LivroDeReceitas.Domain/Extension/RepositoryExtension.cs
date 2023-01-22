using Microsoft.Extensions.Configuration;

namespace LivroDeReceitas.Domain.Extension
{
    public static class RepositoryExtension
    {
        public static string GetDatabaseName(this IConfiguration configurationManager)
        {
            var database = configurationManager.GetConnectionString("databaseName");
            return database;
        }
        public static string GetConnection(this IConfiguration configurationManager)
        {
            var connection = configurationManager.GetConnectionString("connection");
            return connection;
        }

        public static string GetFullConnection(this IConfiguration configurationManager)
        {
            var database = configurationManager.GetDatabaseName();
            var connection = configurationManager.GetConnection();

            return $"{connection}Database={database}";
        }
    }
}
