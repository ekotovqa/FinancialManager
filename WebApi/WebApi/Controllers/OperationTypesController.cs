using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationTypesController : ControllerBase
    {
        private readonly IOperationTypeService _service;

        public OperationTypesController(IOperationTypeService service)
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

        [HttpGet("IncomeTypes")]
        public async Task<IActionResult> GetAllIncomeTypes()
        {
            var items = await _service.GetAllAsync();
            return Ok(items.Where(n => n.IsIncome));
        }

        [HttpGet("ExpenseTypes")]
        public async Task<IActionResult> GetAllExpenseTypes()
        {
            var items = await _service.GetAllAsync();
            return Ok(items.Where(n => !n.IsIncome));
        }

        [HttpGet("{id}/Operations")]
        public async Task<IActionResult> GetOperations(int id)
        {
            var operations = await _service.GetOperations(id);
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
        public async Task<IActionResult> Post([FromBody] OperationTypeDto item)
        {
            var newItem = await _service.CreateAsync(item);
            if (newItem == null) return BadRequest();
            return CreatedAtAction(nameof(GetById), new { id = newItem.Id }, newItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] OperationTypeDto item)
        {
            if (id != item.Id) return BadRequest();
            if (!await _service.UpdateAsync(id, item)) return NotFound();
            return NoContent();
        }
    }
}
