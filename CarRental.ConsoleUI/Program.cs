using CarRental.Business.Abstract;
using CarRental.Business.Concrete;
using CarRental.DataAccess.Concrete.EntityFramework;
using CarRental.DataAccess.Concrete.InMemory;
using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            CarTypeManager carTypeManager = new CarTypeManager(new EfCarTypeDal());
            DepartmentManager departmentManager = new DepartmentManager(new EfDepartmentDal());

            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            IndividualCustomerManager individualCustomerManager = new IndividualCustomerManager(new EfIndividualCustomerDal());
            EmployeeManager employeeManager = new EmployeeManager(new EfEmployeeDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            RentalCarManager rentalCarManager = new RentalCarManager(new EfRentalCarDal());

            CarRentalContext contex = new CarRentalContext();
            //contex.Database.EnsureCreated();


            //AddDefaultData(carManager, brandManager, colorManager, carTypeManager, departmentManager);
            //AddEmployee(employeeManager);
            //AddIndividualCustomer(individualCustomerManager);

            var car1 = carManager.GetById(1).Data;

            var rental = new Rental
            {
                EmployeeId = 1,
                CustomerId = 2,
                TotalPrice = 150,
                RentDate = DateTime.Now,
                //Cars = new List<Car> { car1 }
                RentedCars = new List<RentedCar> { new RentedCar { Car = car1 } }
            };

            //contex.Add(rental);
            //contex.SaveChanges();

         //   rentalManager.Add(rental);
         //   rentalManager.AddWithChild(rental);

            //var rentalList = rentalManager.GetAll();



            //var rentals = rentalManager.GetAll().Data.Where(r => r.Cars.Any(c => c.Id == 1));
            //foreach (var item in rentals)
            //{
            //    Console.WriteLine(item.TotalPrice);
            //}

            //var rentals2 = rentalManager.GetAll().Data.Where(r => r.RentedCars.Any(c => c.ReturnDate == null));
            //foreach (var item in rentals)
            //{
            //    Console.WriteLine(item.TotalPrice);
            //}
        }


        #region SeedData Try
        //using (var context = new CarRentalContext())
        //{
        //    ManyToManyRelationship(context);
        //}
        private static void ManyToManyRelationship(CarRentalContext context)
        {
            var car1 = new Car
            {
                BrandId = 1,
                ColorId = 1,
                CarTypeId = 1,
                Model = "Focus",
                Capacity = 4,
                ModelYear = "2018",
                DailyPrice = 150,
            };
            var car2 = new Car
            {
                Model = "Fiesta",
                ModelYear = "2012",
                ColorId = 1,
                BrandId = 1,
                CarTypeId = 1,
                Capacity = 4,
                DailyPrice = 100,

            };

            context.AddRange(
                //new Brand
                //{
                //    Name = "Ford"
                //},
                //new Color
                //{
                //    Name = "Siyah"
                //},
                //new CarType
                //{
                //    Name = "Hatchback"
                //},
                //new Department
                //{
                //    Name = "Satış"
                //},
                //new Employee
                //{
                //    IdentityNo = "23456789101",
                //    FirstName = "Ahmet",
                //    LastName = "Çalışkan",
                //    Gender = 'M',
                //    DOB = Convert.ToDateTime("12/24/1987"),
                //    Address = "İzmir",
                //    PhoneNumber = "05554443322",
                //    Email = "ahmet.caliskan@carRental.com",
                //    PasswordHash = "23456",
                //    DepartmentId = 1,
                //    Position = "Satis Temsilcisi",
                //    JoinDate = DateTime.Now
                //},
                //new IndividualCustomer
                //{
                //    IdentityNo = "12345678910",
                //    FirstName = "Ali",
                //    LastName = "Yaman",
                //    DOB = Convert.ToDateTime("10/10/1990"),
                //    PhoneNumber = "05556667788",
                //    Address = "İzmir",
                //    Email = "ali.yaman@carRental.com",
                //    PasswordHash = "12345",
                //    JoinDate = DateTime.Now
                //},
                new Rental
                {
                    CustomerId = 2,
                    EmployeeId = 1,
                    Cars = new List<Car> { car1 },
                    //RentDate = DateTime.Now,
                    TotalPrice = 100,
                    Discount = 0
                },
                new Rental
                {
                    CustomerId = 2,
                    EmployeeId = 1,
                    Cars = new List<Car> { car1, car2 },
                    //RentDate = DateTime.Now,
                });
            context.SaveChanges();
        }
        #endregion

        #region MyRegion

        private static void AddRental(CarManager carManager, RentalManager rentalManager)
        {
            var car1 = carManager.GetById(1).Data;
            var carList = new List<Car>();
            carList.Add(car1);

            var agreement = new Rental
            {
                CustomerId = 2,
                EmployeeId = 1,
                //RentDate = DateTime.Now,
                Cars = carList
            };
            var result = rentalManager.Add(agreement);
            Console.WriteLine(result.Message);
        }

        private static void AddDefaultData(CarManager carManager, BrandManager brandManager, ColorManager colorManager, CarTypeManager carTypeManager, DepartmentManager departmentManager)
        {
            var brand = new Brand
            {
               Name = "Ford"
            };
            brandManager.Add(brand);

            var color = new Color
            {
                Name = "Siyah"
            };
            colorManager.Add(color);

            var carType = new CarType
            {
                Name = "Hatchback"
            };
            carTypeManager.Add(carType);

            var car = new Car
            {
                Model = "Fiesta",
                ModelYear = "2012",
                ColorId = 1,
                BrandId = 1,
                CarTypeId = 1,
                Capacity = 4,
                DailyPrice = 100,

            };
            carManager.Add(car);

            var department = new Department
            {
                Name = "Satış"
            };
            departmentManager.Add(department);
        }

        private static void GetIndividualCustomerDetail(IndividualCustomerManager individualCustomerManager)
        {
            var result = individualCustomerManager.GetById(1).Data;
            Console.WriteLine(result.IdentityNo + " " + result.FirstName + " " + result.LastName + " " + result.Email + " " + result.PhoneNumber);
        }

        private static void DeleteUser(UserManager userManager)
        {
            var user = userManager.GetById(1).Data;
            var result = userManager.Delete(user);
            Console.WriteLine(result.Message);
        }

        private static void AddEmployee(EmployeeManager employeeManager)
        {
            var employee = new Employee
            {
                IdentityNo = "23456789101",
                FirstName = "Ahmet",
                LastName = "Çalışkan",
                Gender = 'M',
                DOB = Convert.ToDateTime("12/24/1987"),
                Address = "İzmir",
                PhoneNumber = "05554443322",
                Email = "ahmet.caliskan@carRental.com",
                PasswordHash = "23456",
                DepartmentId = 1,
                Position = "Satis Temsilcisi",
                JoinDate = DateTime.Now
            };
            employeeManager.Add(employee);
        }

        private static void AddIndividualCustomer(IndividualCustomerManager individualCustomerManager)
        {
            var customer = new IndividualCustomer
            {
                IdentityNo = "12345678910",
                FirstName = "Ali",
                LastName = "Yaman",
                DOB = Convert.ToDateTime("10/10/1990"),
                PhoneNumber = "05556667788",
                Address = "İzmir",
                Email = "ali.yaman@hotmail.com",
                PasswordHash = "12345",
                JoinDate = DateTime.Now
            };

            individualCustomerManager.Add(customer);
        }

        #endregion




    }
}
