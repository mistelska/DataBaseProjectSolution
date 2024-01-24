using System.ComponentModel.DataAnnotations;

namespace DataBaseProject.Entities;
public class SubjectsEntity
{
    [Key]
    public int SubjectId { get; set; }
    [Required]
    [StringLength(50)]
    public string SubjectName { get; set; } = null!;

    // Navigation
    public ICollection<TeachersEntity> Teachers { get; set; }
}
