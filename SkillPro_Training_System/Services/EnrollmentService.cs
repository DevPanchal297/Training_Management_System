using SkillPro_Training_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillPro_Training_System.Services
{
    public class EnrollmentService
    {
        public List<Course> _courses;
        public EnrollmentService(List<Course> courses)
        {
            _courses = courses;
        }
        public void DisplayCourses()
        {
            foreach (var course in _courses)
            {
                Console.WriteLine($"ID: {course.Id} Title: {course.Title} Level: {course.Level} Duration: {course.Duration}");
            }
            Console.WriteLine();
        }
        public void EnrollInCourse(Employee curEmp, List<Course> courses)
        {
            string courseId = null;
            while (courseId == null)
            {
                Console.Write("Enter Course ID to Enroll:");
                courseId = Console.ReadLine();
            }
            Course curCourse = courses.Find(c => c.Id == courseId);
            if (curCourse == null) { Console.WriteLine("CourseID not found in Database!, Returning..."); return; }
            if (curEmp.enrolledCourses == null)
            {
                curEmp.enrolledCourses = new List<Course>();
            }
            EnrollInCourse(curEmp, curCourse?.Id, courses);
        }
        public void EnrollInCourse(Employee curEmp, string? courseId, List<Course> courses)
        {
            Course curCourse = courses.Find(c => c.Id == courseId);
            if (curEmp.enrolledCourses.Find(c => c.Id == courseId) != null)
            {
                Console.WriteLine("Employee already Enrolled in course!, Returning.."); return;
            }
            curEmp.enrolledCourses.Add(curCourse);
            TaskManager taskManager = new TaskManager();
            List<Task1> tasks = taskManager.CreateTasks(curCourse);
            if (curEmp?.assignedTasks == null) { curEmp.assignedTasks = new Queue<Task1>(); }
            foreach (Task1 task in tasks)
            {
                curEmp.assignedTasks.Enqueue(task);
            }
            Console.WriteLine($"{curEmp?.Name} Enrolled in {curCourse?.Title}");
        }
    }
}
