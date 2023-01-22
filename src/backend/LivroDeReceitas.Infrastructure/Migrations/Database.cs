using Dapper;
using MySqlConnector;
using System.Runtime.InteropServices;

namespace LivroDeReceitas.Infrastructure.Migrations
{
    public static class Database
    {
        public static void CriateDatabase(string connectionString, string databaseName)
        {
            // O Using fecha a conexao automaticamente
            using var connection = new MySqlConnection(connectionString);

            var parameters = new DynamicParameters();
            parameters.Add("name", databaseName);

            var records = connection.Query("SELECT * FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = @name", parameters);
            
            if(!records.Any())
            {
                connection.Execute($"CREATE DATABASE {databaseName}");
            }
        }
    }
}
