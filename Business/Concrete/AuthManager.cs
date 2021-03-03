using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService,ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
           var claims= _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken);
        }

        public IDataResult<User> Login(UserForLoginDto loginDto)
        {
            var userToCheck = _userService.GetByMail(loginDto.Email);
            if (userToCheck==null)
            {
                return new ErrorDataResult<User>(Messages.UserAlreadyExists);
            }
            if (!HashingHelper.VerifyPasswordHash(loginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>();
        }

        public IDataResult<User> Register(UserForRegisterDto registerDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            _userService.Add(new User
            {
                Email=registerDto.Email,
                 FirstName=registerDto.FirstName,
                  LastName=registerDto.LastName,
                   PasswordHash=passwordHash,
                   PasswordSalt=passwordSalt,
                   Status=true
            });
            return new SuccessDataResult<User>(Messages.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            var userToCheck = _userService.GetByMail(email);
            if (userToCheck!=null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
