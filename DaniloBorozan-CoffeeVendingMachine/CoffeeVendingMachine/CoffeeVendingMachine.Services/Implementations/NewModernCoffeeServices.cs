using CoffeeVendingMachine.DataAccess.Interfaces;
using CoffeeVendingMachine.Domain.Models;
using CoffeeVendingMachine.Dtos.NewModernCoffee;
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
    public class NewModernCoffeeServices : INewModernCoffeeServices
    {
        private ICoffeeRepository<NewModernCoffee> _coffeeRepository;


        public NewModernCoffeeServices(ICoffeeRepository<NewModernCoffee> coffeeRepository)
        {
            _coffeeRepository = coffeeRepository;
        }
        public void AddCoffee(AddUpdateNewModernCoffeeDto addCoffeeDto)
        {
            NewModernCoffee newCoffee = addCoffeeDto.ToModernCoffee();
            _coffeeRepository.Insert(newCoffee);
        }

        public void DeleteCoffeeById(int id)
        {
            NewModernCoffee coffeeDb = _coffeeRepository.GetById(id);
            if (coffeeDb == null)
            {
                throw new ResourceNotFoundException($"Coffee with {id} was not found!");
            }
            _coffeeRepository.Delete(coffeeDb);
        }

        public List<NewModernCoffeeDto> GetAllCoffee()
        {
            //read from db
            List<NewModernCoffee> coffeeDb = _coffeeRepository.GetAll();
            //map to dtos
            return coffeeDb.Select(x => x.ToModernCoffeeDto()).ToList();
        }

        public NewModernCoffeeDto GetCoffeeById(int id)
        {
            NewModernCoffee coffeeDb = _coffeeRepository.GetById(id);
            if (coffeeDb == null)
            {
                //log
                throw new ResourceNotFoundException($"Coffee with id {id} was not found");
            }
            return coffeeDb.ToModernCoffeeDto();
        }

        public void UpdateCoffee(AddUpdateNewModernCoffeeDto updateCoffee)
        {
            NewModernCoffee coffeeDb = _coffeeRepository.GetById(updateCoffee.Id);
            if (coffeeDb == null)
            {
                throw new ResourceNotFoundException($"Coffee with id {updateCoffee.Id} was not found");
            }

            coffeeDb.CoffeeTypeName = updateCoffee.CoffeeTypeName;
            coffeeDb.Price = updateCoffee.Price;
            coffeeDb.Images = updateCoffee.Images;


            _coffeeRepository.Update(coffeeDb);
        }
    }
}
