namespace Core.Entities.Abstract;

public interface IContentEntity : IPassivable
{
    DateTime CreationDate { get; set; }
    string Title  { get; set; }
    string SeoUrl  { get; set; }
    string Content  { get; set; }
    string Description { get; set; }
}