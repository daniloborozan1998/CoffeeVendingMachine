using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeVendingMachine.Domain.Models
{
    public class Ingridients : BaseEntity
    {
        public string Name { get; set; }
        public float Price { get; set; }

    }
}
