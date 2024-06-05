using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaLinus.Services.Teachers;
using PruebaLinus.Models;
using PruebaLinus.DTOs;
using Microsoft.EntityFrameworkCore;


namespace PruebaLinus.Controllers.Teachers
{
    public class TeachersUpdateController : ControllerBase
    {
        private readonly ITeachersRepository _teachersRepository;

        public TeachersUpdateController(ITeachersRepository teachersRepository)
        {
            _teachersRepository = teachersRepository;
        }

        [HttpPut]
        [Route("teachers/{id}")]
        public IActionResult Update(int id, TeacherCreateDTO teacherDTO)
        {
            // if (id != pet.Id)
            // {
            //     return BadRequest(new { message = "el Id del Teacher no coincide " });
            // }

            try
            {
                _teachersRepository.Update(id,teacherDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_teachersRepository.GetById(id) == null)
                {
                    return NotFound(new { message = "Teacher not founded" });
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(Update), new {teacherDTO}, "Teacher updated with success.");
        }
    }
}