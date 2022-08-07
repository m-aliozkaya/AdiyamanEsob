using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Entity;

namespace DataAccess.Concrete;

public class EfPresidentDal : MyEntityRepositoryBase<PresidentInfo>, IPresidentDal
{
    public EfPresidentDal(EsobContext context) : base(context)
    {
    }
}