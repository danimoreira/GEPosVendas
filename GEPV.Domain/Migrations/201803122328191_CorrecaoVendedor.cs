namespace GEPV.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrecaoVendedor : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "COMPRADOR", newName: "VENDEDOR");
            AddColumn("CLIENTE", "NOME_COMPRADOR", c => c.String(unicode: false));
            AddColumn("CLIENTE", "ID_VENDEDOR", c => c.Int());
            CreateIndex("CLIENTE", "ID_VENDEDOR");
            AddForeignKey("CLIENTE", "ID_VENDEDOR", "VENDEDOR", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CLIENTE", "ID_VENDEDOR", "dbo.VENDEDOR");
            DropIndex("dbo.CLIENTE", new[] { "ID_VENDEDOR" });
            DropColumn("dbo.CLIENTE", "ID_VENDEDOR");
            DropColumn("dbo.CLIENTE", "NOME_COMPRADOR");
            RenameTable(name: "dbo.VENDEDOR", newName: "COMPRADOR");
        }
    }
}
