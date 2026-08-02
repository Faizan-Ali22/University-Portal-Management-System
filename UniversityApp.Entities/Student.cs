using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Entities;

public class Student
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(150)]
    public string Email { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string Department { get; set; } = string.Empty;

    public DateTime EnrollmentDate { get; set; } = DateTime.Now;

    [Range(0, 4.0)]
    public decimal? GPA { get; set; }

    [MaxLength(500)]
    public string? ProfileImageUrl { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Navigation properties
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
