using CarRental.Core.DataAccess;
using CarRental.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        /// <summary>
        /// Gets the given users claims for operations.
        /// </summary>
        /// <param name="user">User must be given in a User type.</param>
        /// <returns>Returns list of operations claims of the given user.</returns>
        List<OperationClaim> GetClaims(User user);
    }
}
