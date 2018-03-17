namespace GEPV.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionandoFKVendedor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CONTATOS", "ID_VENDEDOR", c => c.Int(nullable: false));
            CreateIndex("dbo.CONTATOS", "ID_VENDEDOR");
            AddForeignKey("dbo.CONTATOS", "ID_VENDEDOR", "dbo.VENDEDOR", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CONTATOS", "ID_VENDEDOR", "dbo.VENDEDOR");
            DropIndex("dbo.CONTATOS", new[] { "ID_VENDEDOR" });
            DropColumn("dbo.CONTATOS", "ID_VENDEDOR");
        }
    }
}
