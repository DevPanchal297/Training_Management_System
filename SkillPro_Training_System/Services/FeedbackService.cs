using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SkillPro_Training_System.Models;

namespace SkillPro_Training_System.Services
{
    public class FeedbackService
    {

        public void GetFeedback(Employee curEmp, string courseId, string courseTitle)
        {
            int inp = -1;
            while (inp==-1 || inp<0 || inp>5 )
            {
                Console.Write($"Rate {courseId}:{courseTitle}:");
                string input = Console.ReadLine();
                if(int.TryParse(input,out int inp1))
                {
                    inp = inp1;
                }
                else { inp = -1; }
            }
            List<Feedback> feedbacks = GetFeedbacks();
            bool done = false;
            foreach (var item in feedbacks)
            {
                if (item?.courseId == courseId) {
                    item.rating = (item.rating * item.number + inp)/(item.number+1);
                    item.number++;
                    done = true;
                }
            }
            if (!done) { 
               Feedback feedback = new Feedback();
                feedback.courseId = courseId;
                feedback.rating = inp;
                feedback.number = 1;
                feedbacks.Add(feedback);
            }
            SetFeedbacks(feedbacks);
        }
        public List<Feedback> GetFeedbacks()
        {
            var jsonFeedback = File.ReadAllText("../../../Data/Feedbacks.json");
            List<Feedback> feedbacks = JsonConvert.DeserializeObject<List<Feedback>>(jsonFeedback);
            return feedbacks;
        }
        public void SetFeedbacks(List<Feedback> feedbacks)
        {
            var json = JsonConvert.SerializeObject(feedbacks, Formatting.Indented);
            File.WriteAllText("../../../Data/Feedbacks.json", json);
            return;
        }
        public void GetRatings()
        {
            List<Feedback> feedbacks = GetFeedbacks();
            if (feedbacks.Count > 0) { Console.WriteLine("Feedback Summary:"); }
            foreach (var item in feedbacks)
            {
                Console.WriteLine($"CourseID: {item?.courseId} Rating: {item?.rating} Number of Feedbacks: {item?.number}");
            }
        }
    }
}
