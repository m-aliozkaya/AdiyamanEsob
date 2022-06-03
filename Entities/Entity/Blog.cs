using Core.Entities.Concrete;

namespace Entities.Entity;

public class Blog : ContentEntity
{
    public string Image { get; set; }
    public bool IsHome { get; set; }
}