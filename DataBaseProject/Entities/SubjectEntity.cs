using System.ComponentModel.DataAnnotations;

namespace DataBaseProject.Entities;
public class SubjectEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string SubjectName { get; set; } = null!;
}
