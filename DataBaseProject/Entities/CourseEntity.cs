using System.ComponentModel.DataAnnotations;

namespace DataBaseProject.Entities;
public class CourseEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string CourseName { get; set; } = null!;
}
