using Core.Entities.Concrete;

namespace Entities.Entity;

public class Setting:BaseEntity
{
    public string Facebook { get; set; }
    public string Instagram { get; set; }
    public string Youtube { get; set; }
    public string Twitter { get; set; }
    public string Linkedin { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Whatsapp { get; set; }
}