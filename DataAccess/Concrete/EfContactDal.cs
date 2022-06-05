using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete;

public class EfContactDal : MyEntityRepositoryBase<Contact>, IContactDal
{
    public EfContactDal(EsobContext context) : base(context)
    {
    }

    public async Task<List<Contact>> GetAllByDateAsync()
    {
        return await Context.Contacts.OrderByDescending(x => x.Date).ToListAsync();
    }
}