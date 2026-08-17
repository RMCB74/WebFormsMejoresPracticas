using System.Data.Entity;
using WebFormsSoapService.Models;

namespace WebFormsSoapService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Contacto> Contactos { get; set; }

        public DbSet<TipoContacto> TiposContacto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .ToTable("Clientes");

            modelBuilder.Entity<Contacto>()
                .ToTable("Contactos");

            modelBuilder.Entity<TipoContacto>()
                .ToTable("TiposContacto");

            modelBuilder.Entity<Contacto>()
                .HasRequired(c => c.Cliente)
                .WithMany()
                .HasForeignKey(c => c.ClienteId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contacto>()
                .HasRequired(c => c.TipoContacto)
                .WithMany()
                .HasForeignKey(c => c.TipoContactoId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}