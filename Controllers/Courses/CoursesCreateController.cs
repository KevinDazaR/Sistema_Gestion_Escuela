using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaLinus.Services.Courses;
using PruebaLinus.Models;
using PruebaLinus.DTOs;
using Microsoft.EntityFrameworkCore;


namespace PruebaLinus.Controllers.Courses
{
    public class CoursesCreateController : ControllerBase
    {
        private readonly ICoursesRepository _coursesRepository;

        public CoursesCreateController(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

        [HttpPost]
        [Route("courses")]
        public IActionResult Create([FromBody]CourseCreateDTO courseDTO)
        {
             if (courseDTO == null)
            {
                return BadRequest();
            }
            _coursesRepository.Add(courseDTO);

            return CreatedAtAction(nameof(Create), new {courseDTO}, "Course was made with success");
        }
    }
}