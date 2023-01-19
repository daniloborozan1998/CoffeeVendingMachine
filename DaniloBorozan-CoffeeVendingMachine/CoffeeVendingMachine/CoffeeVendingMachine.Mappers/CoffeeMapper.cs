using CoffeeVendingMachine.Domain.Models;
using CoffeeVendingMachine.Dtos.Coffee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeVendingMachine.Mappers
{
    public static class CoffeeMapper
    {
        public static CoffeeDto ToCoffeeDto(this Coffee coffee)
        {
            return new CoffeeDto()
            {
                Id = coffee.Id,
                CoffeeTypeName = coffee.CoffeeTypeName, 
                Price = coffee.Price,
                Images = coffee.Images,
         
            };
        }
        public static Coffee ToCoffee(this AddUpdateCoffeeDto addCoffeeDto)
        {
            return new Coffee
            {
                Id = addCoffeeDto.Id,
                CoffeeTypeName = addCoffeeDto.CoffeeTypeName,
                Price = addCoffeeDto.Price,
                Images = addCoffeeDto.Images,

            };
        }
    }
}
