using System.ComponentModel;
using Core.Entities.Concrete;

namespace Entities.Entity;

public class PresidentInfo : BaseEntity
{
    [DisplayName("İsim")]
    public string Name { get; set; }
    [DisplayName("Resim")]
    public string Image { get; set; }
    [DisplayName("Ünvan")]
    public string Title { get; set; }
    public string Twitter { get; set; }
    public string Facebook { get; set; }
    public string Instagram { get; set; }
    [DisplayName("Görevleri")]
    public string About { get; set; }
    [DisplayName("Özgeçmiş")]
    public string Resume { get; set; }
    [DisplayName("Projeleri")]
    public string Projects { get; set; }
    [DisplayName("Başkan'ın Mesajı")]
    public string Message { get; set; }
}