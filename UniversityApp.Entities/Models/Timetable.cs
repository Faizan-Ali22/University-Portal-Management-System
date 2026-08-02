using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Entities;

public class Timetable
{
    [Key]
    public int Id { get; set; }

    public int CourseId { get; set; }

    [Required, MaxLength(20)]
    public string DayOfWeek { get; set; } = string.Empty;

    [Required, MaxLength(10)]
    public string StartTime { get; set; } = string.Empty;

    [Required, MaxLength(10)]
    public string EndTime { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string Room { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Navigation properties
    public virtual Course Course { get; set; } = null!;
}
