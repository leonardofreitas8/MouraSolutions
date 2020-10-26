using Microsoft.EntityFrameworkCore;
using MouraSolutionsWeb.Models; 

namespace MouraSolutionsWeb.Data
{
    public class MouraExpressContext : DbContext
    {
        //public MouraExpressContext()
        //// C# will call base class parameterless constructor by default
        //{

        //}
        public MouraExpressContext(DbContextOptions<MouraExpressContext> options) : base(options)
        {

        }

        public DbSet<Material> Material { get; set; }
        public DbSet<SystemUser> SystemUser { get; set; }
        public DbSet<Motoboy> Motoboy { get; set; }
        public DbSet<StatusPedido> StatusPedido { get; set; }
        public DbSet<StatusProtocolo> StatusProtocolo { get; set; }
        public DbSet<Zona> Zona { get; set; }        
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material>().ToTable("Material");
            modelBuilder.Entity<SystemUser>().ToTable("SystemUser");
            modelBuilder.Entity<Motoboy>().ToTable("Motoboy");
            modelBuilder.Entity<StatusPedido>().ToTable("StatusPedido");
            modelBuilder.Entity<StatusProtocolo>().ToTable("StatusProtocolo");
            modelBuilder.Entity<Zona>().ToTable("Zona");
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Endereco>().ToTable("Endereco");
            modelBuilder.Entity<Paciente>().ToTable("Paciente");
            modelBuilder.Entity<Pedido>().ToTable("Pedido");

            base.OnModelCreating(modelBuilder);
        }

    }

}
