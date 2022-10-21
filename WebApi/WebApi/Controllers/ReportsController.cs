using Core;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _service;

        public ReportsController(IReportService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("/api/[controller]/DailyReport")]
        public async Task<IActionResult> GetDailyReport([FromQuery] DateTime reportDate)
        {
            return Ok(await _service.GetDailyReport(reportDate));
        }

        [HttpGet]
        [Route("/api/[controller]/PeriodReport")]
        public async Task<IActionResult> GetPeriodReport([FromQuery] DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate) return BadRequest("StartDate can't be more EndDate");
            return Ok(await _service.GetPeriodReport(startDate, endDate));
        }
    }
}
