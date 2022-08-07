using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Core.Entities.Concrete;

namespace Entities.Entity;

public class Faq : BaseEntity
{
    [DisplayName("Soru Başlığı")]
    [Required]
    public string Title { get; set; }
    [DisplayName("Soru Başlığı")]
    [Required]
    public string Content { get; set; }
    [DisplayName("Durum")]
    public bool IsActive { get; set; }

    public string SeoUrl { get; set; }
}