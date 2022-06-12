using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Entity;

namespace DataAccess.Concrete;

public class EfCircularDal : MyEntityRepositoryBase<Circular>, ICircularDal
{
    public EfCircularDal(EsobContext context) : base(context)
    {
    }

}