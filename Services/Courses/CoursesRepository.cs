using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaLinus.Data;
using PruebaLinus.Models;
using Microsoft.EntityFrameworkCore;
using PruebaLinus.Services.Courses;
using PruebaLinus.DTOs;

namespace PruebaLinus.Services.Courses
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly BaseContext _context;

        public CoursesRepository(BaseContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return _context.Courses.Find(id);
        }
        public void Add(CourseCreateDTO courseDTO)
        {
            var course = new Course
            {
                Name = courseDTO.Name,
                Description = courseDTO.Description,
                TeacherId = courseDTO.TeacherId,
                Schedule = courseDTO.Schedule,
                Specialty = courseDTO.Specialty,
                Duration = courseDTO.Duration,
                Capacity = courseDTO.Capacity
            };
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void Update(int id, CourseCreateDTO courseDTO)
        {
            var course = _context.Courses.Find(id);

            if(course != null)
            {
                course.Name = courseDTO.Name;
                course.Description = courseDTO.Description;
                course.TeacherId = courseDTO.TeacherId;
                course.Schedule = courseDTO.Schedule;
                course.Specialty = courseDTO.Specialty;
                course.Duration = courseDTO.Duration;
                course.Capacity = courseDTO.Capacity;
                
                _context.SaveChanges();
        
            }
        }

    }
}