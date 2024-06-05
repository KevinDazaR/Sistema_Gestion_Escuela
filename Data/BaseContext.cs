using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaLinus.Models;
using Microsoft.EntityFrameworkCore;

namespace PruebaLinus.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

    }
}