using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Entity;

namespace DataAccess.Concrete;

public class EfVideoDal : MyEntityRepositoryBase<Video>, IVideoDal
{
    public EfVideoDal(EsobContext context) : base(context)
    {
    }
}