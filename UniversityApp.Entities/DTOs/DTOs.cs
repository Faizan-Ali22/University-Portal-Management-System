namespace UniversityApp.Entities.DTOs;

public class LoginRequestDto
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class LoginResponseDto
{
    public string Token { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}

public class DashboardStatsDto
{
    public int TotalStudents { get; set; }
    public int TotalCourses { get; set; }
    public int TotalFaculty { get; set; }
    public int TotalDepartments { get; set; }
    public int TotalEnrollments { get; set; }
    public List<Announcement> RecentAnnouncements { get; set; } = new();
}

public class AttendanceReportDto
{
    public string StudentName { get; set; } = string.Empty;
    public string CourseName { get; set; } = string.Empty;
    public int TotalClasses { get; set; }
    public int Present { get; set; }
    public int Absent { get; set; }
    public int Late { get; set; }
    public decimal Percentage { get; set; }
}

public class GradeReportDto
{
    public string StudentName { get; set; } = string.Empty;
    public string CourseName { get; set; } = string.Empty;
    public string ExamType { get; set; } = string.Empty;
    public decimal MarksObtained { get; set; }
    public int TotalMarks { get; set; }
    public string? GradeValue { get; set; }
    public decimal Percentage { get; set; }
}
