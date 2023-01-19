using CoffeeVendingMachine.DataAccess.Interfaces;
using CoffeeVendingMachine.Domain.Models;
using CoffeeVendingMachine.Dtos.Coffee;
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
    public class CoffeeServices : ICoffeeService
    {
        private ICoffeeRepository<Coffee> _coffeeRepository;


        public CoffeeServices(ICoffeeRepository<Coffee> coffeeRepository)
        {
            _coffeeRepository = coffeeRepository;
        }
        public void AddCoffee(AddUpdateCoffeeDto addCoffeeDto)
        {
            Coffee newCoffee = addCoffeeDto.ToCoffee();
             _coffeeRepository.Insert(newCoffee);
        }

        public void DeleteCoffeeById(int id)
        {
            Coffee coffeeDb =  _coffeeRepository.GetById(id);
            if (coffeeDb == null)
            {
                throw new ResourceNotFoundException($"Coffee with {id} was not found!");
            }
            _coffeeRepository.Delete(coffeeDb);
        }

        public List<CoffeeDto> GetAllCoffee()
        {

            //read from db
            List<Coffee> coffeeDb =  _coffeeRepository.GetAll();
            //map to dtos
            return coffeeDb.Select(x => x.ToCoffeeDto()).ToList();
        }

        public CoffeeDto GetCoffeeById(int id)
        {
            Coffee coffeeDb =  _coffeeRepository.GetById(id);
            if (coffeeDb == null)
            {
                //log
                throw new ResourceNotFoundException($"Coffee with id {id} was not found");
            }
            return coffeeDb.ToCoffeeDto();
        }


        public  void UpdateCoffee(AddUpdateCoffeeDto updateCoffee)
        {
            Coffee coffeeDb =  _coffeeRepository.GetById(updateCoffee.Id);
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
