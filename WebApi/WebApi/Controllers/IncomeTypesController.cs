using Core;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeTypesController : ControllerBase
    {
        private readonly IIncomeTypeService _service;

        public IncomeTypesController(IIncomeTypeService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpGet]
        [Route("/api/[controller]/{id}/IncomeOperations")]
        public async Task<IActionResult> GetIncomeTypeOperations(int id)
        {
            var operations = await _service.GetIncomeTypeOperations(id);
            if (operations == null || operations.Count <= 0)
                return NotFound();
            return Ok(operations);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _service.DeleteAsync(id)) return NotFound();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IncomeTypeDto item)
        {
            var newItem = await _service.CreateAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = newItem.Id }, newItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] IncomeTypeDto item)
        {
            if (id != item.Id) return BadRequest();
            if(!await _service.UpdateAsync(id, item)) return NotFound();
            return NoContent();
        }
    }
}
