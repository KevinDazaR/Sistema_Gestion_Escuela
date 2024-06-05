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
    public class StudentsCreateController : ControllerBase
    {
        private readonly IStudentsRepository _studentsRepository;

        public StudentsCreateController(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }

        [HttpPost]
        [Route("students")]
        public IActionResult Create([FromBody]StudentCreateDTO studentDTO)
        {
             if (studentDTO == null)
            {
                return BadRequest();
            }
            _studentsRepository.Add(studentDTO);

            return CreatedAtAction(nameof(Create), new {studentDTO}, "Student was made with success");
        }
    }
}