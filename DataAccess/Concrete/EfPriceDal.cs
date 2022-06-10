using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Entity;

namespace DataAccess.Concrete;

public class EfPriceDal : MyEntityRepositoryBase<Price>, IPriceDal
{
    public EfPriceDal(EsobContext context) : base(context)
    {
    }
}