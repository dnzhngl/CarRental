using CarRental.Core.Entities.Concrete;
using CarRental.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.DataAccess.Concrete.EntityFramework
{
    public class CarRentalContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=CarRental;Trusted_Connection=True;");
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CorporateCustomer> CorporateCustomers { get; set; }
        public DbSet<IndividualCustomer> IndividualCustomers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        #region Many to Manyr Relationship with Cars and Rentals
        //public DbSet<RentedCar> RentedCars { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Car>()
        //    .HasMany(c => c.Rentals)
        //    .WithMany(r => r.Cars)
        //    .UsingEntity<RentedCar>(
        //        j => j.HasOne(cr => cr.Rental).WithMany(c => c.RentedCars),
        //        j => j.HasOne(cr => cr.Car).WithMany(c => c.RentedCars));

        //}
        #endregion
    }
}
