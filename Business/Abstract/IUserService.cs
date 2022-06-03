using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Entities.Dto;

namespace Business.Abstract;

public interface IUserService
{
    Task<IResult> AddAsync(User user);

    Task<IDataResult<User>> GetByUserName(string userName);
}