using Core.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entity;

public class Setting:BaseEntity
{
    [Required]
    public string Facebook { get; set; }
    [Required]
    public string Instagram { get; set; }
    [Required]
    public string Youtube { get; set; }
    [Required]
    public string Twitter { get; set; }
    [Required]
    public string Linkedin { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    [Display(Name = "Telefon Numarası")]
    public string Phone { get; set; }
    [Required]
    public string Whatsapp { get; set; }
    [Required]
    [Display(Name ="Organizasyon Şeması")]
    public string OrganizationSchema { get; set; }
}