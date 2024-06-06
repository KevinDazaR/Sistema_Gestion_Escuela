using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaLinus.Models;
using PruebaLinus.DTOs;

namespace PruebaLinus.Services.Students
{
    public interface IStudentsRepository
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        void Add(StudentCreateDTO studentDTO);
        void Update(int id, StudentCreateDTO studentDTO);
        // void Delete(int id);

        //Adicional 
        IEnumerable<Student> GetStudentByDateBirth( DateTime birthdate);
    }
}