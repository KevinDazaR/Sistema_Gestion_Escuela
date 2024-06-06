using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaLinus.Models;
using PruebaLinus.DTOs;

namespace PruebaLinus.Services.Enrollments
{
    public interface IEnrollmentsRepository
    {
        IEnumerable<Enrollment> GetAll();
        Enrollment GetById(int id);
        void Add(EnrollmentCreateDTO enrollmentDTO);
        void Update(int id, EnrollmentCreateDTO enrollmentDTO);
        // void Delete(int id);

        //Adicional 
        IEnumerable<Enrollment> GetEnrollmentByDate( DateTime date);
    }
}