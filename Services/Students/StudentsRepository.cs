using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaLinus.Data;
using PruebaLinus.Models;
using Microsoft.EntityFrameworkCore;
using PruebaLinus.Services.Students;
using PruebaLinus.DTOs;

namespace PruebaLinus.Services.Students
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly BaseContext _context;

        public StudentsRepository(BaseContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student GetById(int id)
        {
            return _context.Students.Find(id);
        }
        public void Add(StudentCreateDTO studentDTO)
        {
            var student = new Student
            {
                Names = studentDTO.Names,
                BirthDate = studentDTO.BirthDate,
                Address = studentDTO.Address,
                Email = studentDTO.Email
            };
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void Update(int id, StudentCreateDTO studentDTO)
        {
            var student = _context.Students.Find(id);

            if(student != null)
            {
                student.Names = studentDTO.Names;
                student.BirthDate = studentDTO.BirthDate;
                student.Address = studentDTO.Address;
                student.Email = studentDTO.Email;

                _context.SaveChanges();
        
            }
        }

         //AdicionalPoint Listar estudiante por fecha de cumpleaños
        public IEnumerable<Student> GetStudentByDateBirth(DateTime birthdate)
        {
            return _context.Students.Where(s =>  s.BirthDate == birthdate.Date).ToList();
        }

    }
}