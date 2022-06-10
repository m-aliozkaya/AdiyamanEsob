using Core.DataAccess;
using Entities.Entity;

namespace DataAccess.Abstract;

public interface IAnnouncementDal : IEntityRepository<Announcement>
{
    Task<List<Announcement>> GetAllByPage(int skipCount, int count);
}