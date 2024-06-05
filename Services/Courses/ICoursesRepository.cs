using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaLinus.Models;
using PruebaLinus.DTOs;

namespace PruebaLinus.Services.Courses
{
    public interface ICoursesRepository
    {
        IEnumerable<Course> GetAll();
        Course GetById(int id);
        void Add(CourseCreateDTO courseDTO);
        void Update(int id, CourseCreateDTO courseDTO);
        // void Delete(int id);
    }
}