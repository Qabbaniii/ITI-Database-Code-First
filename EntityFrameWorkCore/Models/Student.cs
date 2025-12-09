using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkCore.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public int Dept_Id { get; set; }
        public Department Department { get; set; }

        public ICollection<Stud_Course> StudCourses { get; set; }

        public int St_super {  get; set; }
        public Student Supervisor { get; set; }
        public ICollection<Student> SupervisedStudents { get; set; }





    }
}
