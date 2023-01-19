using CoffeeVendingMachine.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeVendingMachine.DataAccess
{
    public class CoffeeVendingMachineDbContext : DbContext
    {
        public CoffeeVendingMachineDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Coffee> Coffee { get; set; }
        public DbSet<Ingridients> Ingridients { get; set; }
        public DbSet<NewModernCoffee> NewModernCoffee { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Coffee>()
                .HasData(new Coffee
                {
                    Id = 1,
                    CoffeeTypeName = "Espresso",
                    Price = 15,
                    Images = "./Images/espresso.jpg"
                },
                new Coffee
                {
                    Id = 2,
                    CoffeeTypeName = "Macchiato",
                    Price = 20,
                    Images = "./Images/macchiato.jpg"
                },
                new Coffee
                {
                    Id = 3,
                    CoffeeTypeName = "Americano",
                    Price = 25,
                    Images = "./Images/americano.jpg"

                },
                new Coffee
                {
                    Id = 4,
                    CoffeeTypeName = "Latte",
                    Price = 25,
                    Images = "./Images/latte.jpg"

                },
                new Coffee
                {
                    Id = 5,
                    CoffeeTypeName = "Cappuccino",
                    Price = 30,
                    Images = "./Images/cappuccino.jpg"

                },
                new Coffee
                {
                    Id = 6,
                    CoffeeTypeName = "Irish",
                    Price = 30,
                    Images = "./Images/irish.jpg"

                });

            modelBuilder.Entity<Ingridients>()
                .HasData(new Ingridients
                {
                    Id = 1,
                    Name = "Extra Sugar",
                    Price = 0
                },
                new Ingridients
                {
                    Id = 2,
                    Name = "Creamer",
                    Price = 5
                },
                new Ingridients
                {
                    Id = 3,
                    Name = "Caramelle",
                    Price = 5
                },
                new Ingridients
                {
                    Id = 4,
                    Name = "Extra milk",
                    Price = 5
                });

            modelBuilder.Entity<NewModernCoffee>()
                .HasData(new NewModernCoffee
                {
                    Id = 1,
                    CoffeeTypeName = "Frappe",
                    Price = 40,
                    Images = "./Images/frappe.png"
                },
                new NewModernCoffee
                {
                    Id = 2,
                    CoffeeTypeName = "Glace",
                    Price = 35,
                    Images = "./Images/glace.png"
                },
                new NewModernCoffee
                {
                    Id = 3,
                    CoffeeTypeName = "Mocha",
                    Price = 25,
                    Images = "./Images/mocha.png"

                });
        }
    }

}
