using CoffeeVendingMachine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeVendingMachine.Dtos.Coffee
{
    public class CoffeeDto 
    {
        public int Id { get; set; }
        public string CoffeeTypeName { get; set; }
        public float Price { get; set; }
        public string Images { get; set; }

    }
}
