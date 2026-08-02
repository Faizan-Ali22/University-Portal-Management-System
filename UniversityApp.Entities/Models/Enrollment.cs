using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Entities;

public class Enrollment
{
    [Key]
    public int Id { get; set; }

    public int StudentId { get; set; }
    public int CourseId { get; set; }

    public DateTime EnrollmentDate { get; set; } = DateTime.Now;

    [MaxLength(20)]
    public string Status { get; set; } = "Active";

    // Navigation properties
    public virtual Student Student { get; set; } = null!;
    public virtual Course Course { get; set; } = null!;
}
