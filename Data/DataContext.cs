using Estoque_App.Data.Configs;
using Estoque_App.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Estoque_App.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<Produto>? Produtos { get; set; }
        public DbSet<Midia>?Midias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoConfig());
            modelBuilder.ApplyConfiguration(new MidiaConfig());
        }
    }
}
