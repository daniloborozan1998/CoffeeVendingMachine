using CoffeeVendingMachine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeVendingMachine.Dtos.Ingridients
{
    public class AddUpdateIngridientsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

    }
}
