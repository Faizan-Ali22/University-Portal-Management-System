using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Entities;

public class Attendance
{
    [Key]
    public int Id { get; set; }

    public int StudentId { get; set; }
    public int CourseId { get; set; }

    public DateTime Date { get; set; }

    [Required, MaxLength(20)]
    public string Status { get; set; } = "Present"; // Present, Absent, Late

    // Navigation properties
    public virtual Student Student { get; set; } = null!;
    public virtual Course Course { get; set; } = null!;
}
