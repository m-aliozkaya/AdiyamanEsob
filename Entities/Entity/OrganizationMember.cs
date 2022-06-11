using System.ComponentModel;
using Core.Entities.Concrete;

namespace Entities.Entity;

public class OrganizationMember : BaseEntity
{
    public int OrganizationId { get; set; }
    public Organization Organization { get; set; }
    
    [DisplayName("Üye İsmi")]
    public string Name { get; set; }
    
    [DisplayName("Üye Başlığı")]
    public string Title { get; set; }
    
    [DisplayName("Üye Ünvanı")]
    public string Degree { get; set; }
    
    [DisplayName("Üye Resmi")]
    public string Image { get; set; }
}