using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazingPizza.Shared;

namespace BlazingPizza.Server.Models
{
    public class PizzaStoreContext : DbContext
    {
        public DbSet<PizzaSpecial> Specials { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PizzaStore");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // llave primaria 
            modelBuilder.Entity<PizzaTopping>().HasKey(pst => new { pst.PizzaId, pst.ToppingId });

            // Una pizza tiene muchos Toppings.
            modelBuilder.Entity<PizzaTopping>().
                HasOne<Pizza>().WithMany(ps => ps.Toppings);

            // Un Toppings puede estar en muchas pizzas.
            modelBuilder.Entity<PizzaTopping>().HasOne(pst => pst.Topping).WithMany();

            modelBuilder.Entity<Order>().OwnsOne(o => o.DeliveryLocation);
        }
    }
}

