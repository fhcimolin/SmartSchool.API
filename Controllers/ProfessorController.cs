using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        public ProfessorController()
        {
            
        }

        private readonly SmartContext _context;

        public readonly IRepository _repo;

        public ProfessorController(SmartContext context,
                                   IRepository repo)
        {
            _repo = repo;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var professor = _context.Professores.FirstOrDefault(x => x.Id.Equals(id));

            if(professor == null)
            {
                return BadRequest("O professor não foi encontrado.");
            }

            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            
            if(_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(x => x.Id == id);
            
            if(prof == null)
            {
                return BadRequest("Professor não encontrado.");
            }

            _context.Update(professor);
            _context.SaveChanges();

            return Ok(professor);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var _professor = _context.Professores.FirstOrDefault(x => x.Id == id);

            if(_professor == null)
            {
                return BadRequest("Professor não encontrado.");
            }

            _context.Update(professor);
            _context.SaveChanges();

            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _context.Professores.FirstOrDefault(x => x.Id == id);

            if(professor == null)
            {
                return BadRequest("Professor não encontrado.");
            }

            _context.Remove(professor);
            _context.SaveChanges();

            return Ok();
        }
    }
}