using CoffeeVendingMachine.DataAccess.Interfaces;
using CoffeeVendingMachine.Domain.Models;
using CoffeeVendingMachine.Dtos.Ingridients;
using CoffeeVendingMachine.Mappers;
using CoffeeVendingMachine.Services.Interfaces;
using CoffeeVendingMachine.Shared.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeVendingMachine.Services.Implementations
{
    public class IngridientsService : IIngridientsServices
    {
        private ICoffeeRepository<Ingridients> _ingridientRepository;

        public IngridientsService(ICoffeeRepository<Ingridients> ingridientRepository)
        {
            _ingridientRepository = ingridientRepository;
        }

        public void AddIngridients(AddUpdateIngridientsDto addIngridientsDto)
        {
            Ingridients newIngridients = addIngridientsDto.ToIngridients();
             _ingridientRepository.Insert(newIngridients);
        }

        public void DeleteIngridientsById(int id)
        {
            Ingridients ingridientsDb =  _ingridientRepository.GetById(id);
            if (ingridientsDb == null)
            {
                throw new ResourceNotFoundException($"Ingridients with {id} was not found!");
            }
             _ingridientRepository.Delete(ingridientsDb);
        }

        public List<IngridientsDto> GetAllIngridients()
        {
            //read from db
            List<Ingridients> ingridientsDb =  _ingridientRepository.GetAll();
            //map to dtos
            return ingridientsDb.Select(x => x.ToIngridientsDto()).ToList();
        }

        public IngridientsDto GetIngridientsById(int id)
        {
            Ingridients ingridientsDb = _ingridientRepository.GetById(id);
            if (ingridientsDb == null)
            {
                //log
                throw new ResourceNotFoundException($"Ingridients with id {id} was not found");
            }
            return ingridientsDb.ToIngridientsDto();
        }

        public void UpdateIngridients(AddUpdateIngridientsDto updateIngridients)
        {
            Ingridients ingridientsDb =  _ingridientRepository.GetById(updateIngridients.Id);
            if (ingridientsDb == null)
            {
                throw new ResourceNotFoundException($"Ingridients with id {updateIngridients.Id} was not found");
            }

            ingridientsDb.Name = updateIngridients.Name;
            ingridientsDb.Price = updateIngridients.Price;

            _ingridientRepository.Update(ingridientsDb);
        }
    }
}
