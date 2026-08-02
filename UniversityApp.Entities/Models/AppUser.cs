using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Entities;

public class AppUser
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(150)]
    public string Email { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string FullName { get; set; } = string.Empty;

    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    [MaxLength(20)]
    public string Role { get; set; } = "Admin"; // Admin, Faculty, Student

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
