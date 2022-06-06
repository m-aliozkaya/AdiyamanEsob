using Core.Utilities.Result.Abstract;
using Entities.Entity;

namespace Business.Abstract;

public interface IContactService
{
    Task<IDataResult<List<Contact>>> GetAllAsync();

    Task<IResult> SendMailAsync(Contact contact);

    Task<IDataResult<Contact>> GetByIdAsync(int id);

    Task<IResult> AddAsync(Contact contact);

    Task<IResult> UpdateAsync(Contact contact);

    Task<IResult> DeleteAsync(int id);
}