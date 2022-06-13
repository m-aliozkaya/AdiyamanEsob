using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Core.Utilities.Seo;
using DataAccess.Abstract;
using Entities.Entity;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete;

public class AboutArticleManager : IAboutArticleService
{
    private readonly IAboutArticleDal _aboutArticleDal;

    public AboutArticleManager(IAboutArticleDal aboutArticleDal)
    {
        _aboutArticleDal = aboutArticleDal;
    }

    public async Task<IDataResult<AboutArticle>> GetAsync(int id)
    {
        var result = await _aboutArticleDal.GetAsync(x => x.Id == id);

        if (result is not null)
        {
            return new SuccessDataResult<AboutArticle>(result);
        }

        return new ErrorDataResult<AboutArticle>();
    }

    public async Task<IDataResult<AboutArticle>> GetBySeoUrl(string seoUrl)
    {
        var result = await _aboutArticleDal.GetAsync(x => x.SeoUrl == seoUrl);

        if (result is not null)
        {
            return new SuccessDataResult<AboutArticle>(result);
        }

        return new ErrorDataResult<AboutArticle>();
    }

    public async Task<IDataResult<List<AboutArticle>>> GetListAsync()
    {
        var result = await _aboutArticleDal.GetAllAsync();
        return new SuccessDataResult<List<AboutArticle>>(result);
    }

    public async Task<IDataResult<List<AboutArticle>>> GetActiveListAsync()
    {
        var result = await _aboutArticleDal.GetQueryable().Where(x => x.IsActive).ToListAsync();
        return new SuccessDataResult<List<AboutArticle>>(result);
    }

    public async Task<IDataResult<AboutArticle>> AddAsync(AboutArticle circular)
    {
        circular.SeoUrl = SeoHelper.GetFriendlyTitle(circular.Title);
        await _aboutArticleDal.AddAsync(circular);
        return new SuccessDataResult<AboutArticle>(circular);
    }

    public async Task<IDataResult<AboutArticle>> UpdateAsync(AboutArticle circular)
    {
        if (circular is null) return new ErrorDataResult<AboutArticle>();
        circular.SeoUrl = SeoHelper.GetFriendlyTitle(circular.Title);
        await _aboutArticleDal.UpdateAsync(circular);
        return new SuccessDataResult<AboutArticle>(circular);
    }

    public async Task<IDataResult<AboutArticle>> DeleteAsync(int id)
    {
        var result = await GetAsync(id);

        if (!result.Success) return new ErrorDataResult<AboutArticle>();

        await _aboutArticleDal.DeleteAsync(result.Data);
        return new SuccessDataResult<AboutArticle>(result.Data);
    }
}