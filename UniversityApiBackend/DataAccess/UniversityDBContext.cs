﻿using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.DataAccess
{
    public class UniversityDBContext: DbContext
    {
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options) : base(options) 
        {

        }
        // TODO: Add DbSets (Tablas de la base de datos)
        public DbSet<User>? Users { get; set; }
        public DbSet<Curso>? Cursos { get; set; }
        public DbSet<Chapter>? Chapters { get; set; }

        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Alumno>? Alumnos { get; set; }




    }
}
