using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkCore.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Duration { get; set; }
        public string Discreption { get; set; }
        public int Top_ID { get; set; }
        public Topic topic { get; set; }
        public ICollection<Stud_Course> StudCourses { get; set; }
        public ICollection<Course_Inst> CourseInstructors { get; set; }
    }
}
