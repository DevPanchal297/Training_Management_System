using SkillPro_Training_System.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SkillPro_Training_System.Models
{
    public class Employee
    {
        public string? Name { get; set; }
        public string? Id { get; set; }
        public string? Department { get; set; }
        public double? Yoe { get; set; }
        public Guid? RegId { get; set; }
        public List<Course>? enrolledCourses { get; set; }
        public List<Feedback>? feedbacks { get; set; }
        public Queue<Task1>? assignedTasks { get; set; }
        public Stack<Task1>? completedTasks { get; set; }
        private NotificationService _notificationService;
        public NotificationService NotificationService
        {
            get => _notificationService ??= new NotificationService();
            set => _notificationService = value;
        }
        public Employee()
        {
            InitializeNotificationService();
        }
        public Employee(string Name,string Id,string Department,double? Yoe, Guid? regId) {
            this.Name = Name;
            this.Id = Id;
            this.Department = Department;
            this.Yoe = Yoe;
            this.RegId = (regId==Guid.Empty)?Guid.NewGuid():regId;
            enrolledCourses = new List<Course>();
            feedbacks = new List<Feedback>();
            assignedTasks = new Queue<Task1>();
            completedTasks = new Stack<Task1>();
            this.NotificationService = new NotificationService();
            this.NotificationService.OnNotification += (msg) => Console.WriteLine($"[Notification]: {msg}");
        }
        public void NotifyCertificateIssued(string msg)
        {
            NotificationService?.RaiseNotification(msg);
        }
        private void InitializeNotificationService()
        {
            this.NotificationService = new NotificationService();
            this.NotificationService.OnNotification += (msg) => Console.WriteLine($"[Notification]: {msg}");
        }
        public void GetAssignedTasks()
        {
            foreach (var item in assignedTasks)
            {
                Console.WriteLine($"Course ID: {item.courseId} Title: {item.TaskTitle}");
            }
        }
        public void GetCompletedTasks()
        {
            Stack<Task1> st = new Stack<Task1> (completedTasks);
            while (st.Count > 0) {
                Console.WriteLine($"Course ID: {st.Peek().courseId} Title: {st.Peek().TaskTitle}");
                st.Pop();
            }
        }
    }
}
