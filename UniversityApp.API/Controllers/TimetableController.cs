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
    public class TimetableController : ControllerBase
    {
        private readonly ITimetableService _timetableService;

        public TimetableController(ITimetableService timetableService)
        {
            _timetableService = timetableService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _timetableService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _timetableService.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpGet("by-day/{day}")]
        public async Task<IActionResult> GetByDay(string day)
        {
            var items = await _timetableService.GetByDayAsync(day);
            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Timetable entity)
        {
            await _timetableService.AddAsync(entity);
            return Ok(entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Timetable entity)
        {
            if (id != entity.Id) return BadRequest();
            await _timetableService.UpdateAsync(entity);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _timetableService.DeleteAsync(id);
            return NoContent();
        }
    }
}

