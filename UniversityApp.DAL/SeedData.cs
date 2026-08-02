using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using UniversityApp.Entities;
using UniversityApp.Entities.Models;

namespace UniversityApp.DAL;

public static class SeedData
{
    public static void SeedDatabase(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<UniversityDbContext>();

        context.Database.EnsureCreated();

        if (context.Departments.Any()) return; // Already seeded

        var departments = new[]
        {
            new Department { Name = "Computer Science", Code = "CS", HeadOfDepartment = "Dr. Ahmad Raza", CreatedAt = DateTime.UtcNow },
            new Department { Name = "Electrical Engineering", Code = "EE", HeadOfDepartment = "Dr. Nadia Hussain", CreatedAt = DateTime.UtcNow },
            new Department { Name = "Business Administration", Code = "BBA", HeadOfDepartment = "Dr. Tariq Mahmood", CreatedAt = DateTime.UtcNow },
            new Department { Name = "Mathematics", Code = "MATH", HeadOfDepartment = "Dr. Sana Fatima", CreatedAt = DateTime.UtcNow },
            new Department { Name = "Physics", Code = "PHY", HeadOfDepartment = "Dr. Imran Ali", CreatedAt = DateTime.UtcNow }
        };
        context.Departments.AddRange(departments);
        context.SaveChanges();

        var faculty = new[]
        {
            new Faculty { Name = "Dr. Ahmad Raza", Email = "ahmad.raza@air.edu", Department = "CS", Designation = "Professor", HireDate = new DateTime(2015, 1, 1), CreatedAt = DateTime.UtcNow },
            new Faculty { Name = "Dr. Nadia Hussain", Email = "nadia.hussain@air.edu", Department = "EE", Designation = "Professor", HireDate = new DateTime(2014, 1, 1), CreatedAt = DateTime.UtcNow },
            new Faculty { Name = "Dr. Tariq Mahmood", Email = "tariq.mahmood@air.edu", Department = "BBA", Designation = "Associate Professor", HireDate = new DateTime(2016, 1, 1), CreatedAt = DateTime.UtcNow },
            new Faculty { Name = "Dr. Sana Fatima", Email = "sana.fatima@air.edu", Department = "MATH", Designation = "Associate Professor", HireDate = new DateTime(2017, 1, 1), CreatedAt = DateTime.UtcNow },
            new Faculty { Name = "Dr. Imran Ali", Email = "imran.ali@air.edu", Department = "PHY", Designation = "Professor", HireDate = new DateTime(2013, 1, 1), CreatedAt = DateTime.UtcNow },
            new Faculty { Name = "Mr. Bilal Ahmed", Email = "bilal.ahmed@air.edu", Department = "CS", Designation = "Lecturer", HireDate = new DateTime(2020, 1, 1), CreatedAt = DateTime.UtcNow },
            new Faculty { Name = "Ms. Farah Khan", Email = "farah.khan@air.edu", Department = "EE", Designation = "Assistant Professor", HireDate = new DateTime(2019, 1, 1), CreatedAt = DateTime.UtcNow },
            new Faculty { Name = "Dr. Zara Malik", Email = "zara.malik@air.edu", Department = "BBA", Designation = "Assistant Professor", HireDate = new DateTime(2018, 1, 1), CreatedAt = DateTime.UtcNow }
        };
        context.Faculties.AddRange(faculty);
        context.SaveChanges();

        var courses = new[]
        {
            new Course { Title = "Intro to Programming", Code = "CS101", CreditHours = 3, Semester = "Fall 2024", FacultyId = faculty[0].Id, CreatedAt = DateTime.UtcNow },
            new Course { Title = "Data Structures", Code = "CS201", CreditHours = 3, Semester = "Fall 2024", FacultyId = faculty[0].Id, CreatedAt = DateTime.UtcNow },
            new Course { Title = "Database Systems", Code = "CS301", CreditHours = 3, Semester = "Spring 2025", FacultyId = faculty[5].Id, CreatedAt = DateTime.UtcNow },
            new Course { Title = "AI & Machine Learning", Code = "CS401", CreditHours = 4, Semester = "Spring 2025", FacultyId = faculty[0].Id, CreatedAt = DateTime.UtcNow },
            new Course { Title = "Circuit Analysis", Code = "EE101", CreditHours = 3, Semester = "Fall 2024", FacultyId = faculty[1].Id, CreatedAt = DateTime.UtcNow },
            new Course { Title = "Signals & Systems", Code = "EE201", CreditHours = 3, Semester = "Spring 2025", FacultyId = faculty[6].Id, CreatedAt = DateTime.UtcNow },
            new Course { Title = "Principles of Management", Code = "BBA101", CreditHours = 3, Semester = "Fall 2024", FacultyId = faculty[2].Id, CreatedAt = DateTime.UtcNow },
            new Course { Title = "Marketing", Code = "BBA201", CreditHours = 3, Semester = "Spring 2025", FacultyId = faculty[7].Id, CreatedAt = DateTime.UtcNow },
            new Course { Title = "Calculus I", Code = "MATH101", CreditHours = 4, Semester = "Fall 2024", FacultyId = faculty[3].Id, CreatedAt = DateTime.UtcNow },
            new Course { Title = "Linear Algebra", Code = "MATH201", CreditHours = 3, Semester = "Spring 2025", FacultyId = faculty[3].Id, CreatedAt = DateTime.UtcNow },
            new Course { Title = "Mechanics", Code = "PHY101", CreditHours = 4, Semester = "Fall 2024", FacultyId = faculty[4].Id, CreatedAt = DateTime.UtcNow },
            new Course { Title = "Thermodynamics", Code = "PHY201", CreditHours = 3, Semester = "Spring 2025", FacultyId = faculty[4].Id, CreatedAt = DateTime.UtcNow }
        };
        context.Courses.AddRange(courses);
        context.SaveChanges();

        var students = new[]
        {
            new Student { Name = "Ahmed Khan", Email = "ahmed.khan@student.air.edu", Department = "CS", EnrollmentDate = DateTime.UtcNow.AddMonths(-6), GPA = 3.8m, CreatedAt = DateTime.UtcNow },
            new Student { Name = "Sara Ali", Email = "sara.ali@student.air.edu", Department = "CS", EnrollmentDate = DateTime.UtcNow.AddMonths(-6), GPA = 3.5m, CreatedAt = DateTime.UtcNow },
            new Student { Name = "Hassan Malik", Email = "hassan.malik@student.air.edu", Department = "EE", EnrollmentDate = DateTime.UtcNow.AddMonths(-6), GPA = 3.2m, CreatedAt = DateTime.UtcNow },
            new Student { Name = "Ayesha Iqbal", Email = "ayesha.iqbal@student.air.edu", Department = "BBA", EnrollmentDate = DateTime.UtcNow.AddMonths(-6), GPA = 3.9m, CreatedAt = DateTime.UtcNow },
            new Student { Name = "Usman Tariq", Email = "usman.tariq@student.air.edu", Department = "MATH", EnrollmentDate = DateTime.UtcNow.AddMonths(-6), GPA = 3.1m, CreatedAt = DateTime.UtcNow },
            new Student { Name = "Fatima Zahra", Email = "fatima.zahra@student.air.edu", Department = "CS", EnrollmentDate = DateTime.UtcNow.AddMonths(-6), GPA = 3.7m, CreatedAt = DateTime.UtcNow },
            new Student { Name = "Ali Raza", Email = "ali.raza@student.air.edu", Department = "EE", EnrollmentDate = DateTime.UtcNow.AddMonths(-6), GPA = 2.8m, CreatedAt = DateTime.UtcNow },
            new Student { Name = "Hira Noor", Email = "hira.noor@student.air.edu", Department = "PHY", EnrollmentDate = DateTime.UtcNow.AddMonths(-6), GPA = 3.4m, CreatedAt = DateTime.UtcNow },
            new Student { Name = "Zain Abbas", Email = "zain.abbas@student.air.edu", Department = "CS", EnrollmentDate = DateTime.UtcNow.AddMonths(-6), GPA = 3.0m, CreatedAt = DateTime.UtcNow },
            new Student { Name = "Mariam Shahid", Email = "mariam.shahid@student.air.edu", Department = "BBA", EnrollmentDate = DateTime.UtcNow.AddMonths(-6), GPA = 3.6m, CreatedAt = DateTime.UtcNow },
            new Student { Name = "Hamza Yousaf", Email = "hamza.yousaf@student.air.edu", Department = "EE", EnrollmentDate = DateTime.UtcNow.AddMonths(-6), GPA = 2.9m, CreatedAt = DateTime.UtcNow },
            new Student { Name = "Noor Fatima", Email = "noor.fatima@student.air.edu", Department = "MATH", EnrollmentDate = DateTime.UtcNow.AddMonths(-6), GPA = 3.3m, CreatedAt = DateTime.UtcNow },
            new Student { Name = "Bilal Hussain", Email = "bilal.hussain@student.air.edu", Department = "PHY", EnrollmentDate = DateTime.UtcNow.AddMonths(-6), GPA = 2.7m, CreatedAt = DateTime.UtcNow },
            new Student { Name = "Sadia Amir", Email = "sadia.amir@student.air.edu", Department = "CS", EnrollmentDate = DateTime.UtcNow.AddMonths(-6), GPA = 3.5m, CreatedAt = DateTime.UtcNow },
            new Student { Name = "Rehan Ahmed", Email = "rehan.ahmed@student.air.edu", Department = "BBA", EnrollmentDate = DateTime.UtcNow.AddMonths(-6), GPA = 3.1m, CreatedAt = DateTime.UtcNow }
        };
        context.Students.AddRange(students);
        context.SaveChanges();

        var enrollments = new[]
        {
            new Enrollment { StudentId = students[0].Id, CourseId = courses[0].Id, EnrollmentDate = DateTime.UtcNow, Status = "Enrolled" },
            new Enrollment { StudentId = students[1].Id, CourseId = courses[0].Id, EnrollmentDate = DateTime.UtcNow, Status = "Enrolled" },
            new Enrollment { StudentId = students[2].Id, CourseId = courses[4].Id, EnrollmentDate = DateTime.UtcNow, Status = "Enrolled" },
            new Enrollment { StudentId = students[3].Id, CourseId = courses[6].Id, EnrollmentDate = DateTime.UtcNow, Status = "Enrolled" },
            new Enrollment { StudentId = students[4].Id, CourseId = courses[8].Id, EnrollmentDate = DateTime.UtcNow, Status = "Enrolled" },
            new Enrollment { StudentId = students[5].Id, CourseId = courses[1].Id, EnrollmentDate = DateTime.UtcNow, Status = "Enrolled" },
            new Enrollment { StudentId = students[6].Id, CourseId = courses[5].Id, EnrollmentDate = DateTime.UtcNow, Status = "Enrolled" },
            new Enrollment { StudentId = students[7].Id, CourseId = courses[10].Id, EnrollmentDate = DateTime.UtcNow, Status = "Enrolled" },
            new Enrollment { StudentId = students[8].Id, CourseId = courses[2].Id, EnrollmentDate = DateTime.UtcNow, Status = "Enrolled" },
            new Enrollment { StudentId = students[9].Id, CourseId = courses[7].Id, EnrollmentDate = DateTime.UtcNow, Status = "Enrolled" },
            new Enrollment { StudentId = students[10].Id, CourseId = courses[4].Id, EnrollmentDate = DateTime.UtcNow, Status = "Enrolled" },
            new Enrollment { StudentId = students[11].Id, CourseId = courses[9].Id, EnrollmentDate = DateTime.UtcNow, Status = "Enrolled" },
            new Enrollment { StudentId = students[12].Id, CourseId = courses[11].Id, EnrollmentDate = DateTime.UtcNow, Status = "Enrolled" },
            new Enrollment { StudentId = students[13].Id, CourseId = courses[3].Id, EnrollmentDate = DateTime.UtcNow, Status = "Enrolled" },
            new Enrollment { StudentId = students[14].Id, CourseId = courses[6].Id, EnrollmentDate = DateTime.UtcNow, Status = "Enrolled" },
            new Enrollment { StudentId = students[0].Id, CourseId = courses[8].Id, EnrollmentDate = DateTime.UtcNow, Status = "Enrolled" }, // Cross dept
            new Enrollment { StudentId = students[2].Id, CourseId = courses[0].Id, EnrollmentDate = DateTime.UtcNow, Status = "Enrolled" },
            new Enrollment { StudentId = students[3].Id, CourseId = courses[0].Id, EnrollmentDate = DateTime.UtcNow, Status = "Enrolled" },
            new Enrollment { StudentId = students[4].Id, CourseId = courses[10].Id, EnrollmentDate = DateTime.UtcNow, Status = "Enrolled" },
            new Enrollment { StudentId = students[5].Id, CourseId = courses[6].Id, EnrollmentDate = DateTime.UtcNow, Status = "Enrolled" }
        };
        context.Enrollments.AddRange(enrollments);
        context.SaveChanges();

        var attendances = new[]
        {
            new Attendance { StudentId = students[0].Id, CourseId = courses[0].Id, Date = DateTime.UtcNow.AddDays(-2), Status = "Present" },
            new Attendance { StudentId = students[1].Id, CourseId = courses[0].Id, Date = DateTime.UtcNow.AddDays(-2), Status = "Present" },
            new Attendance { StudentId = students[0].Id, CourseId = courses[0].Id, Date = DateTime.UtcNow.AddDays(-1), Status = "Late" },
            new Attendance { StudentId = students[1].Id, CourseId = courses[0].Id, Date = DateTime.UtcNow.AddDays(-1), Status = "Absent" },
            new Attendance { StudentId = students[2].Id, CourseId = courses[4].Id, Date = DateTime.UtcNow.AddDays(-2), Status = "Present" },
            new Attendance { StudentId = students[3].Id, CourseId = courses[6].Id, Date = DateTime.UtcNow.AddDays(-2), Status = "Present" }
        };
        context.Attendances.AddRange(attendances);
        context.SaveChanges();

        var exams = new[]
        {
            new Exam { CourseId = courses[0].Id, ExamType = "Midterm", Date = DateTime.UtcNow.AddDays(10), TotalMarks = 50, CreatedAt = DateTime.UtcNow },
            new Exam { CourseId = courses[0].Id, ExamType = "Final", Date = DateTime.UtcNow.AddDays(40), TotalMarks = 100, CreatedAt = DateTime.UtcNow },
            new Exam { CourseId = courses[4].Id, ExamType = "Midterm", Date = DateTime.UtcNow.AddDays(12), TotalMarks = 50, CreatedAt = DateTime.UtcNow },
            new Exam { CourseId = courses[4].Id, ExamType = "Final", Date = DateTime.UtcNow.AddDays(42), TotalMarks = 100, CreatedAt = DateTime.UtcNow },
            new Exam { CourseId = courses[6].Id, ExamType = "Midterm", Date = DateTime.UtcNow.AddDays(15), TotalMarks = 50, CreatedAt = DateTime.UtcNow },
            new Exam { CourseId = courses[6].Id, ExamType = "Final", Date = DateTime.UtcNow.AddDays(45), TotalMarks = 100, CreatedAt = DateTime.UtcNow }
        };
        context.Exams.AddRange(exams);
        context.SaveChanges();

        var grades = new[]
        {
            new Grade { StudentId = students[0].Id, ExamId = exams[0].Id, MarksObtained = 45, GradeValue = "A", CreatedAt = DateTime.UtcNow },
            new Grade { StudentId = students[1].Id, ExamId = exams[0].Id, MarksObtained = 38, GradeValue = "B", CreatedAt = DateTime.UtcNow },
            new Grade { StudentId = students[2].Id, ExamId = exams[2].Id, MarksObtained = 42, GradeValue = "A", CreatedAt = DateTime.UtcNow },
            new Grade { StudentId = students[3].Id, ExamId = exams[4].Id, MarksObtained = 48, GradeValue = "A", CreatedAt = DateTime.UtcNow }
        };
        context.Grades.AddRange(grades);
        context.SaveChanges();

        var announcements = new[]
        {
            new Announcement { Title = "Fall 2024 Registration Open", Content = "Registration is now open...", PostedBy = "Admin", Priority = "High", CreatedAt = DateTime.UtcNow },
            new Announcement { Title = "Mid-Term Exam Schedule Released", Content = "The schedule for mid-terms is now available...", PostedBy = "Admin", Priority = "High", CreatedAt = DateTime.UtcNow },
            new Announcement { Title = "Guest Lecture on AI", Content = "Join us for a guest lecture...", PostedBy = "Faculty", Priority = "Medium", CreatedAt = DateTime.UtcNow },
            new Announcement { Title = "Library Hours Extended", Content = "The library will now stay open until midnight...", PostedBy = "Librarian", Priority = "Low", CreatedAt = DateTime.UtcNow },
            new Announcement { Title = "Sports Week Announcement", Content = "Sign up for sports week...", PostedBy = "Sports Committee", Priority = "Medium", CreatedAt = DateTime.UtcNow }
        };
        context.Announcements.AddRange(announcements);
        context.SaveChanges();

        var timetables = new[]
        {
            new Timetable { CourseId = courses[0].Id, DayOfWeek = "Monday", StartTime = "09:00:00", EndTime = "10:30:00", Room = "Room 101", CreatedAt = DateTime.UtcNow },
            new Timetable { CourseId = courses[0].Id, DayOfWeek = "Wednesday", StartTime = "09:00:00", EndTime = "10:30:00", Room = "Room 101", CreatedAt = DateTime.UtcNow },
            new Timetable { CourseId = courses[4].Id, DayOfWeek = "Tuesday", StartTime = "11:00:00", EndTime = "12:30:00", Room = "Lab 1", CreatedAt = DateTime.UtcNow }
        };
        context.Timetables.AddRange(timetables);
        context.SaveChanges();

        var adminUser = new AppUser
        {
            Email = "admin@university.edu",
            FullName = "Admin User",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
            Role = "Admin",
            CreatedAt = DateTime.UtcNow
        };
        context.AppUsers.Add(adminUser);
        context.SaveChanges();
    }
}
