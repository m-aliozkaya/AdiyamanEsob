using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Entity;

namespace DataAccess.Concrete;

public class EfRoomDal : MyEntityRepositoryBase<Room>, IRoomDal
{
    public EfRoomDal(EsobContext context) : base(context)
    {
    }
}