namespace GEPV.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjusteContatos : DbMigration
    {
        public override void Up()
        {               
            DropColumn("CONTATOS", "ID_COMPRADOR");
        }
        
        public override void Down()
        {
            AddColumn("CONTATOS", "ID_COMPRADOR", c => c.Int(nullable: false));
            
        }
    }
}
