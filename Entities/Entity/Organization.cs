using Core.Entities.Concrete;

namespace Entities.Entity;

public class Organization : BaseEntity
{
    public string Name { get; set; }
    public string SeoUrl { get; set; }
}