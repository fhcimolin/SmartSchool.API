using SmartSchool.API.Models;

namespace SmartSchool.API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        bool SaveChanges();

        // ALUNOS
        Aluno[] GetAllAlunos();
        Aluno[] GetAllAlunosByDisciplinaId();
        Aluno GetAlunoById();

        // PROFESSORES
        Professor[] GetAllProfessores();
        Professor[] GetAllProfessoresByDisciplinaId();
        Professor GetProfessorById();
    }
}