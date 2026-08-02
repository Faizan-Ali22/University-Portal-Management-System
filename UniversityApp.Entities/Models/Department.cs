using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Entities.Models;

public class Department
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(20)]
    public string Code { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? HeadOfDepartment { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
