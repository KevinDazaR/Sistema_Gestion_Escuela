using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaLinus.Services.Students;
using PruebaLinus.Models;
using PruebaLinus.DTOs;
using Microsoft.EntityFrameworkCore;


namespace PruebaLinus.Controllers.Students
{
    public class StudentsUpdateController : ControllerBase
    {
        private readonly IStudentsRepository _studentsRepository;

        public StudentsUpdateController(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }

        [HttpPut]
        [Route("students/{id}")]
        public IActionResult Update(int id, StudentCreateDTO studentDTO)
        {
            // if (id != pet.Id)
            // {
            //     return BadRequest(new { message = "el Id de la Student no coincide " });
            // }

            try
            {
                _studentsRepository.Update(id,studentDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_studentsRepository.GetById(id) == null)
                {
                    return NotFound(new { message = "Student no encontrado" });
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(Update), new {studentDTO}, "Student updated with success.");
        }
    }
}