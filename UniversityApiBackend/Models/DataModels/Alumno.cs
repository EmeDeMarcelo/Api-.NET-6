using System.ComponentModel.DataAnnotations;


namespace UniversityApiBackend.Models.DataModels
{
    public class Alumno : BaseEntity
    {
        [Required]
        public string Nombre { get; set; }= string.Empty;
        [Required]
        public string Apellido { get; set; }= string.Empty;
        [Required]
        public DateTime FechNac { get; set; }
        public ICollection<Curso> Curso { get; set; } = new List<Curso>();
    }
}
