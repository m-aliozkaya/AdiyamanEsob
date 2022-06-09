using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Core.Utilities.Seo;
using DataAccess.Abstract;
using Entities.Dto;
using Entities.Entity;

namespace Business.Concrete;

public class NewsManager : INewsService
{
    private readonly INewsDal _newsDal;

    public NewsManager(INewsDal newsDal)
    {
        _newsDal = newsDal;
    }

    public async Task<IDataResult<NewsWithPageDetailDto>> GetAllByPage(int count, int? page)
    {
        var skipCount = 0;

        if (page is > 1)
        {
            skipCount = (page.Value - 1) * count;
        }

        var result = await _newsDal.GetAllByPage(skipCount, count);
        var totalRecords = await _newsDal.GetCountAsync();

        var newsPageDetailDto = new NewsWithPageDetailDto
        {
            News = result,
            TotalRecors = totalRecords
        };

        return new SuccessDataResult<NewsWithPageDetailDto>(newsPageDetailDto);
    }

    public async Task<IDataResult<News>> GetByIdAsync(int id)
    {
        var result = await _newsDal.GetAsync(x => x.Id == id);

        if (result is not null)
        {
            return new SuccessDataResult<News>(result);
        }

        return new ErrorDataResult<News>();
    }

    public async Task<IDataResult<News>> GetBySeoUrlAsync(string seoUrl)
    {
        var result = await _newsDal.GetAsync(x => x.SeoUrl == seoUrl);

        if (result is not null)
        {
            return new SuccessDataResult<News>(result);
        }

        return new ErrorDataResult<News>();
    }

    public async Task<IDataResult<List<News>>> GetAllAsync()
    {
        var result = await _newsDal.GetAllAsync();
        return new SuccessDataResult<List<News>>(result);
    }

    public async Task<IDataResult<News>> AddAsync(News news)
    {
        news.SeoUrl = SeoHelper.GetFriendlyTitle(news.Title);
        await _newsDal.AddAsync(news);
        return new SuccessDataResult<News>(news);
    }

    public async Task<IDataResult<News>> UpdateAsync(News news)
    {
        if (news is null) return new ErrorDataResult<News>();
        news.SeoUrl = SeoHelper.GetFriendlyTitle(news.Title);
        await _newsDal.UpdateAsync(news);
        return new SuccessDataResult<News>(news);
    }

    public async Task<IDataResult<News>> DeleteAsync(int id)
    {
        var result = await GetByIdAsync(id);

        if (!result.Success) return new ErrorDataResult<News>();

        await _newsDal.DeleteAsync(result.Data);
        return new SuccessDataResult<News>(result.Data);
    }
}