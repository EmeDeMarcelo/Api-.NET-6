using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public enum Nivel 
    { 
        Basico,
        Intermedio,
        Avanzado,
        Experto
    }
    public class Curso : BaseEntity
    {
        [Required, StringLength(50)]
        public string Nombre { get; set; } = string.Empty;
        [Required, StringLength(100)]
        public string DescripcionCorta { get; set; } = string.Empty;
        public string DescripcionLarga { get; set; } = string.Empty;
        public Nivel Nivel { get; set; } = Nivel.Basico;
        [Required]
        public ICollection<Categoria> Categorias { get; set; } = new List<Categoria>();
        [Required]
        public Chapter Chapter { get; set; } = new Chapter();
        [Required]
        public ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();

        public string PublicoObjetivo { get; set; } = string.Empty;
        public string Objetivos { get; set; } = string.Empty;
        public string Requisitos { get; set; } = string.Empty;
        



    }
}
