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
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentsController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _enrollmentService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("by-student/{studentId}")]
        public async Task<IActionResult> GetByStudent(int studentId)
        {
            var items = await _enrollmentService.GetByStudentAsync(studentId);
            return Ok(items);
        }

        [HttpGet("by-course/{courseId}")]
        public async Task<IActionResult> GetByCourse(int courseId)
        {
            var items = await _enrollmentService.GetByCourseAsync(courseId);
            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> Enroll([FromBody] Enrollment entity)
        {
            await _enrollmentService.EnrollAsync(entity);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Drop(int id)
        {
            await _enrollmentService.DropAsync(id);
            return NoContent();
        }
    }
}

