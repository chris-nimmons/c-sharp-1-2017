using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1_31_17
{
    public class SchoolsContext : DbContext
    {
        public SchoolsContext() : base("Name=SchoolsContext")
        {

        }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
    

            base.OnModelCreating(modelBuilder);
        }
    }

    public class Cars
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Course> Courses { get; set; }

        public Instructor()
        {
            Courses = new List<Course>();

        }
    }
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Instructor> Instructors { get; set; }
        public List<Course> Courses { get; set; }
        public virtual List<Student> Students { get; set; }
        public School()
        {
            Students = new List<Student>();
            Instructors = new List<Instructor>(); 
            Courses = new List<Course>();
        }
    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Course> Courses { get; set; }

        public Student() {

            Courses = new List<Course>();
        }
    }
    public class Course
    {
        public int Id { get; set; }
        public Instructor Instructor { get; set; }
        public string Name { get; set; }
        public virtual List<Student> Students { get; set; }

        public Course()
        {
            Students = new List<Student>();
        }
    }

}
