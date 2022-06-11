using Core.Utilities.Result.Abstract;
using Entities.Entity;

namespace Business.Abstract;

public interface IOrganizationService
{
    Task<IDataResult<Organization>> GetAsync(int id);
    Task<IDataResult<Organization>> GetAsync(string seoUrl);
    Task<IDataResult<List<Organization>>> GetListAsync();
    Task<IDataResult<Organization>> AddAsync(Organization organization);
    Task<IDataResult<Organization>> UpdateAsync(Organization organization);
    Task<IDataResult<Organization>> DeleteAsync(int id);
}