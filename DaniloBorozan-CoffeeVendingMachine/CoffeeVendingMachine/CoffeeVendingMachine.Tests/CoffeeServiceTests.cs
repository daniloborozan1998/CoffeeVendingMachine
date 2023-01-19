using CoffeeVendingMachine.DataAccess.Interfaces;
using CoffeeVendingMachine.Domain.Models;
using CoffeeVendingMachine.Dtos.Coffee;
using CoffeeVendingMachine.Services.Implementations;
using CoffeeVendingMachine.Services.Interfaces;
using CoffeeVendingMachine.Shared.CustomException;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeVendingMachine.Tests
{
    [TestClass]
    public class CoffeeServiceTests
    {
        [TestMethod]
        public void GetAllCoffee_Should_Return_Valid_Num_Of_Records_And_Return_AllCoffee_WhenCalled()
        {
            List<Coffee> coffee = new List<Coffee>()
            {
                new Coffee
                {
                    Id = 1,
                    CoffeeTypeName = "Espresso",
                    Price = 15
                },
                new Coffee
                {
                    Id = 2,
                    CoffeeTypeName = "Macchiato",
                    Price = 20
                },
                new Coffee
                {
                    Id = 3,
                    CoffeeTypeName = "Americano",
                    Price = 25
                },
                new Coffee
                {
                    Id = 4,
                    CoffeeTypeName = "Latte",
                    Price = 25
                },
                new Coffee
                {
                    Id = 5,
                    CoffeeTypeName = "Cappuccino",
                    Price = 30
                },
                new Coffee
                {
                    Id = 6,
                    CoffeeTypeName = "Irish",
                    Price = 30
                }
        };


            var coffeeMockRepository = new Mock<ICoffeeRepository<Coffee>>();
            coffeeMockRepository.Setup(x => x.GetAll()).Returns(coffee);

            ICoffeeService coffeeService = new CoffeeServices(coffeeMockRepository.Object);

            var result = coffeeService.GetAllCoffee();

            Assert.AreEqual(6, result.Count);
            Assert.AreEqual("Espresso", result[0].CoffeeTypeName);
            Assert.AreEqual("Macchiato", result[1].CoffeeTypeName);
        }
        [TestMethod]
        public void GetCoffeeById_ReturnsCoffeeDto_WhenCoffeeExists()
        {
            int id = 2;
            List<Coffee> coffee = new List<Coffee>()
            {
                new Coffee
                {
                    Id = 1,
                    CoffeeTypeName = "Espresso",
                    Price = 15
                },
                new Coffee
                {
                    Id = 2,
                    CoffeeTypeName = "Macchiato",
                    Price = 20
                },
                new Coffee
                {
                    Id = 3,
                    CoffeeTypeName = "Americano",
                    Price = 25
                },
                new Coffee
                {
                    Id = 4,
                    CoffeeTypeName = "Latte",
                    Price = 25
                },
                new Coffee
                {
                    Id = 5,
                    CoffeeTypeName = "Cappuccino",
                    Price = 30
                },
                new Coffee
                {
                    Id = 6,
                    CoffeeTypeName = "Irish",
                    Price = 30
                }
            };


            var coffeeMockRepository = new Mock<ICoffeeRepository<Coffee>>();
            coffeeMockRepository.Setup(x => x.GetById(id)).Returns(coffee[1]);
            //coffeeMockRepository.Setup(x => x.GetById(id)).Returns(new Coffee { Id = id });

            ICoffeeService coffeeService = new CoffeeServices(coffeeMockRepository.Object);

            var result = coffeeService.GetCoffeeById(id);

            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
        }

        [TestMethod]
        public void GetCoffeeById_ThrowsResourceNotFoundException_WhenCoffeeDoesNotExist()
        {
            int id = 1;
            var coffeeMockRepository = new Mock<ICoffeeRepository<Coffee>>();
            coffeeMockRepository.Setup(r => r.GetById(id)).Returns((Coffee)null);


            var result = new CoffeeServices(coffeeMockRepository.Object);

            var ex = Assert.ThrowsException<ResourceNotFoundException>(() => result.GetCoffeeById(id));
            Assert.AreEqual($"Coffee with id {id} was not found", ex.Message);
        }
        [TestMethod]
        public void AddCoffee_InsertsNewCoffee_WhenCalled()
        {
            var coffeeMockRepository = new Mock<ICoffeeRepository<Coffee>>();
            var result = new CoffeeServices(coffeeMockRepository.Object);
            var addCoffeeDto = new AddUpdateCoffeeDto { CoffeeTypeName = "Irish", Price = 30 };

            result.AddCoffee(addCoffeeDto);

            coffeeMockRepository.Verify(x => x.Insert(It.Is<Coffee>(n => n.CoffeeTypeName == "Irish" && n.Price == 30)), Times.Once());
        }
        [TestMethod]
        public void DeleteCoffeeById_DeletesCoffee_WhenCoffeeExists()
        {
            int id = 1;
            List<Coffee> coffee = new List<Coffee>()
            {
                new Coffee
                {
                    Id = 1,
                    CoffeeTypeName = "Espresso",
                    Price = 15
                },
                new Coffee
                {
                    Id = 2,
                    CoffeeTypeName = "Macchiato",
                    Price = 20
                },
                new Coffee
                {
                    Id = 3,
                    CoffeeTypeName = "Americano",
                    Price = 25
                },
                new Coffee
                {
                    Id = 4,
                    CoffeeTypeName = "Latte",
                    Price = 25
                },
                new Coffee
                {
                    Id = 5,
                    CoffeeTypeName = "Cappuccino",
                    Price = 30
                },
                new Coffee
                {
                    Id = 6,
                    CoffeeTypeName = "Irish",
                    Price = 30
                }
            };
            var coffeeMockRepository = new Mock<ICoffeeRepository<Coffee>>();
            coffeeMockRepository.Setup(x => x.GetById(id)).Returns(coffee[0]);
            //mockCoffeeRepository.Setup(r => r.GetById(id)).Returns(new Coffee { Id = id });
            var result = new CoffeeServices(coffeeMockRepository.Object);

            result.DeleteCoffeeById(id);

            coffeeMockRepository.Verify(x => x.Delete(It.Is<Coffee>(n => n.Id == id)), Times.Once());
        }

        [TestMethod]
        public void DeleteCoffeeById_ThrowsResourceNotFoundException_WhenCoffeeDoesNotExist()
        {
            int id = 1;
            var coffeeMockRepository = new Mock<ICoffeeRepository<Coffee>>();
            coffeeMockRepository.Setup(r => r.GetById(id)).Returns((Coffee)null);
            var result = new CoffeeServices(coffeeMockRepository.Object);

            var ex = Assert.ThrowsException<ResourceNotFoundException>(() => result.DeleteCoffeeById(id));
            Assert.AreEqual($"Coffee with {id} was not found!", ex.Message);
        }
        [TestMethod]
        public void UpdateCoffee_UpdatesCoffee_WhenCoffeeExists()
        {
            // Arrange
            int id = 1;
            List<Coffee> coffee = new List<Coffee>()
            {
                new Coffee
                {
                    Id = 1,
                    CoffeeTypeName = "Espresso",
                    Price = 15
                },
                new Coffee
                {
                    Id = 2,
                    CoffeeTypeName = "Macchiato",
                    Price = 20
                },
                new Coffee
                {
                    Id = 3,
                    CoffeeTypeName = "Americano",
                    Price = 25
                },
                new Coffee
                {
                    Id = 4,
                    CoffeeTypeName = "Latte",
                    Price = 25
                },
                new Coffee
                {
                    Id = 5,
                    CoffeeTypeName = "Cappuccino",
                    Price = 30
                },
                new Coffee
                {
                    Id = 6,
                    CoffeeTypeName = "Irish",
                    Price = 30
                }
            };
            var coffeeMockRepository = new Mock<ICoffeeRepository<Coffee>>();
            coffeeMockRepository.Setup(x => x.GetById(id)).Returns(coffee[0]);
            var result = new CoffeeServices(coffeeMockRepository.Object);
            var updateCoffeeDto = new AddUpdateCoffeeDto { Id = id, CoffeeTypeName = "Espresso", Price = 10 };

            result.UpdateCoffee(updateCoffeeDto);

            coffeeMockRepository.Verify(x => x.Update(It.Is<Coffee>(n => n.Id == id && n.CoffeeTypeName == "Espresso" && n.Price == 10)), Times.Once());
        }

        [TestMethod]
        public void UpdateCoffee_ThrowsResourceNotFoundException_WhenCoffeeDoesNotExist()
        {
            int id = 1;
            var coffeeMockRepository = new Mock<ICoffeeRepository<Coffee>>();
            coffeeMockRepository.Setup(x => x.GetById(id)).Returns((Coffee)null);
            var service = new CoffeeServices(coffeeMockRepository.Object);
            var updateCoffeeDto = new AddUpdateCoffeeDto { Id = id, CoffeeTypeName = "Espresso", Price = 10 };

            var ex = Assert.ThrowsException<ResourceNotFoundException>(() => service.UpdateCoffee(updateCoffeeDto));
            Assert.AreEqual($"Coffee with id {id} was not found", ex.Message);
        }

    }
}

