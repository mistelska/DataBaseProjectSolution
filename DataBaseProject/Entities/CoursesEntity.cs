using System.ComponentModel.DataAnnotations;

namespace DataBaseProject.Entities;
public class CoursesEntity
{
    [Key]
    public int CourseId { get; set; }

    [Required]
    [StringLength(50)]
    public string CourseName { get; set; } = null!;

    public ICollection<GradesEntity> Grades { get; set; }
    public ICollection<StudentCoursesEntity> StudentCourses { get; set; }
}
