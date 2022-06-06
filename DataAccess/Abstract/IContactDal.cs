using Core.DataAccess;
using Entities.Entity;

namespace DataAccess.Abstract;

public interface IContactDal : IEntityRepository<Contact>
{
    Task<List<Contact>> GetAllByDateAsync();
}