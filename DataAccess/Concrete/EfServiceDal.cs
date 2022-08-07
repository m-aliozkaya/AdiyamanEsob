using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Entity;

namespace DataAccess.Concrete;

public class EfServiceDal : MyEntityRepositoryBase<Service>, IServiceDal
{
    public EfServiceDal(EsobContext context) : base(context)
    {
    }
}