using System.ComponentModel.DataAnnotations.Schema; // Requerido para el ForeignKey
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; // Este es el que se necesita agegar para Requiered

namespace PruebaLinus.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        [Required]
        [ForeignKey("StudentId")]
        public int? StudentId { get; set; }
        public Student ? Students {get; set ;} // una matricula està asociado a un unico estudiante

        [Required]
        [ForeignKey("CourseId")]
        public int? CourseId { get; set; }
        public Course ? Courses {get; set ;} /// una matricula està asociado a un unico curso especifìco

        [Required]
        public string? Status { get; set; }
     
    }
}

