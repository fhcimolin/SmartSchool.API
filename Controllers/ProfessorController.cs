using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Dtos;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        public readonly IRepository _repo;
        public readonly IMapper _mapper;

        public ProfessorController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var professores = _repo.GetAllProfessores(includeAlunos: true);

            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(professores));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id);

            if(professor == null)
            {
                return BadRequest("O professor não foi encontrado.");
            }

            return Ok(_mapper.Map<ProfessorDto>(professor));
        }

        [HttpPost]
        public IActionResult Post(ProfessorDto model)
        {
            var professor = _mapper.Map<Professor>(model);

            _repo.Add(professor);
            
            if(_repo.SaveChanges())
            {
                return Created($"api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
            }

            return BadRequest("Professor não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfessorDto model)
        {
            var professor = _repo.GetProfessorById(id);
            
            if(professor == null)
            {
                return BadRequest("Professor não encontrado.");
            }

            _mapper.Map(model, professor);

            _repo.Update(professor);

            if(_repo.SaveChanges())
            {
                return Created($"api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
            }

            return BadRequest("Professor não atualizado.");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, ProfessorDto model)
        {
            var professor = _repo.GetProfessorById(id);

            if(professor == null)
            {
                return BadRequest("Professor não encontrado.");
            }

            _mapper.Map(model, professor);

            _repo.Update(professor);
            
            if(_repo.SaveChanges())
            {
                return Created($"api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
            }

            return BadRequest("Professor não atualizado.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _repo.GetProfessorById(id);

            if(professor == null)
            {
                return BadRequest("Professor não encontrado.");
            }

            _repo.Remove(professor);
            
            if(_repo.SaveChanges())
            {
                return Ok();
            }

            return BadRequest("Professor não removido.");
        }
    }
}