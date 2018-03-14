namespace GEPV.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelaFornecedorPorCliente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FORNECEDOR_POR_CLIENTE",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ID_FORNECEDOR = c.Int(nullable: false),
                        ID_CLIENTE = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CLIENTE", t => t.ID_CLIENTE, cascadeDelete: true)
                .ForeignKey("dbo.FORNECEDOR", t => t.ID_FORNECEDOR, cascadeDelete: true)
                .Index(t => t.ID_FORNECEDOR)
                .Index(t => t.ID_CLIENTE);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FORNECEDOR_POR_CLIENTE", "ID_FORNECEDOR", "dbo.FORNECEDOR");
            DropForeignKey("dbo.FORNECEDOR_POR_CLIENTE", "ID_CLIENTE", "dbo.CLIENTE");
            DropIndex("dbo.FORNECEDOR_POR_CLIENTE", new[] { "ID_CLIENTE" });
            DropIndex("dbo.FORNECEDOR_POR_CLIENTE", new[] { "ID_FORNECEDOR" });
            DropTable("dbo.FORNECEDOR_POR_CLIENTE");
        }
    }
}
