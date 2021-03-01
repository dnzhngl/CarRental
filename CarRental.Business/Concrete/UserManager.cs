using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Core.Entities.Concrete;
using CarRental.DataAccess.Abstract;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            var result = _userDal.Any(u => u.Email == user.Email);
            if (!result)
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.User.Add());
            }
            return new ErrorResult(Messages.User.Exists(user.Email));
        }

        public IResult Delete(User user)
        {
            var result = _userDal.Any(u => u.Id == user.Id);
            if (result)
            {
                _userDal.Delete(user);
                return new SuccessResult(Messages.User.Delete());
            }
            return new ErrorResult(Messages.NotFound());
        }

        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.Count();
            if (result <= 0)
            {
                return new ErrorDataResult<List<User>>(Messages.NotFound());
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetByMail(string userEmail)
        {
            var result = _userDal.Any(u => u.Email == userEmail);
            if (result)
            {
                return new SuccessDataResult<User>(_userDal.Get(u => u.Email == userEmail));
            }
            return new ErrorDataResult<User>(Messages.NotFound());
        }

        public IDataResult<User> GetById(int userId)
        {
            var result = _userDal.Any(u => u.Id == userId);
            if (result)
            {
                return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
            }
            return new ErrorDataResult<User>(Messages.NotFound());
        }

        public IResult Update(User user)
        {
            var result = _userDal.Any(u => u.Id == user.Id);
            if (result)
            {
                _userDal.Update(user);
                return new SuccessResult(Messages.User.Update());
            }
            return new ErrorResult(Messages.Error());
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = _userDal.Any(u => u.Id == user.Id);
            if (result)
            {
                return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
            }
            return new ErrorDataResult<List<OperationClaim>>(Messages.Authorization.AuthorizationDenied());
        }
    }
}
