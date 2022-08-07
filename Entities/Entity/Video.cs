using System.ComponentModel.DataAnnotations;
using Core.Entities.Concrete;

namespace Entities.Entity;

public class Video : BaseEntity
{
    [Required]
    [Display(Name = "Video Başlığı")]
    public string Title { get; set; }
    [Required]
    [Display(Name = "Video Resmi")]
    public string Image { get; set; }
    [Required]
    [Display(Name = "Video Kodu")]
    public string VideoPath { get; set; }
    public DateTime CreationDate { get; set; }
}