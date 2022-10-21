using Core;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeOperationsController : ControllerBase
    {
        private readonly IIncomeOperationService _service;

        public IncomeOperationsController(IIncomeOperationService service)
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _service.DeleteAsync(id)) return NotFound();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IncomeOperationDto item)
        {
            var newItem = await _service.CreateAsync(item);
            if (newItem == null) return BadRequest();
            return CreatedAtAction(nameof(GetById), new { id = newItem.Id }, newItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] IncomeOperationDto item)
        {
            if (id != item.Id) return BadRequest();
            if (!await _service.UpdateAsync(id, item)) return NotFound();
            return NoContent();
        }
    }
}
