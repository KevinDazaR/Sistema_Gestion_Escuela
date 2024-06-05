using System.ComponentModel.DataAnnotations.Schema; // Requerido para el ForeignKey
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; // Este es el que se necesita agegar para Requiered

namespace PruebaLinus.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required]
        public string? Names { get; set; }

        [Required]
        public string? Specialty { get; set; }

        [Required]
        public string? Phone { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public int? YearsExperience { get; set; }

        [JsonIgnore]
        public List<Course> ? Courses {get; set ;} // Un estudiante puede estar matriculado en uno o màs cursos
     
    }
}