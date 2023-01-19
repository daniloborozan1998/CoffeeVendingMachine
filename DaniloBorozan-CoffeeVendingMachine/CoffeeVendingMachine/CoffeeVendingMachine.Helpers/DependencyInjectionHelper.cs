using CoffeeVendingMachine.DataAccess;
using CoffeeVendingMachine.DataAccess.Implementations;
using CoffeeVendingMachine.DataAccess.Interfaces;
using CoffeeVendingMachine.Domain.Models;
using CoffeeVendingMachine.Services;
using CoffeeVendingMachine.Services.Implementations;
using CoffeeVendingMachine.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeVendingMachine.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CoffeeVendingMachineDbContext>(x =>
                x.UseSqlServer(connectionString));
        }

        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<ICoffeeRepository<Ingridients>, IngridientsRepository>(); //DI
            services.AddTransient<ICoffeeRepository<Coffee>, CoffeeRepository>(); //DI
            services.AddTransient<ICoffeeRepository<NewModernCoffee>, NewModernCoffeeRepository>(); //DI
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<ICoffeeService, CoffeeServices>(); //DI
            services.AddTransient<IIngridientsServices, IngridientsService>(); //DI
            services.AddTransient<INewModernCoffeeServices, NewModernCoffeeServices>(); //DI
        }
    }
}
