using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Core.Utilities.Seo;
using DataAccess.Abstract;
using Entities.Entity;

namespace Business.Concrete;

public class ActivityFieldManager : IActivityFieldService
{
    private readonly IActivityFieldDal _activityFieldDal;

    public ActivityFieldManager(IActivityFieldDal activityFieldDal)
    {
        _activityFieldDal = activityFieldDal;
    }
    
    public async Task<IDataResult<ActivityField>> GetAsync(int id)
    {
        var result = await _activityFieldDal.GetAsync(x => x.Id == id);

        if (result is not null)
        {
            return new SuccessDataResult<ActivityField>(result); 
        }

        return new ErrorDataResult<ActivityField>();
    }
    
    public async Task<IDataResult<ActivityField>> GetBySeoUrlAsync(string seoUrl)
    {
        var result = await _activityFieldDal.GetAsync(x => x.SeoUrl == seoUrl);

        if (result is not null)
        {
            return new SuccessDataResult<ActivityField>(result);
        }

        return new ErrorDataResult<ActivityField>();
    }

    public async Task<IDataResult<List<ActivityField>>> GetListAsync()
    {
        var result = await _activityFieldDal.GetAllAsync();
        return new SuccessDataResult<List<ActivityField>>(result);
    }

    public async Task<IDataResult<List<ActivityField>>> GetHome()
    {
        var result = await _activityFieldDal.GetAllAsync(x => x.IsActive);
        return new SuccessDataResult<List<ActivityField>>(result);
    }

    public async Task<IDataResult<ActivityField>> AddAsync(ActivityField activityField)
    {
        activityField.SeoUrl = SeoHelper.GetFriendlyTitle(activityField.Title);
        await _activityFieldDal.AddAsync(activityField);
        return new SuccessDataResult<ActivityField>(activityField);
    }

    public async Task<IDataResult<ActivityField>> UpdateAsync(ActivityField activityField)
    {
        if (activityField is null) return new ErrorDataResult<ActivityField>();
        
        activityField.SeoUrl = SeoHelper.GetFriendlyTitle(activityField.Title);
        await _activityFieldDal.UpdateAsync(activityField);
        return new SuccessDataResult<ActivityField>(activityField);
    }

    public async Task<IDataResult<ActivityField>> DeleteAsync(int id)
    {
        var result = await GetAsync(id);
        
        if (!result.Success) return new ErrorDataResult<ActivityField>();
        
        await _activityFieldDal.DeleteAsync(result.Data);
        return new SuccessDataResult<ActivityField>(result.Data);
    }
}