using CoffeeVendingMachine.Dtos.Ingridients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeVendingMachine.Services.Interfaces
{
    public interface IIngridientsServices
    {
        List<IngridientsDto> GetAllIngridients();
        IngridientsDto GetIngridientsById(int id);
        void AddIngridients(AddUpdateIngridientsDto addIngridientsDto);
        void UpdateIngridients(AddUpdateIngridientsDto updateIngridients);
        void DeleteIngridientsById(int id);
    }
}
