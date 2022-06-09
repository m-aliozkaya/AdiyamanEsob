using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete;

public class EfBlogDal :  MyEntityRepositoryBase<Blog>, IBlogDal
{
    public EfBlogDal(EsobContext context) : base(context)
    {
    }

    public Task<List<Blog>> GetAllByPage(int skipCount, int count)
    {
        return Context.Blogs.Skip(skipCount).Take(count).ToListAsync();
    }
}