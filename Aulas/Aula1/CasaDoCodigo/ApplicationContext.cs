using CasaDoCodigo.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>().HasKey(k => k.Id);

            modelBuilder.Entity<Pedido>().HasKey(k => k.Id);
            modelBuilder.Entity<Pedido>().HasMany(p => p.Itens).WithOne(p => p.Pedido);
            modelBuilder.Entity<Pedido>().HasOne(p => p.Cadastro).WithOne(p => p.Pedido).IsRequired();

            modelBuilder.Entity<ItemPedido>().HasKey(k => k.Id);
            modelBuilder.Entity<ItemPedido>().HasOne(p => p.Pedido);
            modelBuilder.Entity<ItemPedido>().HasOne(p => p.Produto);

            modelBuilder.Entity<Cadastro>().HasKey(k => k.Id);
            modelBuilder.Entity<Cadastro>().HasOne(c => c.Pedido);
        }
    }
}
