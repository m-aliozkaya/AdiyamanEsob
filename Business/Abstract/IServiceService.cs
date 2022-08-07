using Core.Utilities.Result.Abstract;
using Entities.Entity;

namespace Business.Abstract;

public interface IServiceService
{
    Task<IDataResult<Service>> GetAsync(int id);
    Task<IDataResult<Service>> GetBySeoUrlAsync(string seoUrl);
    Task<IDataResult<List<Service>>> GetListAsync();
    Task<IDataResult<List<Service>>> GetHome();
    Task<IDataResult<Service>> AddAsync(Service service);
    Task<IDataResult<Service>> UpdateAsync(Service service);
    Task<IDataResult<Service>> DeleteAsync(int id);
}