using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        private readonly IOperationService _service;

        public OperationsController(IOperationService service)
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

        [HttpGet("IncomeOperations")]
        public async Task<IActionResult> GetIncomeOperations()
        {
            var items = await _service.GetOperationsByType(true);
            return Ok(items);
        }

        [HttpGet("ExpenseOperations")]
        public async Task<IActionResult> GetExpenseOperations()
        {
            var items = await _service.GetOperationsByType(false);
            return Ok(items);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _service.DeleteAsync(id)) return NotFound();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OperationDto item)
        {
            var newItem = await _service.CreateAsync(item);
            if (newItem == null) return BadRequest();
            return CreatedAtAction(nameof(GetById), new { id = newItem.Id }, newItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] OperationDto item)
        {
            if (id != item.Id) return BadRequest();
            if (!await _service.UpdateAsync(id, item)) return NotFound();
            return NoContent();
        }
    }
}
