using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Core.Entities.Concrete;
using CarRental.Core.Utilities.Security.Hashing;
using CarRental.Core.Utilities.Security.JWT;
using CarRental.Entities.DTOs;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            if (claims.Success)
            {
                var accessToken = _tokenHelper.CreateToken(user, claims.Data);
                return new SuccessDataResult<AccessToken>(accessToken, Messages.Authentication.AccessTokenCreated);
            }
            return new ErrorDataResult<AccessToken>(claims.Message);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.User.NotFound());
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.Authentication.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck.Data, Messages.Authentication.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                UserName = userForRegisterDto.UserName,
                Email = userForRegisterDto.Email,
                //FirstName = userForRegisterDto.FirstName,
                //LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
                JoinDate = DateTime.Now
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.Authentication.UserRegistered);
        }

        /// <summary>
        /// Search for the given email in the users table. 
        /// </summary>
        /// <param name="email">User's email in a string type.</param>
        /// <returns>If found a matching user with the given email returns error result with an error message else  exists returns success result.</returns>
        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email).Data != null)
            {
                return new ErrorResult(Messages.Authentication.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
