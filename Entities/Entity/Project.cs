using Core.Entities.Concrete;

namespace Entities.Entity;

public class Project : BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string Image { get; set; }
}