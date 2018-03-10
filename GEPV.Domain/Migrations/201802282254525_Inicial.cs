namespace GEPV.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.CLIENTE",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            RAZAO_SOCIAL = c.String(unicode: false),
            //            NomeFantasia = c.String(unicode: false),
            //            CNPJ = c.String(unicode: false),
            //            INSCRICAO_ESTADUAL = c.String(unicode: false),
            //            TELEFONE_PRINCIPAL = c.String(unicode: false),
            //            TELEFONE_CONTATO = c.String(unicode: false),
            //            EMAIL_PRINCIPAL = c.String(unicode: false),
            //            EMAIL_NFE = c.String(unicode: false),
            //            OBSERVACAO = c.String(unicode: false),
            //        })
            //    .PrimaryKey(t => t.ID);
            
            //CreateTable(
            //    "dbo.ENDERECO_CLIENTE",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            LOGRADOURO = c.String(unicode: false),
            //            NUMERO = c.String(unicode: false),
            //            BAIRRO = c.String(unicode: false),
            //            CEP = c.String(unicode: false),
            //            CIDADE = c.String(unicode: false),
            //            ID_ESTADO = c.Int(nullable: false),
            //            ID_REGIAO = c.Int(nullable: false),
            //            IND_ENDERECO_ENTREGA = c.Boolean(nullable: false),
            //            ID_CLIENTE = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.CLIENTE", t => t.ID_CLIENTE, cascadeDelete: true)
            //    .Index(t => t.ID_CLIENTE);
            
            //CreateTable(
            //    "dbo.COMPRADOR",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            NOME = c.String(unicode: false),
            //            DATA_NASCIMENTO = c.DateTime(precision: 0),
            //            EMAIL = c.String(unicode: false),
            //            ID_USUARIO = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.USUARIO", t => t.ID_USUARIO, cascadeDelete: true)
            //    .Index(t => t.ID_USUARIO);
            
            //CreateTable(
            //    "dbo.USUARIO",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            USUARIO = c.String(unicode: false),
            //            SENHA = c.String(unicode: false),
            //        })
            //    .PrimaryKey(t => t.ID);
            
            //CreateTable(
            //    "dbo.CONTATOS",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            ID_COMPRADOR = c.Int(nullable: false),
            //            ID_CLIENTE = c.Int(nullable: false),
            //            ID_FORNECEDOR = c.Int(nullable: false),
            //            Descricao = c.String(unicode: false),
            //            DATA_CONTATO = c.DateTime(nullable: false, precision: 0),
            //            DATA_COMPRA = c.DateTime(precision: 0),
            //            DATA_AGENDA = c.DateTime(precision: 0),
            //            DATA_REAGENDA = c.DateTime(precision: 0),
            //            SITUACAO = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.CLIENTE", t => t.ID_CLIENTE, cascadeDelete: true)
            //    .ForeignKey("dbo.COMPRADOR", t => t.ID_COMPRADOR, cascadeDelete: true)
            //    .ForeignKey("dbo.FORNECEDOR", t => t.ID_FORNECEDOR, cascadeDelete: true)
            //    .Index(t => t.ID_COMPRADOR)
            //    .Index(t => t.ID_CLIENTE)
            //    .Index(t => t.ID_FORNECEDOR);
            
            //CreateTable(
            //    "dbo.FORNECEDOR",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            NomeFantasia = c.String(unicode: false),
            //            SIGLA_FORNECEDOR = c.String(unicode: false),
            //            OBSERVACAO = c.String(unicode: false),
            //        })
            //    .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CONTATOS", "ID_FORNECEDOR", "dbo.FORNECEDOR");
            DropForeignKey("dbo.CONTATOS", "ID_COMPRADOR", "dbo.COMPRADOR");
            DropForeignKey("dbo.CONTATOS", "ID_CLIENTE", "dbo.CLIENTE");
            DropForeignKey("dbo.COMPRADOR", "ID_USUARIO", "dbo.USUARIO");
            DropForeignKey("dbo.ENDERECO_CLIENTE", "ID_CLIENTE", "dbo.CLIENTE");
            DropIndex("dbo.CONTATOS", new[] { "ID_FORNECEDOR" });
            DropIndex("dbo.CONTATOS", new[] { "ID_CLIENTE" });
            DropIndex("dbo.CONTATOS", new[] { "ID_COMPRADOR" });
            DropIndex("dbo.COMPRADOR", new[] { "ID_USUARIO" });
            DropIndex("dbo.ENDERECO_CLIENTE", new[] { "ID_CLIENTE" });
            DropTable("dbo.FORNECEDOR");
            DropTable("dbo.CONTATOS");
            DropTable("dbo.USUARIO");
            DropTable("dbo.COMPRADOR");
            DropTable("dbo.ENDERECO_CLIENTE");
            DropTable("dbo.CLIENTE");
        }
    }
}
