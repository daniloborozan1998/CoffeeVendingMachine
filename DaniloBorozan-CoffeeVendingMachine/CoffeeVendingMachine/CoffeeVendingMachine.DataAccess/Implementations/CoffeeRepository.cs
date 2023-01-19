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
    public class CoffeeRepository : ICoffeeRepository<Coffee>
    {
        private CoffeeVendingMachineDbContext _coffeeVendingMachineDbContext;
        public CoffeeRepository(CoffeeVendingMachineDbContext coffeeVendingMachineDbContext)
        {
            _coffeeVendingMachineDbContext = coffeeVendingMachineDbContext;
        }

        public void Delete(Coffee entity)
        {
            _coffeeVendingMachineDbContext.Coffee.Remove(entity);
            _coffeeVendingMachineDbContext.SaveChanges();
        }

        public List<Coffee> GetAll()
        {
            return  _coffeeVendingMachineDbContext
                .Coffee
                .ToList();
        }

        public Coffee GetById(int id)
        {
            return  _coffeeVendingMachineDbContext
                 .Coffee
                 .FirstOrDefault(x => x.Id == id);
        }

        public void Insert(Coffee entity)
        {
             _coffeeVendingMachineDbContext.Coffee.Add(entity);
             _coffeeVendingMachineDbContext.SaveChanges(); //request to DB
        }

        public  List<Coffee> ListOfCoffee()
        {
            return  _coffeeVendingMachineDbContext
               .Coffee
               .ToList();
        }

        public void Update(Coffee entity)
        {
             _coffeeVendingMachineDbContext.Coffee.Update(entity);
             _coffeeVendingMachineDbContext.SaveChanges(); //call to db
        }

    }
}
