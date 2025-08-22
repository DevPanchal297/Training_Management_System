using SkillPro_Training_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillPro_Training_System.Services
{
    public class FeedbackService
    {

        public void GetFeedback(Employee curEmp, string courseId, string courseTitle)
        {
            int? inp = null;
            while (inp==null || inp<0 || inp>5 )
            {
                Console.Write($"Rate {courseId}:{courseTitle}:");
                string input = Console.ReadLine();
                if(int.TryParse(input,out int inp1))
                {
                    inp = inp1;
                }
                else { inp = null; }
            }

        }
    }
}
