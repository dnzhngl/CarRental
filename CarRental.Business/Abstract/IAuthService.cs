using CarRental.Core.Entities.Concrete;
using CarRental.Core.Utilities.Security.JWT;
using CarRental.Entities.DTOs;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        /// <summary>
        /// Search for the given email in the users table. 
        /// </summary>
        /// <param name="email">User's email in a string type.</param>
        /// <returns>If found a matching user with the given email returns error result with an error message else  exists returns success result.</returns>
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
