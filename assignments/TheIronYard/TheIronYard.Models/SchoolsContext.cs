using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheIronYard.Models
{
    public class SchoolsContext : DbContext
    {
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public SchoolsContext() : base("Name=SchoolsContext")
        {

        }
    }
}
