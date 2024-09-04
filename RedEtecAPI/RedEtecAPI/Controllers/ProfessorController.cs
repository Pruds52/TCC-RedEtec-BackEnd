using Microsoft.AspNetCore.Mvc;
using RedEtecAPI.Entities;
using RedEtecAPI.Services;

namespace RedEtecAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : Controller
    {
        private readonly ProfessorService _professorService;

        public ProfessorController(ProfessorService professorService)
        {
            _professorService = professorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Professor>>> GetProfessor()
        {
            return await _professorService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Professor>> GetProfessor(int id)
        {
            var professor = await _professorService.GetByIdAsync(id);

            if (professor == null)
            {
                return NotFound();
            }

            return professor;
        }

        [HttpPost]
        public async Task<ActionResult<Professor>> PostProfessor([FromBody] Professor professor)
        {
            await _professorService.CreateAsync(professor);

            return CreatedAtAction(nameof(GetProfessor), new { id = professor.Id_Professor }, professor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutProfessor(int id, Professor professor)
        {
            if (id != professor.Id_Professor)
            {
                return BadRequest("Os IDs não são correspondentes.");
            }

            await _professorService.EditAsync(professor);

            return Ok("Professor atualizado.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProfessor(int id)
        {
            var professor = await _professorService.GetByIdAsync(id);

            if (professor == null)
            {
                return NotFound();
            }

            await _professorService.DeleteAsync(professor);

            return NoContent();
        }
    }
}
