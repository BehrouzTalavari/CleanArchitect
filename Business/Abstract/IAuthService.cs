using Core.Entities.Concrete;
using Core.Utility.Results;
using Core.Utility.Security.Jwt;
using Entities.Dtos;

namespace Business.Abstract
{
    internal interface IAuthService
    {
        IDataResult<AccessToken> CreateAccessToken(User user);
        IDataResult<User> Login(UserForLoginDto loginDto);
        IDataResult<User> Register(UserForRegisterDto registerDto, string password);
        IResult UserExist(string email);
    }
}
