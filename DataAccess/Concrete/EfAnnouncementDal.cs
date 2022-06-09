using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete;

public class EfAnnouncementDal :  MyEntityRepositoryBase<Announcement>, IAnnouncementDal
{
    public EfAnnouncementDal(EsobContext context) : base(context)
    {
    }

    public Task<List<Announcement>> GetAllByPage(int skipCount, int count)
    {
        return Context.Announcements.Skip(skipCount).Take(count).ToListAsync();
    }
}