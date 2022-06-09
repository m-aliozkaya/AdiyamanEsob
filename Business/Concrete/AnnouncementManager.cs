using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Core.Utilities.Seo;
using DataAccess.Abstract;
using Entities.Dto;
using Entities.Entity;

namespace Business.Concrete;

public class AnnouncementManager : IAnnouncementService
{
    private readonly IAnnouncementDal _announcementDal;

    public AnnouncementManager(IAnnouncementDal announcementDal)
    {
        _announcementDal = announcementDal;
    }

    public async Task<IDataResult<AnnouncementWithPageDetailDto>> GetAllByPage(int count, int? page)
    {
        var skipCount = 0;

        if (page is > 1)
        {
            skipCount = (page.Value - 1) * count;
        }

        var result = await _announcementDal.GetAllByPage(skipCount, count);
        var totalRecords = await _announcementDal.GetCountAsync();

        var announcementPageDetailDto = new AnnouncementWithPageDetailDto
        {
            Announcements = result,
            TotalRecors = totalRecords
        };

        return new SuccessDataResult<AnnouncementWithPageDetailDto>(announcementPageDetailDto);
    }

    public async Task<IDataResult<Announcement>> GetByIdAsync(int id)
    {
        var result = await _announcementDal.GetAsync(x => x.Id == id);

        if (result is not null)
        {
            return new SuccessDataResult<Announcement>(result);
        }

        return new ErrorDataResult<Announcement>();
    }

    public async Task<IDataResult<Announcement>> GetBySeoUrlAsync(string seoUrl)
    {
        var result = await _announcementDal.GetAsync(x => x.SeoUrl == seoUrl);

        if (result is not null)
        {
            return new SuccessDataResult<Announcement>(result);
        }

        return new ErrorDataResult<Announcement>();
    }

    public async Task<IDataResult<List<Announcement>>> GetAllAsync()
    {
        var result = await _announcementDal.GetAllAsync();
        return new SuccessDataResult<List<Announcement>>(result);
    }

    public async Task<IDataResult<Announcement>> AddAsync(Announcement announcement)
    {
        announcement.SeoUrl = SeoHelper.GetFriendlyTitle(announcement.Title);
        await _announcementDal.AddAsync(announcement);
        return new SuccessDataResult<Announcement>(announcement);
    }

    public async Task<IDataResult<Announcement>> UpdateAsync(Announcement announcement)
    {
        if (announcement is null) return new ErrorDataResult<Announcement>();
        announcement.SeoUrl = SeoHelper.GetFriendlyTitle(announcement.Title);
        await _announcementDal.UpdateAsync(announcement);
        return new SuccessDataResult<Announcement>(announcement);
    }

    public async Task<IDataResult<Announcement>> DeleteAsync(int id)
    {
        var result = await GetByIdAsync(id);

        if (!result.Success) return new ErrorDataResult<Announcement>();

        await _announcementDal.DeleteAsync(result.Data);
        return new SuccessDataResult<Announcement>(result.Data);
    }
}