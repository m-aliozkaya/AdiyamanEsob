using Core.Entities.Concrete;

namespace Entities.Entity;

public class Circular : BaseEntity
{
    public int Year { get; set; }
    public string Title { get; set; }
    public string File { get; set; }
}