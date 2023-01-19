using CoffeeVendingMachine.Domain.Models;
using CoffeeVendingMachine.Dtos.Ingridients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeVendingMachine.Mappers
{
    public static class IngridientsMapper
    {
        public static IngridientsDto ToIngridientsDto(this Ingridients ingridients)
        {
            return new IngridientsDto()
            {
                Id = ingridients.Id,
                Name = ingridients.Name,
                Price = ingridients.Price
               
            };
        }
        public static Ingridients ToIngridients(this AddUpdateIngridientsDto addIngridients)
        {
            return new Ingridients
            {
                Id = addIngridients.Id,
                Name = addIngridients.Name,
                Price = addIngridients.Price,
            };
        }
    }
}
