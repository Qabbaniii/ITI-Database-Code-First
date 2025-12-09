using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkCore.Models
{
    public class Stud_Course
    {
        public int Stud_ID { get; set; }

        [ForeignKey("Stud_ID")]
        public Student student { get; set; }    
        public int course_ID { get; set; }

        [ForeignKey("course_ID")]
        public Course course { get; set; }
        public double Grade{ get; set; }



    }
}
