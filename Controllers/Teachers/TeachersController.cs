using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaLinus.Services.Teachers;
using PruebaLinus.Models;
using Microsoft.EntityFrameworkCore;


namespace PruebaLinus.Controllers.Teachers
{
    public class TeachersController : ControllerBase
    {
        private readonly ITeachersRepository _teachersRepository;

        public TeachersController(ITeachersRepository teachersRepository)
        {
            _teachersRepository = teachersRepository;
        }

        [HttpGet]
        [Route("api/teachers")]
        public IEnumerable<Teacher> GetAll()
        {
            return _teachersRepository.GetAll();
        }

        [HttpGet]
        [Route("teachers/{id}")]
        public IActionResult GetById(int id)
        {
            var teacher = _teachersRepository.GetById(id);
            
            if(teacher == null)
            {
                return NotFound(new{message = "Teacher not found, enter a valid Id"});
            }

            return Ok(teacher);
        }
    }
}