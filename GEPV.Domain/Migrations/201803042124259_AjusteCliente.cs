namespace GEPV.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjusteCliente : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.ENDERECO_CLIENTE", "ID_CLIENTE", "dbo.CLIENTE");
            //DropForeignKey("dbo.COMPRADOR", "ID_USUARIO", "dbo.USUARIO");
            //DropIndex("dbo.ENDERECO_CLIENTE", new[] { "ID_CLIENTE" });
            //DropIndex("dbo.COMPRADOR", new[] { "ID_USUARIO" });
            //CreateTable(
            //    "dbo.ESTADO",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            DESCRICAO = c.String(unicode: false),
            //            SIGLA = c.String(unicode: false),
            //        })
            //    .PrimaryKey(t => t.ID);
            
            //CreateTable(
            //    "dbo.REGIAO",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            DESCRICAO = c.String(unicode: false),
            //        })
            //    .PrimaryKey(t => t.ID);
            
            //AddColumn("dbo.CLIENTE", "LOGRADOURO", c => c.String(unicode: false));
            //AddColumn("dbo.CLIENTE", "NUMERO", c => c.String(unicode: false));
            //AddColumn("dbo.CLIENTE", "BAIRRO", c => c.String(unicode: false));
            //AddColumn("dbo.CLIENTE", "CEP", c => c.String(unicode: false));
            //AddColumn("dbo.CLIENTE", "CIDADE", c => c.String(unicode: false));
            //AddColumn("dbo.CLIENTE", "ID_ESTADO", c => c.Int(nullable: false));
            //AddColumn("dbo.CLIENTE", "ID_REGIAO", c => c.Int(nullable: false));
            //AddColumn("dbo.COMPRADOR", "USUARIO", c => c.String(unicode: false));
            //AddColumn("dbo.COMPRADOR", "SENHA", c => c.String(unicode: false));
            //CreateIndex("dbo.CLIENTE", "ID_ESTADO");
            //CreateIndex("dbo.CLIENTE", "ID_REGIAO");
            //AddForeignKey("dbo.CLIENTE", "ID_ESTADO", "dbo.ESTADO", "ID", cascadeDelete: true);
            //AddForeignKey("dbo.CLIENTE", "ID_REGIAO", "dbo.REGIAO", "ID", cascadeDelete: true);

            
            //DropTable("dbo.ENDERECO_CLIENTE");
            //DropTable("dbo.USUARIO");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.USUARIO",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        USUARIO = c.String(unicode: false),
                        SENHA = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ENDERECO_CLIENTE",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LOGRADOURO = c.String(unicode: false),
                        NUMERO = c.String(unicode: false),
                        BAIRRO = c.String(unicode: false),
                        CEP = c.String(unicode: false),
                        CIDADE = c.String(unicode: false),
                        ID_ESTADO = c.Int(nullable: false),
                        ID_REGIAO = c.Int(nullable: false),
                        IND_ENDERECO_ENTREGA = c.Boolean(nullable: false),
                        ID_CLIENTE = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.COMPRADOR", "ID_USUARIO", c => c.Int(nullable: false));
            DropForeignKey("dbo.CLIENTE", "ID_REGIAO", "dbo.REGIAO");
            DropForeignKey("dbo.CLIENTE", "ID_ESTADO", "dbo.ESTADO");
            DropIndex("dbo.CLIENTE", new[] { "ID_REGIAO" });
            DropIndex("dbo.CLIENTE", new[] { "ID_ESTADO" });
            DropColumn("dbo.COMPRADOR", "SENHA");
            DropColumn("dbo.COMPRADOR", "USUARIO");
            DropColumn("dbo.CLIENTE", "ID_REGIAO");
            DropColumn("dbo.CLIENTE", "ID_ESTADO");
            DropColumn("dbo.CLIENTE", "CIDADE");
            DropColumn("dbo.CLIENTE", "CEP");
            DropColumn("dbo.CLIENTE", "BAIRRO");
            DropColumn("dbo.CLIENTE", "NUMERO");
            DropColumn("dbo.CLIENTE", "LOGRADOURO");
            DropTable("dbo.REGIAO");
            DropTable("dbo.ESTADO");
            CreateIndex("dbo.COMPRADOR", "ID_USUARIO");
            CreateIndex("dbo.ENDERECO_CLIENTE", "ID_CLIENTE");
            AddForeignKey("dbo.COMPRADOR", "ID_USUARIO", "dbo.USUARIO", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ENDERECO_CLIENTE", "ID_CLIENTE", "dbo.CLIENTE", "ID", cascadeDelete: true);
        }
    }
}
