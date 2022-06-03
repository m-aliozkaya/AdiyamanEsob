using Core.Entities.Concrete;

namespace Entities.Entity;

public class Contact : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Message { get; set; }
    public DateTime Date { get; set; }
}