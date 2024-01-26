using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseProject.Entities;
public class TeacherEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = null!;
    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = null!;

    public int SubjectId { get; set; }
    public SubjectEntity Subject { get; set; }
}
