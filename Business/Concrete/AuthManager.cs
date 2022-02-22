using Business.Abstract;
using Business.Constants;

using Core.Entities.Concrete;
using Core.Utility.Results;
using Core.Utility.Security.Hashing;
using Core.Utility.Security.Jwt;
using Entities.Dtos;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto registerDto, string password)
        {
            HashingHelper.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User
            {
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user);
        }
        public IDataResult<User> Login(UserForLoginDto loginDto)
        {
            var userCheck = _userService.GetByMail(loginDto.Email);
            if (userCheck == null) return new ErrorDataResult<User>(Messages.UserNotFound);
            if (!HashingHelper.VerifyPasswordHash(password: loginDto.Password, passwordHash: userCheck.PasswordHash, passwordSalt: userCheck.PasswordSalt))
                return new ErrorDataResult<User>(Messages.PasswordError);
            return new SuccessDataResult<User>(userCheck, Messages.SuccessfulLogin);
        }
        public IResult UserExist(string email)
        {
            if (_userService.GetByMail(email) != null)
                return new ErrorResult(Messages.UserAlreadyExist);
            return new SuccessResult();
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claim = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claim);
            return new SuccessDataResult<AccessToken>(accessToken);
        }
    }
}
