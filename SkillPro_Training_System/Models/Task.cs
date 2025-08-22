using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillPro_Training_System.Models
{
    public class Task1
    {
        public string TaskTitle {  get; set; }
        public string courseId { get; set; }
        public Task1(string taskTitle,string courseId)
        {
            this.TaskTitle = taskTitle;
            this.courseId = courseId;
        }
    }
}
