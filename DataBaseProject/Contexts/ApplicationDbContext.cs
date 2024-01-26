using DataBaseProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DataBaseProject.Contexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public virtual DbSet<CourseEntity> Courses { get; set; }
    public virtual DbSet<GradeEntity> Grades { get; set;}
    public virtual DbSet<StudentEntity> Students { get; set;} 
    public virtual DbSet<SubjectEntity> Subjects { get; set; }    
    public virtual DbSet<TeacherEntity> Teachers { get; set; }    
}
