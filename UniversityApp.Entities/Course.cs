using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Entities;

public class Course
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required, MaxLength(20)]
    public string Code { get; set; } = string.Empty;

    [Range(1, 6)]
    public int CreditHours { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    [MaxLength(20)]
    public string? Semester { get; set; }

    public int? FacultyId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Navigation properties
    public virtual Faculty? Faculty { get; set; }
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();
    public virtual ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();
    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
}
