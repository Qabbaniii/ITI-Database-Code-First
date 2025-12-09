using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkCore.Models
{
    public class Course_Inst
    {
        public int Inst_ID { get; set; }
        public Instructor instructor { get; set; }
        public int Course_ID { get; set; }
        public Course course { get; set; }
        public double  evaluate{ get; set; }


    }
}
