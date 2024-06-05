using System.ComponentModel.DataAnnotations.Schema; // Requerido para el ForeignKey
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; // Este es el que se necesita agegar para Requiered

namespace PruebaLinus.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string? Names { get; set; }

        [Required]
        public  DateTime? BirthDate { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? Email { get; set; }

        [JsonIgnore]
         public List<Course> ? Courses {get; set ;} //Un alumno puede estar matriculado en uno o más cursos.
     
    }
}