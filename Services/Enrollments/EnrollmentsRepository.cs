using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaLinus.Data;
using PruebaLinus.Models;
using Microsoft.EntityFrameworkCore;
using PruebaLinus.Services.Enrollments;
using PruebaLinus.DTOs;

namespace PruebaLinus.Services.Enrollments
{
    public class EnrollmentsRepository : IEnrollmentsRepository
    {
        private readonly BaseContext _context;

        public EnrollmentsRepository(BaseContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Enrollment> GetAll()
        {
            return _context.Enrollments.ToList();
        }

        public Enrollment GetById(int id)
        {
            return _context.Enrollments.Find(id);
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

    }
}