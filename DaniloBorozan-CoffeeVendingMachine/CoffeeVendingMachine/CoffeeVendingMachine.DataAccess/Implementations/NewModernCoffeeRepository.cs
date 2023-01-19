using CoffeeVendingMachine.DataAccess.Interfaces;
using CoffeeVendingMachine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeVendingMachine.DataAccess.Implementations
{
    public class NewModernCoffeeRepository : ICoffeeRepository<NewModernCoffee>
    {
        private CoffeeVendingMachineDbContext _coffeeVendingMachineDbContext;
        public NewModernCoffeeRepository(CoffeeVendingMachineDbContext coffeeVendingMachineDbContext)
        {
            _coffeeVendingMachineDbContext = coffeeVendingMachineDbContext;
        }
        public void Delete(NewModernCoffee entity)
        {
            _coffeeVendingMachineDbContext.NewModernCoffee.Remove(entity);
            _coffeeVendingMachineDbContext.SaveChanges();
        }

        public List<NewModernCoffee> GetAll()
        {
            return _coffeeVendingMachineDbContext
                .NewModernCoffee
                .ToList();
        }

        public NewModernCoffee GetById(int id)
        {
            return _coffeeVendingMachineDbContext
                 .NewModernCoffee
                 .FirstOrDefault(x => x.Id == id);
        }

        public void Insert(NewModernCoffee entity)
        {
            _coffeeVendingMachineDbContext.NewModernCoffee.Add(entity);
            _coffeeVendingMachineDbContext.SaveChanges(); 
        }

        public List<NewModernCoffee> ListOfCoffee()
        {
            return _coffeeVendingMachineDbContext
               .NewModernCoffee
               .ToList();
        }

        public void Update(NewModernCoffee entity)
        {
            _coffeeVendingMachineDbContext.NewModernCoffee.Update(entity);
            _coffeeVendingMachineDbContext.SaveChanges(); 
                                             }
        }
}
