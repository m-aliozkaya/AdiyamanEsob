namespace Core.Entities.Abstract;

public interface IPassivable
{
    bool IsActive { get; set; }
}