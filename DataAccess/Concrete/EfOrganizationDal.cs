using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Entity;

namespace DataAccess.Concrete;

public class EfOrganizationDal : MyEntityRepositoryBase<Organization>, IOrganizationDal
{
    public EfOrganizationDal(EsobContext context) : base(context)
    {
    }
}