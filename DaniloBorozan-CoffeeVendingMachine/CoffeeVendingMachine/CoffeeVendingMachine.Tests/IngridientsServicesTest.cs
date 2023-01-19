using CoffeeVendingMachine.DataAccess.Interfaces;
using CoffeeVendingMachine.Domain.Models;
using CoffeeVendingMachine.Dtos.Ingridients;
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
    public class IngridientsServicesTest
    {
        [TestMethod]
        public void GetAllCoffee_Should_Return_Valid_Num_Of_Records_And_Return_AllCoffee_WhenCalled()
        {
            List<Ingridients> ingridient = new List<Ingridients>()
            {
               new Ingridients
                {
                    Id = 1,
                    Name = "Extra Sugar",
                    Price = 0
                },
                new Ingridients
                {
                    Id = 2,
                    Name = "Creamer",
                    Price = 5
                },
                new Ingridients
                {
                    Id = 3,
                    Name = "Caramelle",
                    Price = 5
                },
                new Ingridients
                {
                    Id = 4,
                    Name = "Extra milk",
                    Price = 5
                }
            };
            var ingridientMockRepository = new Mock<ICoffeeRepository<Ingridients>>();
            ingridientMockRepository.Setup(x => x.GetAll()).Returns(ingridient);

            IIngridientsServices ingridientsService = new IngridientsService(ingridientMockRepository.Object);

            var result = ingridientsService.GetAllIngridients();

            Assert.AreEqual(4, result.Count);
            Assert.AreEqual("Extra Sugar", result[0].Name);
            Assert.AreEqual("Creamer", result[1].Name);

        }
        [TestMethod]
        public void GetCoffeeById_ReturnsCoffeeDto_WhenCoffeeExists()
        {
            int id = 1;
            List<Ingridients> ingridient = new List<Ingridients>()
            {
               new Ingridients
                {
                    Id = 1,
                    Name = "Extra Sugar",
                    Price = 0
                },
                new Ingridients
                {
                    Id = 2,
                    Name = "Creamer",
                    Price = 5
                },
                new Ingridients
                {
                    Id = 3,
                    Name = "Caramelle",
                    Price = 5
                },
                new Ingridients
                {
                    Id = 4,
                    Name = "Extra milk",
                    Price = 5
                }
            };


            var ingridientMockRepository = new Mock<ICoffeeRepository<Ingridients>>();
            ingridientMockRepository.Setup(x => x.GetById(id)).Returns(ingridient[0]);

            IIngridientsServices ingridientsService = new IngridientsService(ingridientMockRepository.Object);

            var result = ingridientsService.GetIngridientsById(id);

            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
        }
        [TestMethod]
        public void GetCoffeeById_ThrowsResourceNotFoundException_WhenCoffeeDoesNotExist()
        {
            int id = 1;
            var ingridientMockRepository = new Mock<ICoffeeRepository<Ingridients>>();
            ingridientMockRepository.Setup(r => r.GetById(id)).Returns((Ingridients)null);


            var result = new IngridientsService(ingridientMockRepository.Object);

            var ex = Assert.ThrowsException<ResourceNotFoundException>(() => result.GetIngridientsById(id));
            Assert.AreEqual($"Ingridients with id {id} was not found", ex.Message);
        }
        [TestMethod]
        public void AddCoffee_InsertsNewCoffee_WhenCalled()
        {
            var ingridientMockRepository = new Mock<ICoffeeRepository<Ingridients>>();
            var result = new IngridientsService(ingridientMockRepository.Object);
            var addIngridientDto = new AddUpdateIngridientsDto { Name = "Honey", Price = 10 };

            result.AddIngridients(addIngridientDto);

            ingridientMockRepository.Verify(x => x.Insert(It.Is<Ingridients>(n => n.Name == "Honey" && n.Price == 10)), Times.Once());
        }
        [TestMethod]
        public void DeleteCoffeeById_DeletesCoffee_WhenCoffeeExists()
        {
            int id = 1;
            List<Ingridients> ingridient = new List<Ingridients>()
            {
               new Ingridients
                {
                    Id = 1,
                    Name = "Extra Sugar",
                    Price = 0
                },
                new Ingridients
                {
                    Id = 2,
                    Name = "Creamer",
                    Price = 5
                },
                new Ingridients
                {
                    Id = 3,
                    Name = "Caramelle",
                    Price = 5
                },
                new Ingridients
                {
                    Id = 4,
                    Name = "Extra milk",
                    Price = 5
                }
            };
            var ingridientMockRepository = new Mock<ICoffeeRepository<Ingridients>>();
            ingridientMockRepository.Setup(x => x.GetById(id)).Returns(ingridient[0]);
            //mockCoffeeRepository.Setup(r => r.GetById(id)).Returns(new Coffee { Id = id });
            var result = new IngridientsService(ingridientMockRepository.Object);

            result.DeleteIngridientsById(id);

            ingridientMockRepository.Verify(x => x.Delete(It.Is<Ingridients>(n => n.Id == id)), Times.Once());
        }

        [TestMethod]
        public void DeleteCoffeeById_ThrowsResourceNotFoundException_WhenCoffeeDoesNotExist()
        {
            int id = 1;
            var ingridientMockRepository = new Mock<ICoffeeRepository<Ingridients>>();
            ingridientMockRepository.Setup(r => r.GetById(id)).Returns((Ingridients)null);
            var result = new IngridientsService(ingridientMockRepository.Object);

            var ex = Assert.ThrowsException<ResourceNotFoundException>(() => result.DeleteIngridientsById(id));
            Assert.AreEqual($"Ingridients with {id} was not found!", ex.Message);
        }
        [TestMethod]
        public void UpdateCoffee_UpdatesCoffee_WhenCoffeeExists()
        {
            // Arrange
            int id = 2;
            List<Ingridients> ingridient = new List<Ingridients>()
            {
               new Ingridients
                {
                    Id = 1,
                    Name = "Extra Sugar",
                    Price = 0
                },
                new Ingridients
                {
                    Id = 2,
                    Name = "Creamer",
                    Price = 5
                },
                new Ingridients
                {
                    Id = 3,
                    Name = "Caramelle",
                    Price = 5
                },
                new Ingridients
                {
                    Id = 4,
                    Name = "Extra milk",
                    Price = 5
                }
            };
            var ingridientMockRepository = new Mock<ICoffeeRepository<Ingridients>>();
            ingridientMockRepository.Setup(x => x.GetById(id)).Returns(ingridient[1]);
            var result = new IngridientsService(ingridientMockRepository.Object);
            var updateIngridientDto = new AddUpdateIngridientsDto { Id = id, Name = "Creamer", Price = 7 };

            result.UpdateIngridients(updateIngridientDto);

            ingridientMockRepository.Verify(x => x.Update(It.Is<Ingridients>(n => n.Id == id && n.Name == "Creamer" && n.Price == 7)), Times.Once());
        }

        [TestMethod]
        public void UpdateCoffee_ThrowsResourceNotFoundException_WhenCoffeeDoesNotExist()
        {
            int id = 1;
            var coffeeMockRepository = new Mock<ICoffeeRepository<Ingridients>>();
            coffeeMockRepository.Setup(x => x.GetById(id)).Returns((Ingridients)null);
            var service = new IngridientsService(coffeeMockRepository.Object);
            var updateIngridientDto = new AddUpdateIngridientsDto { Id = id, Name = "Creamer", Price = 7 };

            var ex = Assert.ThrowsException<ResourceNotFoundException>(() => service.UpdateIngridients(updateIngridientDto));
            Assert.AreEqual($"Ingridients with id {id} was not found", ex.Message);
        }
    }
}
           
