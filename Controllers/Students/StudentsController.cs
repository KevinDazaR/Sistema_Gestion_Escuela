using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaLinus.Services.Students;
using PruebaLinus.Models;
using Microsoft.EntityFrameworkCore;


namespace PruebaLinus.Controllers.Students
{
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepository _studentsRepository;

        public StudentsController(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }

        [HttpGet]
        [Route("students")]
        public IEnumerable<Student> GetAll()
        {
            return _studentsRepository.GetAll();
        }

        [HttpGet]
        [Route("students/{id}")]
        public IActionResult GetById(int id)
        {
            var student = _studentsRepository.GetById(id);
            
            if(student == null)
            {
                return NotFound(new{message = "Student not found, enter a valid Id"});
            }

            return Ok(student);
        }
    }
}