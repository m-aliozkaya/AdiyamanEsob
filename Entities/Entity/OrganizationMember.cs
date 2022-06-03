using Core.Entities.Concrete;

namespace Entities.Entity;

public class OrganizationMember : BaseEntity
{
    public int OrganizationId { get; set; }
    public Organization Organization { get; set; }
    
    public string Name { get; set; }
    public string Title { get; set; }
    public string Image { get; set; }
}