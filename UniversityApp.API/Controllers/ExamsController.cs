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
    public class ExamsController : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamsController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _examService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _examService.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Exam entity)
        {
            await _examService.AddAsync(entity);
            return Ok(entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Exam entity)
        {
            if (id != entity.Id) return BadRequest();
            await _examService.UpdateAsync(entity);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _examService.DeleteAsync(id);
            return NoContent();
        }
    }
}

