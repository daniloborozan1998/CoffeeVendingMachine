using CoffeeVendingMachine.Dtos.Coffee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeVendingMachine.Services.Interfaces
{
    public interface ICoffeeService
    {
        List<CoffeeDto> GetAllCoffee();
        CoffeeDto GetCoffeeById(int id);
        void AddCoffee(AddUpdateCoffeeDto addCoffeeDto);
        void UpdateCoffee(AddUpdateCoffeeDto updateCoffee);
        void DeleteCoffeeById(int id);
    }
}
