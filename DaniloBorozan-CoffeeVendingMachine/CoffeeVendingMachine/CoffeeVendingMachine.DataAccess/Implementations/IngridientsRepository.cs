using CoffeeVendingMachine.DataAccess.Interfaces;
using CoffeeVendingMachine.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeVendingMachine.DataAccess.Implementations
{
    public class IngridientsRepository : ICoffeeRepository<Ingridients>
    {
        private CoffeeVendingMachineDbContext _coffeeVendingMachineDbContext;
        public IngridientsRepository(CoffeeVendingMachineDbContext coffeeVendingMachineDbContext)
        {
            _coffeeVendingMachineDbContext = coffeeVendingMachineDbContext;
        }
        
        public void Delete(Ingridients entity)
        {
            _coffeeVendingMachineDbContext.Ingridients.Remove(entity);
            _coffeeVendingMachineDbContext.SaveChanges();
        }

        public List<Ingridients> GetAll()
        {
            return _coffeeVendingMachineDbContext
                .Ingridients
                .ToList();
        }

        public Ingridients GetById(int id)
        {
            return _coffeeVendingMachineDbContext
                 .Ingridients
                 .FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Ingridients entity)
        {
            _coffeeVendingMachineDbContext.Ingridients.Add(entity);
            _coffeeVendingMachineDbContext.SaveChanges(); 
        }

        //This is the same with GetAll() but I made it so that there is also a special
        public List<Ingridients> ListOfCoffee()
        {
            return _coffeeVendingMachineDbContext
                .Ingridients
                .ToList();
        }

        public void Update(Ingridients entity)
        {
            _coffeeVendingMachineDbContext.Ingridients.Update(entity);
            _coffeeVendingMachineDbContext.SaveChanges(); 
        }
    }
}
