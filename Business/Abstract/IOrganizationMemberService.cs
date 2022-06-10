using Core.Utilities.Result.Abstract;
using Entities.Entity;

namespace Business.Abstract;

public interface IOrganizationMemberService
{
    Task<IDataResult<OrganizationMember>> GetAsync(int id);
    Task<IDataResult<List<OrganizationMember>>> GetListAsync(int organizationId);
    Task<IDataResult<OrganizationMember>> AddAsync(OrganizationMember organizationMember);
    Task<IDataResult<OrganizationMember>> UpdateAsync(OrganizationMember organizationmember);
    Task<IDataResult<OrganizationMember>> DeleteAsync(int id);
}