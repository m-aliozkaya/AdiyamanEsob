using System.ComponentModel.DataAnnotations;
using Core.Entities.Abstract;

namespace Core.Entities.Concrete;

public class ContentEntity : BaseEntity, IContentEntity
{
    private const int MaxLength = 256;
    
    public bool IsActive { get; set; }
    
    public DateTime CreationDate { get; set; }
    
    public string Title  { get; set; }
    
    public string SeoUrl  { get; set; }
    
    public string Content  { get; set; }
    
    [MaxLength(MaxLength)]
    public string Description { get; set; }
}