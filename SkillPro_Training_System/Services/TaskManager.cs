using SkillPro_Training_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillPro_Training_System.Services
{
    public class TaskManager
    {
        List<string> tasksOrder = new List<string> { "Complete Module", "Complete Assignment", "Show and Tell Session" };
        public List<Task1> CreateTasks(Course course)
        {
            List<Task1> tasks = new List<Task1>();
            foreach (var item in tasksOrder)
            {
                Task1 task = new Task1($"{item} - {course?.Title}", course?.Id);
                tasks.Add(task);
            }
            return tasks;
        }
        public void CompleteTask(Employee curEmp)
        {
            Task1 frontOfQ = curEmp?.assignedTasks?.Count > 0 ? curEmp.assignedTasks.First() : null;
            if (frontOfQ == null)
            {
                Console.WriteLine("No Task Assigned!, Returning.."); return;
            }
            if (curEmp?.completedTasks == null) { curEmp.completedTasks = new Stack<Task1>(); }
            curEmp.completedTasks.Push(frontOfQ);
            curEmp.assignedTasks.Dequeue();
            Console.WriteLine($"{frontOfQ.TaskTitle} is Completed!");
            curEmp.NotifyCertificateIssued($"Task '{frontOfQ.TaskTitle}' completed by {curEmp.Name}");
            if (frontOfQ.TaskTitle.Contains("Session"))
            {
                FeedbackService feedbackService = new FeedbackService();
                string courseTitle = frontOfQ.TaskTitle.Split('-')[1].Trim();
                Console.WriteLine($"Completed All Tasks of {courseTitle}");
                feedbackService.GetFeedback(curEmp, frontOfQ?.courseId, courseTitle);
            }
        }
    }
}
