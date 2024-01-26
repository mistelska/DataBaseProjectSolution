using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseProject.Entities;
public class GradeEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(1)]
    public string Grade { get; set; } = null!;
}
