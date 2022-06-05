using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Entity;

namespace DataAccess.Concrete;

public class EfFaqDal : MyEntityRepositoryBase<Faq>, IFaqDal
{
    public EfFaqDal(EsobContext context) : base(context)
    {
    }
}