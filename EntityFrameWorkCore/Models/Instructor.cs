using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkCore.Models
{
   public class Instructor
    {
       public int ID { get; set; }
        public string Name { get; set; }
        public double Bonus { get; set; }
        public double Salary { get; set; }
        public string Address { get; set; }
        public double Hour_rate { get; set; }
        public int Dept_ID { get; set; }
        public Department Department { get; set; }
        public ICollection<Course_Inst> CourseInstructors { get; set; }
    }
}
