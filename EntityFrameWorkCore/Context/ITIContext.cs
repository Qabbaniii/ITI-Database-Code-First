using EntityFrameWorkCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkCore.Context
{
    public class ITIContext:DbContext
    {
        public ITIContext():base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=itiDB;Trusted_Connection=True;TrustServerCertificate=True");
        }
       protected override void OnModelCreating(ModelBuilder builder)
        {
           
            base.OnModelCreating(builder);

            // ---------------------------------------------------
            // Student – Department (Many-to-One)
            // ---------------------------------------------------
            builder.Entity<Student>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.Dept_Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Student>()
                .HasOne(s => s.Supervisor)
                .WithMany(su => su.SupervisedStudents)
                .HasForeignKey(s => s.St_super)
                .OnDelete(DeleteBehavior.NoAction);

            // ---------------------------------------------------
            // Course – Topic (Many-to-One)
            // ---------------------------------------------------
            builder.Entity<Course>()
                .HasOne(c => c.topic)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.Top_ID);

            // ---------------------------------------------------
            // StudCourse (Composite Key)
            // ---------------------------------------------------
            builder.Entity<Stud_Course>()
                .HasKey(sc => new { sc.Stud_ID, sc.course_ID });

            builder.Entity<Stud_Course>()
                .HasOne(sc => sc.student)
                .WithMany(s => s.StudCourses)
                .HasForeignKey(sc => sc.Stud_ID);

            builder.Entity<Stud_Course>()
                .HasOne(sc => sc.course)
                .WithMany(c => c.StudCourses)
                .HasForeignKey(sc => sc.course_ID);

            // ---------------------------------------------------
            // CourseInst (Composite Key)
            // ---------------------------------------------------
            builder.Entity<Course_Inst>()
                .HasKey(ci => new { ci.Inst_ID, ci.Course_ID });

            builder.Entity<Course_Inst>()
                .HasOne(ci => ci.instructor)
                .WithMany(i => i.CourseInstructors)
                .HasForeignKey(ci => ci.Inst_ID);

            builder.Entity<Course_Inst>()
                .HasOne(ci => ci.course)
                .WithMany(c => c.CourseInstructors)
                .HasForeignKey(ci => ci.Course_ID);

            // ---------------------------------------------------
            // Instructor – Department (Many-to-One)
            // ---------------------------------------------------
            builder.Entity<Instructor>()
                .HasOne(i => i.Department)
                .WithMany(d => d.Instructors)
                .HasForeignKey(i => i.Dept_ID)
                .OnDelete(DeleteBehavior.Restrict);

            // ---------------------------------------------------
            // Department – Instructor (One Manager)
            // ---------------------------------------------------
            builder.Entity<Department>()
                .HasOne(d => d.instructor)
                .WithMany()
                .HasForeignKey(d => d.Ins_ID)
                .OnDelete(DeleteBehavior.Restrict);
        }
        
       public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Stud_Course> Stud_Course { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Department> Depaertments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course_Inst> Course_Inst { get; set; }
    }
}
