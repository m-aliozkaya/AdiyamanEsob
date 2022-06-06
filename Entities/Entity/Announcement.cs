using System.ComponentModel.DataAnnotations;
using Core.Entities.Concrete;

namespace Entities.Entity;

public class Announcement : ContentEntity
{
    [Required]
    public string Image { get; set; }
}