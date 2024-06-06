using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaLinus.Data;
using PruebaLinus.Models;
using Microsoft.EntityFrameworkCore;
using PruebaLinus.Services.Teachers;
using PruebaLinus.DTOs;

namespace PruebaLinus.Services.Teachers
{
    public class TeachersRepository : ITeachersRepository
    {
        private readonly BaseContext _context;

        public TeachersRepository(BaseContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Teacher> GetAll()
        {
            return _context.Teachers.ToList();
        }

        public Teacher GetById(int id)
        {
            return _context.Teachers.Find(id);
        }
        public void Add(TeacherCreateDTO teacherDTO)
        {
            var teacher = new Teacher
            {
                Names = teacherDTO.Names,
                Specialty = teacherDTO.Specialty,
                Phone = teacherDTO.Phone,
                Email = teacherDTO.Email,
                YearsExperience = teacherDTO.YearsExperience
            };
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }

        public void Update(int id, TeacherCreateDTO teacherDTO)
        {
            var teacher = _context.Teachers.Find(id);

            if(teacher != null)
            {
                teacher.Names = teacherDTO.Names;
                teacher.Specialty = teacherDTO.Specialty;
                teacher.Phone = teacherDTO.Phone;
                teacher.Email = teacherDTO.Email;
                teacher.YearsExperience = teacherDTO.YearsExperience;

                _context.SaveChanges();
        
            }
        }

         //AdicionalPoint Listar Todos los cursos que tiene un profesor 
        public IEnumerable<Enrollment> GetEnrollmentByDate(DateTime date)
        {
            return _context.Enrollments.Where(e =>  e.Date == date.Date).Include(s => s.Students).Include(c => c.Courses).ToList();
        }


    }
}