using FluentMigrator.Builders.Create.Table;

namespace LivroDeReceitas.Infrastructure.Migrations
{
    public static class BaseVersion
    {
        public static ICreateTableColumnOptionOrWithColumnSyntax InsertStandardColumns(ICreateTableWithColumnOrSchemaOrDescriptionSyntax table)
        {
            return table
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("DataCadastro").AsDateTime().NotNullable();
        }
    }
}
