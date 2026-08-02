using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Entities;

public class Exam
{
    [Key]
    public int Id { get; set; }

    public int CourseId { get; set; }

    [Required, MaxLength(50)]
    public string ExamType { get; set; } = string.Empty; // Midterm, Final, Quiz

    public DateTime Date { get; set; }

    public int TotalMarks { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Navigation properties
    public virtual Course Course { get; set; } = null!;
    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
