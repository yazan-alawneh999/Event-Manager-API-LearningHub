using LearningHub.Core.Dto;
using LearningHub.Core.Services;
using LearningHub.Infra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {

        private readonly IReportsService _reportsService;
        public ReportsController(IReportsService reportsService)
        {
            _reportsService = reportsService;
        }

        [HttpGet]
        [Route("GetSalesReport")]
        public List<SalesReportDto> GetSalesRrport()
        {
            return _reportsService.GetSalesRrport();
        }


        [HttpGet]
        [Route("GetAttendanceReport/{id}")]
        public AttendanceDto GetAttendanceReport(int id)
        {
            return _reportsService.GetAttendanceReport(id);
        }
    }
}
