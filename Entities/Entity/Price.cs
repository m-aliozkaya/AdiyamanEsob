using Core.Entities.Concrete;

namespace Entities.Entity;

public class Price : BaseEntity
{
    public bool IsCentre { get; set; }
    public DateTime DecisionDate { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}