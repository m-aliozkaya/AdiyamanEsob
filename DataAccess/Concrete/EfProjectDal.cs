using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Entity;

namespace DataAccess.Concrete;

public class EfProjectDal : MyEntityRepositoryBase<Project>, IProjectDal
{
    public EfProjectDal(EsobContext context) : base(context)
    {
    }
}