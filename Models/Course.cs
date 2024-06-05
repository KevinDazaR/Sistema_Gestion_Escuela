using System.ComponentModel.DataAnnotations.Schema; // Requerido para el ForeignKey
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; // Este es el que se necesita agegar para Requiered

namespace PruebaLinus.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public string? Specialty { get; set; }

        [Required]
        public string? Duration { get; set; }
        [Required]
        public int? Capacity { get; set; }


        [Required]
        public int? Schedule { get; set; }

        [Required]
        [ForeignKey("TeacherId")]
        public int? TeacherId { get; set; }
        public Teacher ? Teachers {get; set ;} // ● Un curso está a cargo de un único profesor.

        [JsonIgnore]
        public List<Student> ? Students {get; set ;} // ● Un curso puede tener uno o más alumnos matriculado
    
    }
}