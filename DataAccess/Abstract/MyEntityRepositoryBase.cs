using Core.DataAccess.EntityFramework;
using Core.Entities;
using Core.Entities.Abstract;
using DataAccess.Context;

namespace DataAccess.Abstract;

public class MyEntityRepositoryBase<TEntity> : EfEntityRepositoryBase<TEntity, EsobContext>
    where TEntity : class, IEntity, new()
{
    public MyEntityRepositoryBase(EsobContext context) : base(context)
    {
    }
}