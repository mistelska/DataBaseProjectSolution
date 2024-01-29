using System.ComponentModel.DataAnnotations;

namespace DataBaseProject.Entities;
public class StudentEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = null!;
    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = null!;
    [Required]
    [StringLength(50)]
    public string Email { get; set; } = null!;
    [StringLength(50)]
    public string? PhoneNumber { get; set; }
    public int CourseId { get; set; }
    public CourseEntity Course { get; set; } = null!;
    public int GradeId { get; set; }
    public GradeEntity Grade { get; set; } = null!;
}
