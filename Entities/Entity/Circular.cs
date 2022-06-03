using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Core.Entities.Concrete;

namespace Entities.Entity;

public class Circular : BaseEntity
{
    public int Year { get; set; }
    
    [Required]
    [DisplayName("İsim")]
    public string Title { get; set; }
    public string File { get; set; }
}