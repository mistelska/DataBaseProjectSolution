using System.ComponentModel.DataAnnotations;

namespace DataBaseProject.Entities;
public class StudentsEntity
{
    [Key]
    public Guid StudentId { get; set; }

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

    //Navigation
    public ICollection<GradesEntity> Grades { get; set; }
    public ICollection<StudentCoursesEntity> StudentCourses { get;}
}
