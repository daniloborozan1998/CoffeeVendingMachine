using Microsoft.AspNetCore.Http;
using CoffeeVendingMachine.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CoffeeVendingMachine.Dtos.Ingridients;
using CoffeeVendingMachine.Shared.CustomException;

namespace CoffeeVendingMachine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngridientController : ControllerBase
    {
        private IIngridientsServices _ingridientsService;

        public IngridientController(IIngridientsServices ingridientsService)
        {
            _ingridientsService = ingridientsService;
        }
        [HttpGet]
        [Route("AllIngridient")]
        public  ActionResult<List<IngridientsDto>> GetAllIngridient()
        {
            try
            {
                var ingridients = _ingridientsService.GetAllIngridients();
                return Ok(ingridients);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!");

            }
        }
        [HttpGet("{id}")]
        public  ActionResult<IngridientsDto> GetById(int id)
        {
            try
            {
                var ingridient = _ingridientsService.GetIngridientsById(id);
                return Ok(ingridient);
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
        public IActionResult Post([FromBody] AddUpdateIngridientsDto updateIngridientsDto)
        {
            try
            {
                _ingridientsService.AddIngridients(updateIngridientsDto);
                return StatusCode(StatusCodes.Status201Created, "Ingridient created successfully!");
            }
            catch (IngridientsException e)
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
        public IActionResult Put([FromBody] AddUpdateIngridientsDto updateIngridientsDto)
        {
            try
            {
                _ingridientsService.UpdateIngridients(updateIngridientsDto);
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
                _ingridientsService.DeleteIngridientsById(id);
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
