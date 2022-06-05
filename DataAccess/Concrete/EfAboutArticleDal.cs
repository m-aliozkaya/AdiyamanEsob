using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Entity;

namespace DataAccess.Concrete;

public class EfAboutArticleDal : MyEntityRepositoryBase<AboutArticle>, IAboutArticleDal
{
    public EfAboutArticleDal(EsobContext context) : base(context)
    {
    }
}