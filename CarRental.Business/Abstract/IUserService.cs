using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(int userId);
        User GetByEmail(string userEmail);
        void Add(User user);
        void Delete(User user);
        void Update(User user);
    }
}
