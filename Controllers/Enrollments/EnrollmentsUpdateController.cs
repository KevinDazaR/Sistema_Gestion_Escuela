using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaLinus.Services.Enrollments;
using PruebaLinus.Models;
using PruebaLinus.DTOs;
using Microsoft.EntityFrameworkCore;


namespace PruebaLinus.Controllers.Enrollments
{
    public class EnrollmentsUpdateController : ControllerBase
    {
        private readonly IEnrollmentsRepository _enrollmentsRepository;

        public EnrollmentsUpdateController(IEnrollmentsRepository enrollmentsRepository)
        {
            _enrollmentsRepository = enrollmentsRepository;
        }

        [HttpPut]
        [Route("enrollments/{id}")]
        public IActionResult Update(int id, EnrollmentCreateDTO enrollmentDTO)
        {
            // if (id != pet.Id)
            // {
            //     return BadRequest(new { message = "el Id de la Enrollment no coincide " });
            // }

            try
            {
                _enrollmentsRepository.Update(id,enrollmentDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_enrollmentsRepository.GetById(id) == null)
                {
                    return NotFound(new { message = "Enrollment not founded" });
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(Update), new {enrollmentDTO}, "Enrollment updated with success.");
        }
    }
}