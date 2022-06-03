using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Core.Utilities.Security.Hashing;
using Entities.Dto;

namespace Business.Concrete;

public class AuthManager : IAuthService
{
    private readonly IUserService _userService;

    public AuthManager(IUserService userService)
    {
        _userService = userService;
    }
    
    public async Task<IResult> RegisterAsync(UserForRegisterDto userForRegisterDto)
    {
        HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out var passwordHash,
            out var passwordSalt);
       
        var user = new User
        {
            UserName = userForRegisterDto.Username,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };
        
        await _userService.AddAsync(user);
        
        return new SuccessResult("Kayıt oldu");
    }

    public async Task<IResult> LoginAsync(UserForLoginDto userForLoginDto)
    {
        var userToCheck = (await _userService.GetByUserName(userForLoginDto.Username)).Data;
        
        if (HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
        {
            return new SuccessResult("Başarılı giriş");
        }

        return new ErrorResult("Parola hatası");
    }
}