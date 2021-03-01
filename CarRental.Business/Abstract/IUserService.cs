using CarRental.Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);
        IDataResult<User> GetByMail(string userEmail);
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);

        IDataResult<List<OperationClaim>> GetClaims(User user);

    }
}
