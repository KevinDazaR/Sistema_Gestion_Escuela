using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaLinus.Models;
using PruebaLinus.DTOs;

namespace PruebaLinus.Services.Teachers
{
    public interface ITeachersRepository
    {
        IEnumerable<Teacher> GetAll();
        Teacher GetById(int id);
        void Add(TeacherCreateDTO teacherDTO);
        void Update(int id, TeacherCreateDTO teacherDTO);
        // void Delete(int id);


    }
}