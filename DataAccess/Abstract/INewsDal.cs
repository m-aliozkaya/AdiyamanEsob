using Core.DataAccess;
using Entities.Entity;

namespace DataAccess.Abstract;

public interface INewsDal : IEntityRepository<News>
{
    Task<List<News>> GetAllByPage(int skipCount, int count);
}