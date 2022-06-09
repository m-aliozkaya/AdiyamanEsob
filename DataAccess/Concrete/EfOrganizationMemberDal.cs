using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Entity;

namespace DataAccess.Concrete;

public class EfOrganizationMemberDal : MyEntityRepositoryBase<OrganizationMember>, IOrganizationMemberDal
{
    public EfOrganizationMemberDal(EsobContext context) : base(context)
    {
    }
}