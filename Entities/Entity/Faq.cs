using Core.Entities.Concrete;

namespace Entities.Entity;

public class Faq : BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
}