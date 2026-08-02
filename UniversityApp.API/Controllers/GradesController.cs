using UniversityApp.Entities;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.BLL.Interfaces;
using UniversityApp.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace UniversityApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class GradesController : ControllerBase
    {
        private readonly IGradeService _gradeService;

        public GradesController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _gradeService.GetAllAsync();
            return Ok(items);
        }

        [HttpPost("assign")]
        public async Task<IActionResult> Assign([FromBody] Grade entity)
        {
            await _gradeService.AssignGradeAsync(entity);
            return Ok(entity);
        }

        [HttpGet("transcript/{studentId}")]
        public async Task<IActionResult> GetTranscript(int studentId)
        {
            var report = await _gradeService.GetTranscriptAsync(studentId);
            return Ok(report);
        }
    }
}

