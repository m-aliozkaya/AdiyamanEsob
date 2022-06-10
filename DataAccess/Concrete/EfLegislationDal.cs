using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Entity;

namespace DataAccess.Concrete;

public class EfLegislationDal : MyEntityRepositoryBase<Legislation>, ILegislationDal
{
    public EfLegislationDal(EsobContext context) : base(context)
    {
    }
}