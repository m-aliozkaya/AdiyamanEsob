using Core.Utilities.Result.Abstract;
using Entities.Entity;

namespace Business.Abstract;

public interface IActivityFieldService
{
    Task<IDataResult<ActivityField>> GetAsync(int id);
    Task<IDataResult<ActivityField>> GetBySeoUrlAsync(string seoUrl);
    Task<IDataResult<List<ActivityField>>> GetListAsync();
    Task<IDataResult<List<ActivityField>>> GetHome();
    
    Task<IDataResult<ActivityField>> AddAsync(ActivityField activityField);
    Task<IDataResult<ActivityField>> UpdateAsync(ActivityField activityField);
    Task<IDataResult<ActivityField>> DeleteAsync(int id);
}