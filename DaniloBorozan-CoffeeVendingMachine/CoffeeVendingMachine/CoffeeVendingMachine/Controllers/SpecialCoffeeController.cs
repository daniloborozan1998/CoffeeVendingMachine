using CoffeeVendingMachine.Dtos.NewModernCoffee;
using CoffeeVendingMachine.Services.Interfaces;
using CoffeeVendingMachine.Shared.CustomException;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeVendingMachine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialCoffeeController : ControllerBase
    {
        private INewModernCoffeeServices _coffeeService;

        public SpecialCoffeeController(INewModernCoffeeServices coffeeService)
        {
            _coffeeService = coffeeService;
        }
        [HttpGet]
        [Route("AllSpecialCoffee")]
        public ActionResult<List<NewModernCoffeeDto>> GetAllCoffee()
        {
            try
            {
                var coffees = _coffeeService.GetAllCoffee();
                return Ok(coffees);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!");
            }
        }
        [HttpGet("{id}")]
        public ActionResult<NewModernCoffeeDto> GetById(int id)
        {
            try
            {
                var coffee = _coffeeService.GetCoffeeById(id);
                return Ok(coffee);

            }
            catch (ResourceNotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!");
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] AddUpdateNewModernCoffeeDto updateCoffeeDto)
        {
            try
            {
                _coffeeService.AddCoffee(updateCoffeeDto);
                return StatusCode(StatusCodes.Status201Created, "Coffee created successfully!");
            }
            catch (CoffeeException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (Exception e)
            {
                //log
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!");
            }
        }
        [HttpPut]
        public IActionResult Put([FromBody] AddUpdateNewModernCoffeeDto updateCoffeeDto)
        {
            try
            {
                _coffeeService.UpdateCoffee(updateCoffeeDto);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (ResourceNotFoundException e)
            {
                //log
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (CoffeeException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (Exception e)
            {
                //log
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Invalid id value!");
                }
                _coffeeService.DeleteCoffeeById(id);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (ResourceNotFoundException e)
            {
                //log
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception e)
            {
                //log
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!");
            }
        }
    }
}
