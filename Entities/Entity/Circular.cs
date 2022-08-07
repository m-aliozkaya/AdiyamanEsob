using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Core.Entities.Concrete;

namespace Entities.Entity;

public class Circular : BaseEntity
{
    [DisplayName("Genelge Yılı")]
    public int Year { get; set; }
    
    [Required]
    [DisplayName("Genelge Başlığı")]
    public string Title { get; set; }

    public int Priority { get; set; }
    public string File { get; set; }
}