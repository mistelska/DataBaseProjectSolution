using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseProject.Entities;
public class GradesEntity
{
    [Key]
    public int GradeId { get; set; }
    [ForeignKey(nameof(CoursesEntity))]
    public int CourseId {  get; set; }
    [ForeignKey(nameof(StudentsEntity))]
    public int StudentId { get; set; }
    [Required]
    [StringLength(1)]
    public string Grade { get; set; } = null!;

    // Navigation
    public CoursesEntity Course { get; set; }
    public StudentsEntity Student { get; set; }
}
