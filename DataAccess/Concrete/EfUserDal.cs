using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;

namespace DataAccess.Concrete
{
    public class EfUserDal : MyEntityRepositoryBase<User>, IUserDal
    {
        public EfUserDal(EsobContext context) : base(context)
        {
        }
    }
}