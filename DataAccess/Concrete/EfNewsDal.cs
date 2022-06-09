using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete;

public class EfNewsDal :  MyEntityRepositoryBase<News>, INewsDal
{
    public EfNewsDal(EsobContext context) : base(context)
    {
    }

    public Task<List<News>> GetAllByPage(int skipCount, int count)
    {
        return Context.News.Skip(skipCount).Take(count).ToListAsync();
    }
}