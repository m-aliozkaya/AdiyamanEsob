using Core.Entities.Concrete;

namespace Entities.Entity;

public class Video : BaseEntity
{
    public string Title { get; set; }
    public string Image { get; set; }
    public string VideoPath { get; set; }
    public DateTime CreationDate { get; set; }
}