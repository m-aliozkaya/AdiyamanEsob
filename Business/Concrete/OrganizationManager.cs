using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Core.Utilities.Seo;
using DataAccess.Abstract;
using Entities.Entity;

namespace Business.Concrete;

public class OrganizationManager : IOrganizationService
{
    private readonly IOrganizationDal _organizationDal;

    public OrganizationManager(IOrganizationDal organizationDal)
    {
        _organizationDal = organizationDal;
    }
    
    public async Task<IDataResult<Organization>> GetAsync(int id)
    {
        var result = await _organizationDal.GetAsync(x => x.Id == id);

        if (result is not null)
        {
            return new SuccessDataResult<Organization>(result); 
        }

        return new ErrorDataResult<Organization>();
    }

    public async Task<IDataResult<List<Organization>>> GetListAsync()
    {
        var result = await _organizationDal.GetAllAsync();
        return new SuccessDataResult<List<Organization>>(result);
    }

    public async Task<IDataResult<Organization>> AddAsync(Organization organization)
    {
        organization.SeoUrl=SeoHelper.GetFriendlyTitle(organization.Name);
        await _organizationDal.AddAsync(organization);
        return new SuccessDataResult<Organization>(organization);
    }

    public async Task<IDataResult<Organization>> UpdateAsync(Organization organization)
    {
        if (organization is null) return new ErrorDataResult<Organization>();
        
        await _organizationDal.UpdateAsync(organization);
        return new SuccessDataResult<Organization>(organization);
    }

    public async Task<IDataResult<Organization>> DeleteAsync(int id)
    {
        var result = await GetAsync(id);
        
        if (!result.Success) return new ErrorDataResult<Organization>();
        
        await _organizationDal.DeleteAsync(result.Data);
        return new SuccessDataResult<Organization>(result.Data);
    }
}