using Core.Entities.Concrete;

namespace Entities.Entity;

public class Room : BaseEntity
{
    public bool IsCentre { get; set; }
    public string Title { get; set; }
    public string Leader { get; set; }
    public string Secretary { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string Website { get; set; }
}