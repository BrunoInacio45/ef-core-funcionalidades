using System;
using EFCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get;set; }
        public DbSet<ItemPedido> ItensPedidos { get;set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var stringConnection = "Server=localhost;User Id=SA;Password=4DLtDj9d;Database=efcore;pooling=false";
            optionsBuilder
                .UseSqlServer(stringConnection)
                .EnableSensitiveDataLogging()
                // .UseLazyLoadingProxies()
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>().HasQueryFilter(x => x.Ativo);
        }
    }
}