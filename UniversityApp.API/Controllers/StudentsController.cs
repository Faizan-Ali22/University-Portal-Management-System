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
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string term)
        {
            var students = await _studentService.SearchStudentsAsync(term);
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Student student)
        {
            await _studentService.AddStudentAsync(student);
            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Student student)
        {
            if (id != student.Id) return BadRequest();
            await _studentService.UpdateStudentAsync(student);
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentService.DeleteStudentAsync(id);
            return NoContent();
        }
    }
}

