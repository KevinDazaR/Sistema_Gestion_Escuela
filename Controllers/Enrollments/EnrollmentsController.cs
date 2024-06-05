using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaLinus.Services.Enrollments;
using PruebaLinus.Models;
using Microsoft.EntityFrameworkCore;


namespace PruebaLinus.Controllers.Enrollments
{
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentsRepository _enrollmentsRepository;

        public EnrollmentsController(IEnrollmentsRepository enrollmentsRepository)
        {
            _enrollmentsRepository = enrollmentsRepository;
        }

        [HttpGet]
        [Route("enrollments")]
        public IEnumerable<Enrollment> GetAll()
        {
            return _enrollmentsRepository.GetAll();
        }

        [HttpGet]
        [Route("enrollments/{id}")]
        public IActionResult GetById(int id)
        {
            var enrollment = _enrollmentsRepository.GetById(id);
            
            if(enrollment == null)
            {
                return NotFound(new{message = "Enrollment not found, enter a valid Id"});
            }

            return Ok(enrollment);
        }
    }
}