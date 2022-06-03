using Core.Entities;
using Core.Entities.Concrete;

namespace Entities.Entity;

public class Book : BaseEntity
{
    public string Name { get; set; }
    public Author Author { get; set; }
}