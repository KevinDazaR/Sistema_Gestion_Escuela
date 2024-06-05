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
    public class TeachersCreateController : ControllerBase
    {
        private readonly ITeachersRepository _teachersRepository;

        public TeachersCreateController(ITeachersRepository teachersRepository)
        {
            _teachersRepository = teachersRepository;
        }

        [HttpPost]
        [Route("teachers")]
        public IActionResult Create([FromBody]TeacherCreateDTO teacherDTO)
        {
             if (teacherDTO == null)
            {
                return BadRequest();
            }
            _teachersRepository.Add(teacherDTO);

            return CreatedAtAction(nameof(Create), new {teacherDTO}, "Teacher was made with success");
        }
    }
}