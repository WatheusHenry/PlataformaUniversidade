using DDD.Infra.MemoryDB.Interfaces;
using DDD.Unimar.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Universidade.AplicationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplineController : ControllerBase
    {
        readonly IDisciplineRepository _disciplineRepository;

        public DisciplineController(IDisciplineRepository disciplineRepository)
        {
            _disciplineRepository = disciplineRepository;
        }

        [HttpGet]
        public ActionResult<List<Discipline>> Get()
        {
            var disciplines = _disciplineRepository.GetDisciplines();
            return Ok(disciplines);
        }

        [HttpGet("{id}")]
        public ActionResult<Discipline> GetById(int id)
        {
            var discipline = _disciplineRepository.GetDisciplineById(id);

            if (discipline == null)
            {
                return NotFound(); // Retorna 404 se a disciplina não for encontrada.
            }

            return Ok(discipline);
        }

        [HttpPost]
        public ActionResult<Discipline> CreateDiscipline(Discipline discipline)
        {
            if (string.IsNullOrWhiteSpace(discipline.Name))
            {
                return BadRequest("O nome da disciplina é obrigatório.");
            }

            _disciplineRepository.InsertDiscipline(discipline);
            return CreatedAtAction(nameof(GetById), new { Id = discipline.DisciplineId }, discipline);
        }

        [HttpPut("{id}")]
        public ActionResult<Discipline> UpdateDiscipline(int id, Discipline updatedDiscipline)
        {
            var existingDiscipline = _disciplineRepository.GetDisciplineById(id);

            if (existingDiscipline == null)
            {
                return NotFound();
            }

            existingDiscipline.Name = updatedDiscipline.Name;
            existingDiscipline.Value = updatedDiscipline.Value;
            existingDiscipline.Available = updatedDiscipline.Available;
            existingDiscipline.Ead = updatedDiscipline.Ead;

            _disciplineRepository.UpdateDiscipline(existingDiscipline);

            return Ok(existingDiscipline);
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteDiscipline(int id)
        {
            var existingDiscipline = _disciplineRepository.GetDisciplineById(id);

            if (existingDiscipline == null)
            {
                return NotFound(); 
            }

            _disciplineRepository.DeleteDiscipline(existingDiscipline);

            return NoContent(); 
        }
    }
}
