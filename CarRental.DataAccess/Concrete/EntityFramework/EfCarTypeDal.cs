using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CarRental.DataAccess.Concrete.EntityFramework
{
    public class EfCarTypeDal : ICarTypeDal
    {
        public void Add(CarType entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(CarType entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public CarType Get(Expression<Func<CarType, bool>> filter)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.Set<CarType>().SingleOrDefault(filter);

            }
        }

        public List<CarType> GetAll(Expression<Func<CarType, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return filter == null ? context.Set<CarType>().ToList() : context.Set<CarType>().Where(filter).ToList();
            }
        }

        public void Update(CarType entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
