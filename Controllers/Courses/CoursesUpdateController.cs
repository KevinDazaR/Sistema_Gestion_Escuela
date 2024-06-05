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
    public class CoursesUpdateController : ControllerBase
    {
        private readonly ICoursesRepository _coursesRepository;

        public CoursesUpdateController(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

        [HttpPut]
        [Route("courses/{id}")]
        public IActionResult Update(int id, CourseCreateDTO courseDTO)
        {
            // if (id != pet.Id)
            // {
            //     return BadRequest(new { message = "el Id de la Owner no coincide " });
            // }

            try
            {
                _coursesRepository.Update(id,courseDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_coursesRepository.GetById(id) == null)
                {
                    return NotFound(new { message = "Owner no encontrado" });
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(Update), new {courseDTO}, "Course updated with success.");
        }
    }
}