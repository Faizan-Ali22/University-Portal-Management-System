using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Entities;

public class Grade
{
    [Key]
    public int Id { get; set; }

    public int StudentId { get; set; }
    public int ExamId { get; set; }

    public decimal MarksObtained { get; set; }

    [MaxLength(5)]
    public string? GradeValue { get; set; } // A, A-, B+, B, B-, C+, C, D, F

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Navigation properties
    public virtual Student Student { get; set; } = null!;
    public virtual Exam Exam { get; set; } = null!;
}
