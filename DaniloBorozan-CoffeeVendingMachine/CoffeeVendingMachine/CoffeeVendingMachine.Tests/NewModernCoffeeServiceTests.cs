using CoffeeVendingMachine.DataAccess.Interfaces;
using CoffeeVendingMachine.Domain.Models;
using CoffeeVendingMachine.Dtos.NewModernCoffee;
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
    public class NewModernCoffeeServiceTests
    {
        [TestMethod]
        public void GetAllCoffee_Should_Return_Valid_Num_Of_Records_And_Return_AllCoffee_WhenCalled()
        {
            List<NewModernCoffee> coffee = new List<NewModernCoffee>()
            {
                new NewModernCoffee
                {
                    Id = 1,
                    CoffeeTypeName = "Frappe",
                    Price = 40,
                    Images = "./Images/frappe.png"
                },
                new NewModernCoffee
                {
                    Id = 2,
                    CoffeeTypeName = "Glace",
                    Price = 35,
                    Images = "./Images/lglace.png"
                },
                new NewModernCoffee
                {
                    Id = 3,
                    CoffeeTypeName = "Mocha",
                    Price = 25,
                    Images = "./Images/mocha.png"

                }
        };


            var coffeeMockRepository = new Mock<ICoffeeRepository<NewModernCoffee>>();
            coffeeMockRepository.Setup(x => x.GetAll()).Returns(coffee);

            INewModernCoffeeServices coffeeService = new NewModernCoffeeServices(coffeeMockRepository.Object);

            var result = coffeeService.GetAllCoffee();

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("Frappe", result[0].CoffeeTypeName);
            Assert.AreEqual("Glace", result[1].CoffeeTypeName);
        }
        [TestMethod]
        public void GetCoffeeById_ReturnsCoffeeDto_WhenCoffeeExists()
        {
            int id = 2;
            List<NewModernCoffee> coffee = new List<NewModernCoffee>()
            {
                new NewModernCoffee
                {
                    Id = 1,
                    CoffeeTypeName = "Frappe",
                    Price = 40,
                    Images = "./Images/frappe.png"
                },
                new NewModernCoffee
                {
                    Id = 2,
                    CoffeeTypeName = "Glace",
                    Price = 35,
                    Images = "./Images/lglace.png"
                },
                new NewModernCoffee
                {
                    Id = 3,
                    CoffeeTypeName = "Mocha",
                    Price = 25,
                    Images = "./Images/mocha.png"

                }
            };


            var coffeeMockRepository = new Mock<ICoffeeRepository<NewModernCoffee>>();
            coffeeMockRepository.Setup(x => x.GetById(id)).Returns(coffee[1]);
            //coffeeMockRepository.Setup(x => x.GetById(id)).Returns(new Coffee { Id = id });

            INewModernCoffeeServices coffeeService = new NewModernCoffeeServices(coffeeMockRepository.Object);

            var result = coffeeService.GetCoffeeById(id);

            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
        }

        [TestMethod]
        public void GetCoffeeById_ThrowsResourceNotFoundException_WhenCoffeeDoesNotExist()
        {
            int id = 1;
            var coffeeMockRepository = new Mock<ICoffeeRepository<NewModernCoffee>>();
            coffeeMockRepository.Setup(r => r.GetById(id)).Returns((NewModernCoffee)null);


            var result = new NewModernCoffeeServices(coffeeMockRepository.Object);

            var ex = Assert.ThrowsException<ResourceNotFoundException>(() => result.GetCoffeeById(id));
            Assert.AreEqual($"Coffee with id {id} was not found", ex.Message);
        }
        [TestMethod]
        public void AddCoffee_InsertsNewCoffee_WhenCalled()
        {
            var coffeeMockRepository = new Mock<ICoffeeRepository<NewModernCoffee>>();
            var result = new NewModernCoffeeServices(coffeeMockRepository.Object);
            var addCoffeeDto = new AddUpdateNewModernCoffeeDto { CoffeeTypeName = "Irish", Price = 30 };

            result.AddCoffee(addCoffeeDto);

            coffeeMockRepository.Verify(x => x.Insert(It.Is<NewModernCoffee>(n => n.CoffeeTypeName == "Irish" && n.Price == 30)), Times.Once());
        }
        [TestMethod]
        public void DeleteCoffeeById_DeletesCoffee_WhenCoffeeExists()
        {
            int id = 1;
            List<NewModernCoffee> coffee = new List<NewModernCoffee>()
            {
                new NewModernCoffee
                {
                    Id = 1,
                    CoffeeTypeName = "Frappe",
                    Price = 40,
                    Images = "./Images/frappe.png"
                },
                new NewModernCoffee
                {
                    Id = 2,
                    CoffeeTypeName = "Glace",
                    Price = 35,
                    Images = "./Images/lglace.png"
                },
                new NewModernCoffee
                {
                    Id = 3,
                    CoffeeTypeName = "Mocha",
                    Price = 25,
                    Images = "./Images/mocha.png"

                }
            };
            var coffeeMockRepository = new Mock<ICoffeeRepository<NewModernCoffee>>();
            coffeeMockRepository.Setup(x => x.GetById(id)).Returns(coffee[0]);
            //mockCoffeeRepository.Setup(r => r.GetById(id)).Returns(new Coffee { Id = id });
            var result = new NewModernCoffeeServices(coffeeMockRepository.Object);

            result.DeleteCoffeeById(id);

            coffeeMockRepository.Verify(x => x.Delete(It.Is<NewModernCoffee>(n => n.Id == id)), Times.Once());
        }

        [TestMethod]
        public void DeleteCoffeeById_ThrowsResourceNotFoundException_WhenCoffeeDoesNotExist()
        {
            int id = 1;
            var coffeeMockRepository = new Mock<ICoffeeRepository<NewModernCoffee>>();
            coffeeMockRepository.Setup(r => r.GetById(id)).Returns((NewModernCoffee)null);
            var result = new NewModernCoffeeServices(coffeeMockRepository.Object);

            var ex = Assert.ThrowsException<ResourceNotFoundException>(() => result.DeleteCoffeeById(id));
            Assert.AreEqual($"Coffee with {id} was not found!", ex.Message);
        }
        [TestMethod]
        public void UpdateCoffee_UpdatesCoffee_WhenCoffeeExists()
        {
            // Arrange
            int id = 1;
            List<NewModernCoffee> coffee = new List<NewModernCoffee>()
            {
                new NewModernCoffee
                {
                    Id = 1,
                    CoffeeTypeName = "Frappe",
                    Price = 40,
                    Images = "./Images/frappe.png"
                },
                new NewModernCoffee
                {
                    Id = 2,
                    CoffeeTypeName = "Glace",
                    Price = 35,
                    Images = "./Images/lglace.png"
                },
                new NewModernCoffee
                {
                    Id = 3,
                    CoffeeTypeName = "Mocha",
                    Price = 25,
                    Images = "./Images/mocha.png"

                }
            };
            var coffeeMockRepository = new Mock<ICoffeeRepository<NewModernCoffee>>();
            coffeeMockRepository.Setup(x => x.GetById(id)).Returns(coffee[0]);
            var result = new NewModernCoffeeServices(coffeeMockRepository.Object);
            var updateCoffeeDto = new AddUpdateNewModernCoffeeDto { Id = id, CoffeeTypeName = "Espresso", Price = 10 };

            result.UpdateCoffee(updateCoffeeDto);

            coffeeMockRepository.Verify(x => x.Update(It.Is<NewModernCoffee>(n => n.Id == id && n.CoffeeTypeName == "Espresso" && n.Price == 10)), Times.Once());
        }

        [TestMethod]
        public void UpdateCoffee_ThrowsResourceNotFoundException_WhenCoffeeDoesNotExist()
        {
            int id = 1;
            var coffeeMockRepository = new Mock<ICoffeeRepository<NewModernCoffee>>();
            coffeeMockRepository.Setup(x => x.GetById(id)).Returns((NewModernCoffee)null);
            var service = new NewModernCoffeeServices(coffeeMockRepository.Object);
            var updateCoffeeDto = new AddUpdateNewModernCoffeeDto { Id = id, CoffeeTypeName = "Espresso", Price = 10 };

            var ex = Assert.ThrowsException<ResourceNotFoundException>(() => service.UpdateCoffee(updateCoffeeDto));
            Assert.AreEqual($"Coffee with id {id} was not found", ex.Message);
        }

    }
}

