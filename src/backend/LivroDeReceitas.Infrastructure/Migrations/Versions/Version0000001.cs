using FluentMigrator;

namespace LivroDeReceitas.Infrastructure.Migrations.Versions
{
    [Migration((long)EnumVersions.CriarTabelaUsuario, "Cria tabela de usuario")]
    public class Version0000001 : Migration
    {
        public override void Down() { }

        public override void Up()
        {
            var table = BaseVersion.InsertStandardColumns(Create.Table("usuarios"));

            table
                .WithColumn("Nome").AsString(100).NotNullable()
                .WithColumn("Email").AsString(100).NotNullable()
                .WithColumn("Senha").AsString(2000).NotNullable()
                .WithColumn("Telefone").AsString(14).NotNullable();
        }
    }
}
