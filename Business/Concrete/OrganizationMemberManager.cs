using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Entity;

namespace Business.Concrete;

public class OrganizationMemberManager : IOrganizationMemberService
{
    private readonly IOrganizationMemberDal _organizationmemberDal;

    public OrganizationMemberManager(IOrganizationMemberDal organizationmemberDal)
    {
        _organizationmemberDal = organizationmemberDal;
    }

    public async Task<IDataResult<OrganizationMember>> GetAsync(int id)
    {
        var result = await _organizationmemberDal.GetAsync(x => x.Id == id);

        if (result is not null)
        {
            return new SuccessDataResult<OrganizationMember>(result);
        }

        return new ErrorDataResult<OrganizationMember>();
    }

    public async Task<IDataResult<List<OrganizationMember>>> GetListAsync(int organizationId)
    {
        var result = await _organizationmemberDal.GetAllAsync(x => x.OrganizationId == organizationId);
        return new SuccessDataResult<List<OrganizationMember>>(result);
    }

    public async Task<IDataResult<OrganizationMember>> AddAsync(OrganizationMember organizationMember)
    {
        await _organizationmemberDal.AddAsync(organizationMember);
        return new SuccessDataResult<OrganizationMember>(organizationMember);
    }

    public async Task<IDataResult<OrganizationMember>> UpdateAsync(OrganizationMember organizationmember)
    {
        if (organizationmember is null) return new ErrorDataResult<OrganizationMember>();

        await _organizationmemberDal.UpdateAsync(organizationmember);
        return new SuccessDataResult<OrganizationMember>(organizationmember);
    }

    public async Task<IDataResult<OrganizationMember>> DeleteAsync(int id)
    {
        var result = await GetAsync(id);

        if (!result.Success) return new ErrorDataResult<OrganizationMember>();

        await _organizationmemberDal.DeleteAsync(result.Data);
        return new SuccessDataResult<OrganizationMember>(result.Data);
    }
}