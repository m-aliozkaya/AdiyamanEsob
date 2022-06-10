using Core.DataAccess;
using Entities.Entity;

namespace DataAccess.Abstract;

public interface IBlogDal : IEntityRepository<Blog>
{
    Task<List<Blog>> GetAllByPage(int skipCount, int count);
}