using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Dtos;
using SmartSchool.API.Helpers;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AlunoController : ControllerBase
    {
        public readonly IRepository _repo;
        public readonly IMapper _mapper;

        public AlunoController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]PageParams pageParams)
        {
            var alunos = await _repo.GetAllAlunosAsync(pageParams, includeProfessor: false);

            var alunosResult = _mapper.Map<IEnumerable<AlunoDto>>(alunos);

            Response.AddPagination(alunos.CurrentPage, alunos.PageSize, alunos.TotalCount, alunos.TotalPages);

            return Ok(alunosResult);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id);

            if (aluno == null)
            {
                return BadRequest("O aluno não foi encontrado.");
            }

            return Ok(_mapper.Map<AlunoDto>(aluno));
        }

        [HttpPost]
        public IActionResult Post(AlunoRegistrarDto model)
        {
            var aluno = _mapper.Map<Aluno>(model);

            _repo.Add(aluno);
            
            if(_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }

            return BadRequest("Aluno não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, AlunoRegistrarDto model)
        {
            var aluno = _repo.GetAlunoById(id);

            if (aluno == null)
            {
                return BadRequest("Aluno não encontrado.");
            }

            _mapper.Map(model, aluno);

            _repo.Update(aluno);
            
            if(_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }

            return BadRequest("Aluno não atualizado.");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, AlunoRegistrarDto model)
        {
            var aluno = _repo.GetAlunoById(id);

            if (aluno == null)
            {
                return BadRequest("Aluno não encontrado.");
            }

            _mapper.Map(aluno, model);

            _repo.Update(model);
            
            if(_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }

            return BadRequest("Aluno não atualizado.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunoById(id);

            if (aluno == null)
            {
                return BadRequest("Aluno não encontrado.");
            }

            _repo.Remove(aluno);
            
            if(_repo.SaveChanges())
            {
                return Ok();
            }

            return BadRequest("Aluno não removido.");
        }
    }
}