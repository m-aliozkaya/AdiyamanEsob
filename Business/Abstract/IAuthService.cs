using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Entities.Dto;

namespace Business.Abstract;

public interface IAuthService
{
    Task<IResult> RegisterAsync(UserForRegisterDto userForRegisterDto);

    Task<IResult> LoginAsync(UserForLoginDto userForLoginDto);
}