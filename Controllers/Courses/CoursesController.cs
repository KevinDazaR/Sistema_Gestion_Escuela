using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaLinus.Services.Courses;
using PruebaLinus.Models;
using Microsoft.EntityFrameworkCore;


namespace PruebaLinus.Controllers.Courses
{
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesRepository _coursesRepository;

        public CoursesController(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

        [HttpGet]
        [Route("courses")]
        public IEnumerable<Course> GetAll()
        {
            return _coursesRepository.GetAll();
        }

        [HttpGet]
        [Route("courses/{id}")]
        public IActionResult GetById(int id)
        {
            var course = _coursesRepository.GetById(id);
            
            if(course == null)
            {
                return NotFound(new{message = "Course not found, enter a valid Id"});
            }

            return Ok(course);
        }

        [HttpGet]
        [Route("teachers/{id}/courses")]
        public IEnumerable<Course> GetCoursesByTeacher(int id)
        {
            var course = _coursesRepository.GetCoursesByTeacher(id);
            return course;
        }
    }
}