using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Abstract
{
    public interface IColorService
    {
        List<Color> GetAll();
        Color GetById(int colorId);
        void Add(Color color);
        void Delete(Color color);
        void Update(Color color);
    }
}
