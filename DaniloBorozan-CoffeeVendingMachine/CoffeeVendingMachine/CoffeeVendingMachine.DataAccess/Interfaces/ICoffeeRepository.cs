using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeVendingMachine.DataAccess.Interfaces
{
    public interface ICoffeeRepository<T> : IRepository<T> where T : class
    {
        List<T> ListOfCoffee();
    }
}
