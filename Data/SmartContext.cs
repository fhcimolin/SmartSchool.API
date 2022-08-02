using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Models;

namespace SmartSchool.API.Data
{
    public class SmartContext : DbContext
    {
        public SmartContext(DbContextOptions<SmartContext> options) : base(options)
        {
            
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<AlunoCurso> AlunosCursos { get; set; }
        public DbSet<AlunoDisciplina> AlunosDisciplinas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Professor> Professores { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AlunoDisciplina>()
                .HasKey(AD => new {AD.AlunoId, AD.DisciplinaId});

            builder.Entity<AlunoCurso>()
                .HasKey(AC => new {AC.AlunoId, AC.CursoId});

            builder.Entity<Professor>()
                .HasData(new List<Professor>{
                    new Professor(1, 1, "Lauro", "Oliveira"),
                    new Professor(2, 2, "Roberto", "Soares"),
                    new Professor(3, 3, "Ronaldo", "Marconi"),
                    new Professor(4, 4, "Rodrigo", "Carvalho"),
                    new Professor(5, 5, "Joel", "Carvalho")
                });

            builder.Entity<Aluno>()
                .HasData(new List<Aluno>{
                    new Aluno(1, "Flavio", "Cimolin", "91827398", 81745, DateTime.Parse("1990-01-03")),
                    new Aluno(2, "Nadir", "Ridan", "8937492", 10000, DateTime.Parse("1980-02-05")),
                    new Aluno(3, "Zenildo", "Odlinez", "111723726", 54654, DateTime.Parse("2000-06-05"))
                });

            builder.Entity<Curso>()
                .HasData(new List<Curso>{
                    new Curso(1, "Tecnologia da Informação"),
                    new Curso(2, "Sistemas de Informação"),
                    new Curso(3, "Ciência da Computação")
                });

            builder.Entity<Disciplina>()
                .HasData(new List<Disciplina>{
                    new Disciplina(1, "Matemática", 1, 1),
                    new Disciplina(2, "Matemática", 1, 3),
                    new Disciplina(3, "Física", 2, 3),
                    new Disciplina(4, "Português", 3, 1),
                    new Disciplina(5, "Inglês", 4, 1),
                    new Disciplina(6, "Inglês", 4, 2),
                    new Disciplina(7, "Inglês", 4, 3),
                    new Disciplina(8, "Programação", 5, 1),
                    new Disciplina(9, "Programação", 5, 2),
                    new Disciplina(10, "Programação", 5, 3)
                });

            builder.Entity<AlunoDisciplina>()
                .HasData(new List<AlunoDisciplina>{
                    new AlunoDisciplina(1,1),
                    new AlunoDisciplina(1,2),
                    new AlunoDisciplina(2,1),
                    new AlunoDisciplina(3,1),
                    new AlunoDisciplina(3,2)
                });
        }
    }
}