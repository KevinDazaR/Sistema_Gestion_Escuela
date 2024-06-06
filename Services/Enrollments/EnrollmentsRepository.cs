using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaLinus.Data;
using PruebaLinus.Models;
using PruebaLinus.DTOs;
using Microsoft.EntityFrameworkCore;
using PruebaLinus.Services.Enrollments;
using PruebaLinus.Services.Emails;

namespace PruebaLinus.Services.Enrollments
{
    public class EnrollmentsRepository : IEnrollmentsRepository
    {
        private readonly BaseContext _context;
        private readonly IEmailService _emailService;


        public EnrollmentsRepository(BaseContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }
        
        public IEnumerable<Enrollment> GetAll()
        {
            return _context.Enrollments.Include(s => s.Students).Include(c => c.Courses).ToList();
        }

        public Enrollment GetById(int id)
        {
            return _context.Enrollments.Include(x => x.Students).Include(x => x.Courses).FirstOrDefault(x => x.Id == id);
        }
        
        public void Add(EnrollmentCreateDTO enrollmentDTO)
        {
            var enrollment = new Enrollment
            {
                Date = enrollmentDTO.Date,
                StudentId = enrollmentDTO.StudentId,
                CourseId = enrollmentDTO.CourseId,
                Status = enrollmentDTO.Status
            };

            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();

            var student = _context.Students.FirstOrDefault(s => s.Id == enrollmentDTO.StudentId);
            var course = _context.Courses.Find(enrollmentDTO.CourseId);

            Console.WriteLine("------student - "+student.Email);
            Console.WriteLine("------course -"+course);
            Console.WriteLine("------enrollmentDTO -"+enrollmentDTO.Date);

            if (student!= null && course!= null)
            {
                var subject = "Escuela Kevin Daza";
                var mensajePaciente = $"Hola, Sr@ {student.Names},\n Recuerda que tienes una nuevo curso programado para el {enrollmentDTO.Date}\n \n \n \n \n Feliz noche!";

                _emailService.SendEmail(student.Email, subject, mensajePaciente);
            }
        }

        public void Update(int id, EnrollmentCreateDTO enrollmentDTO)
        {
            var enrollment = _context.Enrollments.Find(id);

            if(enrollment != null)
            {
                enrollment.Date = enrollmentDTO.Date;
                enrollment.StudentId = enrollmentDTO.StudentId;
                enrollment.CourseId = enrollmentDTO.CourseId;
                enrollment.Status = enrollmentDTO.Status;
                
                _context.SaveChanges();
        
            }
        }

        //AdicionalPoint Listar Matriculas en una fecha especifica
        public IEnumerable<Enrollment> GetEnrollmentByDate(DateTime date)
        {
            return _context.Enrollments.Where(e =>  e.Date == date.Date).Include(s => s.Students).Include(c => c.Courses).ToList();
        }

          //AdicionalPoint Listar todas las matriculas que ha tenido un estudiante
        public IEnumerable<Enrollment> GetEnrollmentByStudent(int id)
        {
            var search = _context.Enrollments.Include(c => c.Students).Include(c => c.Courses).Where(c => c.StudentId == id)
            .ToList();

            
            // if(search==null)
            // {
            //      return "The teacher searched doesn't have listed courses yet with that Id"};
            // }

            return search;
        }
    }
}