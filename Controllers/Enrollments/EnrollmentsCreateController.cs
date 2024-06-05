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
    public class EnrollmentsCreateController : ControllerBase
    {
        private readonly IEnrollmentsRepository _enrollmentsRepository;

        public EnrollmentsCreateController(IEnrollmentsRepository enrollmentsRepository)
        {
            _enrollmentsRepository = enrollmentsRepository;
        }

        [HttpPost]
        [Route("enrollments")]
        public IActionResult Create([FromBody]EnrollmentCreateDTO enrollmentDTO)
        {
             if (enrollmentDTO == null)
            {
                return BadRequest();
            }
            _enrollmentsRepository.Add(enrollmentDTO);

            return CreatedAtAction(nameof(Create), new {enrollmentDTO}, "Enrollment was made with success");
        }
    }
}