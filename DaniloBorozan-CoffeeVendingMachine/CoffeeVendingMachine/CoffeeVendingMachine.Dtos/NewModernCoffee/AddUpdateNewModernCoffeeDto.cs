using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeVendingMachine.Dtos.NewModernCoffee
{
    public class AddUpdateNewModernCoffeeDto
    {
        public int Id { get; set; }
        public string CoffeeTypeName { get; set; }
        public float Price { get; set; }
        public string Images { get; set; }
    }
}
