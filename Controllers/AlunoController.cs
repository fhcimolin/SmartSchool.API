using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly SmartContext _context;

        public AlunoController(SmartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(x => x.Id.Equals(id));

            if(aluno == null)
            {
                return BadRequest("O aluno não foi encontrado.");
            }

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();

            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(x => x.Id == id);
            
            if(alu == null)
            {
                return BadRequest("Aluno não encontrado.");
            }

            _context.Update(aluno);
            _context.SaveChanges();

            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var _aluno = _context.Alunos.FirstOrDefault(x => x.Id == id);

            if(_aluno == null)
            {
                return BadRequest("Aluno não encontrado.");
            }

            _context.Update(aluno);
            _context.SaveChanges();

            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(x => x.Id == id);

            if(aluno == null)
            {
                return BadRequest("Aluno não encontrado.");
            }

            _context.Remove(aluno);
            _context.SaveChanges();

            return Ok();
        }
    }
}