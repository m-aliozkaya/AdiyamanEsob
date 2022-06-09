using Core.Utilities.Result.Abstract;
using Entities.Dto;
using Entities.Entity;

namespace Business.Abstract;

public interface IAnnouncementService
{
    Task<IDataResult<List<Announcement>>> GetAllAsync();

    Task<IDataResult<AnnouncementWithPageDetailDto>> GetAllByPage(int count, int? page = 1);
    
    Task<IDataResult<Announcement>> GetByIdAsync(int id);
    Task<IDataResult<Announcement>> GetBySeoUrlAsync(string seoUrl);

    Task<IDataResult<Announcement>> AddAsync(Announcement announcement);

    Task<IDataResult<Announcement>> UpdateAsync(Announcement announcement);

    Task<IDataResult<Announcement>> DeleteAsync(int id);
}