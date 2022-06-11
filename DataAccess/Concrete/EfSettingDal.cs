using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete;

public class EfSettingDal : MyEntityRepositoryBase<Setting>, ISettingDal
{
    public EfSettingDal(EsobContext context) : base(context)
    {
    }
}