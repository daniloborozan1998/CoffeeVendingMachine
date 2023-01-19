using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeVendingMachine.Shared.CustomException
{
    public class IngridientsException : Exception
    {
        public IngridientsException(string message) : base(message)
        {

        }
    }
}
