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

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Comprador> Comprador { get; set; }
        public DbSet<Contatos> Contatos { get; set; }
        public DbSet<EnderecoCliente> EnderecoCliente { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>();
            modelBuilder.Entity<Comprador>();
            modelBuilder.Entity<Contatos>();
            modelBuilder.Entity<EnderecoCliente>();
            modelBuilder.Entity<Fornecedor>();
            modelBuilder.Entity<Usuario>();
            
            base.OnModelCreating(modelBuilder);
        }

    }
        
}