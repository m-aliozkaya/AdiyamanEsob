using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Core.Entities.Abstract;

namespace Core.Entities.Concrete;

public class ContentEntity : BaseEntity, IContentEntity
{
    private const int MaxLength = 256;
    
    public bool IsActive { get; set; }
    
    public DateTime CreationDate { get; set; }
    
    [DisplayName("Başlık")]
    [Required]
    [MaxLength(MaxLength)]
    public string Title  { get; set; }
    
    [MaxLength(MaxLength)]
    public string SeoUrl  { get; set; }
    
    [DisplayName("İçerik")]
    [Required]
    public string Content  { get; set; }
    
    [DisplayName("Açıklama")]
    [Required]
    [MaxLength(MaxLength)]
    public string Description { get; set; }

    public ContentEntity()
    {
        CreationDate = DateTime.Now;
    }
}