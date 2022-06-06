using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Core.Entities.Concrete;

namespace Entities.Entity;

public class Project : BaseEntity
{
    [Required]
    [DisplayName("Proje Başlığı")]
    public string Title { get; set; }
    [DisplayName("Proje İçeriği")]
    public string Content { get; set; }
    [DisplayName("Proje Resmi")]
    public string Image { get; set; }
}