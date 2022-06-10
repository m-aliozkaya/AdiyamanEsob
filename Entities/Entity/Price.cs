using System.ComponentModel;
using Core.Entities.Concrete;

namespace Entities.Entity;

public class Price : BaseEntity
{
    [DisplayName("Merkez Rayiç Mi")]
    public bool IsCentre { get; set; }
    [DisplayName("Karar Tarihi")]
    public DateTime DecisionDate { get; set; }
    [DisplayName("Tarife Başlığı")]
    public string Title { get; set; }
    [DisplayName("Tarife İçeriği")]
    public string Content { get; set; }
    [DisplayName("Karar Numarası")]
    public int DecisionNumber { get; set; }

}