using Core;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseTypesController : ControllerBase
    {
        private readonly IExpenseTypeService _service;

        public ExpenseTypesController(IExpenseTypeService service)
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
        [Route("/api/[controller]/{id}/ExpenseOperations")]
        public async Task<IActionResult> GetExpenseTypeOperations(int id)
        {
            var operations = await _service.GetExpenseTypeOperations(id);
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
        public async Task<IActionResult> Post([FromBody] ExpenseTypeDto item)
        {
            var newItem = await _service.CreateAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = newItem.Id }, newItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ExpenseTypeDto item)
        {
            if (id != item.Id) return BadRequest();
            if(!await _service.UpdateAsync(id, item)) return NotFound();
            return NoContent();
        }
    }
}
