using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseProject.Entities;
public class TeachersEntity
{
    [Key]
    public int TeachersId { get; set; }
    [ForeignKey(nameof(SubjectsEntity))]
    public int SubjectId { get; set; }
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = null!;
    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = null!;
    
    // Navigation
    public SubjectsEntity Subjects { get; set; }
}
