using CoffeeVendingMachine.Dtos.NewModernCoffee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeVendingMachine.Services.Interfaces
{
    public interface INewModernCoffeeServices
    {
        List<NewModernCoffeeDto> GetAllCoffee();
        NewModernCoffeeDto GetCoffeeById(int id);
        void AddCoffee(AddUpdateNewModernCoffeeDto addCoffeeDto);
        void UpdateCoffee(AddUpdateNewModernCoffeeDto updateCoffee);
        void DeleteCoffeeById(int id);
    }
}
