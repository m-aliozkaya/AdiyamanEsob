using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Entity;

namespace DataAccess.Concrete;

public class EfActivityFieldDal : MyEntityRepositoryBase<ActivityField>, IActivityFieldDal
{
    public EfActivityFieldDal(EsobContext context) : base(context)
    {
    }
}