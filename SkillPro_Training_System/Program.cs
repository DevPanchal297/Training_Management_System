using Newtonsoft.Json;
using SkillPro_Training_System.Models;
using SkillPro_Training_System.Services;
using System.Xml.Linq;

namespace SkillPro_Training_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to SkillPro Training System");
            Console.WriteLine();
            bool isExisting = false;
            Employee curEmp = null ;
            string? id = null;
            while (id == null || string.IsNullOrEmpty(id)) { Console.Write("Enter Your EmployeeID:"); id = Console.ReadLine(); }
            List<Employee> employees = GetEmployees();
            List<Course> courses = GetCourses();
            foreach (var emp in employees)
            {
                if (emp.Id.ToLower() == id.ToLower())
                {
                    Console.WriteLine("Existing Employee!, Proceeding to Options!");
                    curEmp = emp;
                    isExisting = true;
                    break;
                }
            }
            if (!isExisting) {
                curEmp = RegisterNewEmployee(id);
                employees.Add(curEmp);
            }
            Run(curEmp,employees,courses);
            SetEmployees(employees);
        }
        public static void Run(Employee? curEmp,List<Employee>? employees,List<Course>? courses)
        {
            int input = 0;
            do
            {
                Console.WriteLine("1. View Courses\n2. Enroll in Course\n3. Complete Next Task\n4. View Assigned Tasks\n5. View Completed Tasks\n6. See Analytics\n7. Exit");
                input = TryParseInt(Console.ReadLine());
                EnrollmentService enrollmentService = new EnrollmentService(courses);
                TaskManager taskManger = new TaskManager(); 
                switch (input)
                {
                    case 1:
                            enrollmentService.DisplayCourses();
                        break;
                    case 2:
                            enrollmentService.EnrollInCourse(curEmp,courses);
                        break;
                    case 3: 
                            taskManger.CompleteTask(curEmp);
                        //FeedBack => Viewall => Analuytics
                        break;
                    case 4:
                            
                        break;
                    case 5:
                        break;

                }
            }
            while (input != 7);
        }
        public static List<Course>? GetCourses()
        {
            var jsonCourse = File.ReadAllText("../../../Data/Courses.json");
            List<Course> courses = JsonConvert.DeserializeObject<List<Course>>(jsonCourse);
            return courses;
        }
        public static List<Employee>? GetEmployees()
        {
            var jsonEmployee = File.ReadAllText("../../../Data/Employees.json");
            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(jsonEmployee);
            return employees;
        }
        public static Employee? RegisterNewEmployee(string? id)
        {
            string? name = null, department = null;
            double? yoe = null;
            while (name == null || string.IsNullOrEmpty(name)) { Console.Write("Enter Your Name:"); name = Console.ReadLine(); }
            while (department == null || string.IsNullOrEmpty(department)) { Console.Write("Enter Your Department:"); department = Console.ReadLine(); }
            while (yoe == null)
            {
                Console.Write("Enter Your Year of Experience:");
                yoe = double.TryParse(Console.ReadLine(), out double x) == true ? yoe = x : yoe = null;
            }
            Employee employee = new(name, id, department, yoe, Guid.Empty);
            return employee;
        }
        public static int TryParseInt(string? input)
        {
            int result;
            while (!int.TryParse(input, out result) || result < 1 || result > 7)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 7.");
                input = Console.ReadLine();
            }
            return result;
        }
        public static void SetEmployees(List<Employee>? employee)
        {
            var data = JsonConvert.SerializeObject(employee, Formatting.Indented);
            File.WriteAllText("../../../Data/Employees.json",data);
        }
    }
}