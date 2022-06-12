using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Core.Utilities.Seo;
using DataAccess.Abstract;
using Entities.Entity;

namespace Business.Concrete;

public class LegislationManager : ILegislationService
{
    private readonly ILegislationDal _legislationDal;

    public LegislationManager(ILegislationDal legislationDal)
    {
        _legislationDal = legislationDal;
    }
    
    public async Task<IDataResult<Legislation>> GetAsync(int id)
    {
        var result = await _legislationDal.GetAsync(x => x.Id == id);

        if (result is not null)
        {
            return new SuccessDataResult<Legislation>(result); 
        }

        return new ErrorDataResult<Legislation>();
    }

    public async Task<IDataResult<Legislation>> GetBySeoUrl(string seoUrl)
    {
        var result = await _legislationDal.GetAsync(x => x.SeoUrl == seoUrl);

        if (result is not null)
        {
            return new SuccessDataResult<Legislation>(result); 
        }

        return new ErrorDataResult<Legislation>();
    }

    public async Task<IDataResult<List<Legislation>>> GetListAsync()
    {
        var result = await _legislationDal.GetAllAsync();
        return new SuccessDataResult<List<Legislation>>(result);
    }

    public async Task<IDataResult<Legislation>> AddAsync(Legislation circular)
    {
        circular.SeoUrl = SeoHelper.GetFriendlyTitle(circular.Title);
        await _legislationDal.AddAsync(circular);
        return new SuccessDataResult<Legislation>(circular);
    }

    public async Task<IDataResult<Legislation>> UpdateAsync(Legislation circular)
    {
        if (circular is null) return new ErrorDataResult<Legislation>();
        circular.SeoUrl = SeoHelper.GetFriendlyTitle(circular.Title);
        await _legislationDal.UpdateAsync(circular);
        return new SuccessDataResult<Legislation>(circular);
    }

    public async Task<IDataResult<Legislation>> DeleteAsync(int id)
    {
        var result = await GetAsync(id);
        
        if (!result.Success) return new ErrorDataResult<Legislation>();
        
        await _legislationDal.DeleteAsync(result.Data);
        return new SuccessDataResult<Legislation>(result.Data);
    }
}