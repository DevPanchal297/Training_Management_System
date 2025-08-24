# SkillPro Training System

SkillPro Training System is a .NET 8-based application designed to manage employee training, course enrollments, feedback, and task assignments within an organization. It provides a structured way to track employee progress, manage courses, and facilitate feedback and notifications.

## Features
- Employee management (add, update, track employees)
- Course management (enroll, assign, and track courses)
- Task assignment and completion tracking
- Feedback collection and management
- Notification service for important updates
- Data persistence using JSON files

## Concepts & Technologies Used
- **.NET 8**: Modern, cross-platform framework for building robust applications
- **Object-Oriented Programming (OOP)**: Classes for Employee, Course, Feedback, Task, etc.
- **Service Layer Pattern**: Services for Enrollment, Feedback, Task Management, and Notifications
- **JSON Data Storage**: Employees, Courses, and Feedbacks are stored in JSON files for easy data management
- **LINQ**: For querying and manipulating collections
- **Separation of Concerns**: Models, Services, and Data are organized for maintainability

## Getting Started
1. **Clone the repository**
2. Open the solution in Visual Studio or your preferred IDE
3. Build the solution (.NET 8 required)
4. Run the application

## Project Structure
- `Models/` - Data models (Employee, Course, Feedback, etc.)
- `Services/` - Business logic and service classes
- `Data/` - JSON files for persistent storage
- `Program.cs` - Application entry point

## Contribution
Contributions are welcome! Please fork the repository and submit a pull request.

## License
This project is licensed under the MIT License.
