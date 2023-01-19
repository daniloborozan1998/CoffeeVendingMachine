using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeVendingMachine.Domain.Models
{
    public class Coffee : BaseEntity
    {
        public string CoffeeTypeName { get; set; }
        public float Price { get; set; }
        public string Images { get; set; }
    }
}
