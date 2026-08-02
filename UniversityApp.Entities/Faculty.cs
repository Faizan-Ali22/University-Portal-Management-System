using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Entities;

public class Faculty
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(150)]
    public string Email { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string Department { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? Designation { get; set; }

    public DateTime? HireDate { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Navigation properties
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
