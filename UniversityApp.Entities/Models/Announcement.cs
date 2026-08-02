using System.ComponentModel.DataAnnotations;

namespace UniversityApp.Entities;

public class Announcement
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Content { get; set; } = string.Empty;

    [MaxLength(100)]
    public string PostedBy { get; set; } = string.Empty;

    [MaxLength(20)]
    public string Priority { get; set; } = "Medium"; // High, Medium, Low

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
