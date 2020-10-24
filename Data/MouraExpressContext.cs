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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material>().ToTable("Material");

            base.OnModelCreating(modelBuilder);
        }

    }

}
