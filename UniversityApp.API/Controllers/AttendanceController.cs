using UniversityApp.Entities;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.BLL.Interfaces;
using UniversityApp.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System;

namespace UniversityApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _attendanceService.GetAllAsync();
            return Ok(items);
        }

        [HttpPost("mark")]
        public async Task<IActionResult> Mark([FromBody] Attendance entity)
        {
            await _attendanceService.MarkAttendanceAsync(entity);
            return Ok(entity);
        }

        [HttpGet("report")]
        public async Task<IActionResult> GetReport([FromQuery] int courseId, [FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            var report = await _attendanceService.GetReportAsync(courseId, from, to);
            return Ok(report);
        }
    }
}

