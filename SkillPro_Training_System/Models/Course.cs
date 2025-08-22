using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillPro_Training_System.Models
{
    public class Course
    {
        public string? Id {  get; set; }
        public string? Title { get; set; }
        public int? Level { get; set; }
        public double? Duration { get; set; }
    }
}
