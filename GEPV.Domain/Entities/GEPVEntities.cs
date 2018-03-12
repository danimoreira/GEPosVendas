namespace GEPV.Domain.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations.History;
    using System.Linq;

    public class GEPVEntities : DbContext
    {        
        public GEPVEntities()
            : base("name=GEPVEntities")
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Vendedor> Comprador { get; set; }
        public virtual DbSet<Contatos> Contatos { get; set; }        
        public virtual DbSet<Fornecedor> Fornecedor { get; set; }        
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Regiao> Regiao { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>();
            modelBuilder.Entity<Vendedor>();
            modelBuilder.Entity<Contatos>();            
            modelBuilder.Entity<Fornecedor>();
            modelBuilder.Entity<Estado>();
            modelBuilder.Entity<Regiao>();
            
            base.OnModelCreating(modelBuilder);
        }

    }
        
}