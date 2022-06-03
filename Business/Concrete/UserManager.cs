using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Dto;

namespace Business.Concrete;

public class UserManager : IUserService
{
    private readonly IUserDal _userDal;
    private readonly IMapper _mapper;

    public UserManager(IUserDal userDal, IMapper mapper)
    {
        _userDal = userDal;
        _mapper = mapper;
    }

    public async Task<IResult> AddAsync(User user)
    {
        await _userDal.AddAsync(user);
        return new SuccessResult();
    }

    public async Task<IDataResult<User>> GetByUserName(string userName)
    {
        var result = await _userDal.GetAsync(u => u.UserName == userName);
        return new SuccessDataResult<User>(result);
    }
}