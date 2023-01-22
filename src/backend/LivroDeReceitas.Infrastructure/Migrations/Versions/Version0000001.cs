using FluentMigrator;

namespace LivroDeReceitas.Infrastructure.Migrations.Versions
{
    [Migration((long)EnumVersions.CriarTabelaUsuario, "Cria tabela de usuario")]
    public class Version0000001 : Migration
    {
        public override void Down(){}

        public override void Up()
        {
            var table = BaseVersion.InsertStandardColumns(Create.Table("TB_USUARIO"));

            table
                .WithColumn("DS_NOME").AsString(100).NotNullable()
                .WithColumn("DS_EMAIL").AsString(100).NotNullable()
                .WithColumn("DS_SENHA").AsString(2000).NotNullable()
                .WithColumn("DS_TELEFONE").AsString(14).NotNullable();
        }
    }
}
