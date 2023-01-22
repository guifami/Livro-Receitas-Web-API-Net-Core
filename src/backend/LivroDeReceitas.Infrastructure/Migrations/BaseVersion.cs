using FluentMigrator.Builders.Create.Table;

namespace LivroDeReceitas.Infrastructure.Migrations
{
    public static class BaseVersion
    {
        public static ICreateTableColumnOptionOrWithColumnSyntax InsertStandardColumns(ICreateTableWithColumnOrSchemaOrDescriptionSyntax table)
        {
            return table
                .WithColumn("ID_USUARIO").AsInt64().PrimaryKey().Identity()
                .WithColumn("DT_CRIACAO").AsDateTime().NotNullable();
        }
    }
}
