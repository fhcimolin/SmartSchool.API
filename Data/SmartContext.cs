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
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<AlunoDisciplina> AlunosDisciplinas { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AlunoDisciplina>()
                .HasKey(AD => new {AD.AlunoId, AD.DisciplinaId});

            builder.Entity<Professor>()
                .HasData(new List<Professor>{
                    new Professor(1, "Lauro"),
                    new Professor(2, "Roberto"),
                    new Professor(3, "Ronaldo"),
                    new Professor(4, "Rodrigo")
                });

            builder.Entity<Aluno>()
                .HasData(new List<Aluno>{
                    new Aluno(1, "Flavio", "Cimolin", "91827398"),
                    new Aluno(2, "Nadir", "Ridan", "8937492"),
                    new Aluno(3, "Zenildo", "Odlinez", "111723726")
                });

            builder.Entity<Disciplina>()
                .HasData(new List<Disciplina>{
                    new Disciplina(1, "Matemática", 2),
                    new Disciplina(2, "Português", 4)
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