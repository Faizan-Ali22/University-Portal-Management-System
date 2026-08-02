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
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyService _facultyService;

        public FacultyController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _facultyService.GetAllFacultiesAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _facultyService.GetFacultyByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Faculty entity)
        {
            await _facultyService.AddFacultyAsync(entity);
            return Ok(entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Faculty entity)
        {
            if (id != entity.Id) return BadRequest();
            await _facultyService.UpdateFacultyAsync(entity);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _facultyService.DeleteFacultyAsync(id);
            return NoContent();
        }
    }
}

