using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseProject.Entities;
public class StudentCoursesEntity
{
    [Key]
    public int StudentCourseId { get; set; }
    [ForeignKey(nameof(StudentsEntity))]
    public int StudentId { get; set; }
    [ForeignKey(nameof(CoursesEntity))]
    public int CourseId { get; set; }

    // Navigation
    public StudentsEntity Student {  get; set; }
    public CoursesEntity Courses { get; set; }
}
