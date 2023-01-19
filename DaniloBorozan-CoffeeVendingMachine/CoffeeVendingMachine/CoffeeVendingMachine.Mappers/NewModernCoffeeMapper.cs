using CoffeeVendingMachine.Domain.Models;
using CoffeeVendingMachine.Dtos.NewModernCoffee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeVendingMachine.Mappers
{
    public static class NewModernCoffeeMapper
    {
        public static NewModernCoffeeDto ToModernCoffeeDto(this NewModernCoffee coffee)
        {
            return new NewModernCoffeeDto()
            {
                Id = coffee.Id,
                CoffeeTypeName = coffee.CoffeeTypeName,
                Price = coffee.Price,
                Images = coffee.Images,

            };
        }
        public static NewModernCoffee ToModernCoffee(this AddUpdateNewModernCoffeeDto addCoffeeDto)
        {
            return new NewModernCoffee
            {
                Id = addCoffeeDto.Id,
                CoffeeTypeName = addCoffeeDto.CoffeeTypeName,
                Price = addCoffeeDto.Price,
                Images = addCoffeeDto.Images,

            };
        }
    }
}
