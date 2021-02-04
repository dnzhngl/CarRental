using CarRental.Business.Concrete;
using CarRental.DataAccess.Concrete.EntityFramework;
using CarRental.DataAccess.Concrete.InMemory;
using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;

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

            var brandList = new List<Brand>
            {
                new Brand { Name ="Ford" },
                new Brand { Name = "Skoda" }
            };
            var colorList = new List<Color>
            {
                new Color { Name ="White" },
                new Color { Name = "Black"},
                new Color { Name = "Red"},
                new Color { Name = "Gray"},
            };
            var carTypes = new List<CarType>
            {
                new CarType{Name = "Hatchback"},
                new CarType{Name = "Sedan"},
                new CarType{Name = "Pickup"}
            };
            var carList = new List<Car>
            {
                new Car{BrandId =1, CarTypeId=1, ColorId=1, Capacity= 4, DailyPrice = 80, Model="Fiesta", ModelYear = "2012" },
                new Car{BrandId =1, CarTypeId=2, ColorId=2, Capacity= 4, DailyPrice = 100, Model="Focus", ModelYear = "2015" },
                new Car{BrandId =2, CarTypeId=2, ColorId=3, Capacity= 4, DailyPrice = 120, Model="SuperB", ModelYear = "2017" },

            };

            //foreach (var brand in brandList)
            //{
            //    brandManager.Add(brand);
            //}
            //foreach (var color in colorList)
            //{
            //    colorManager.Add(color);
            //}
            //foreach (var types in carTypes)
            //{
            //    carTypeManager.Add(types);
            //}
            //foreach (var car in carList)
            //{
            //    carManager.Add(car);
            //}

            //var cars = carManager.GetAll();
            //var cars = carManager.GetAllByBrandId(1);
            var cars = carManager.GetAllByColorId(1);
            foreach (var car in cars)
            {
                Console.WriteLine($"Model : {car.Model} \nModel Yılı : {car.ModelYear} \nFiyatı : {car.DailyPrice} \nKapasitesi : {car.Capacity} \nRengi: {colorManager.GetById(car.ColorId).Name} \nTipi : {carTypeManager.GetById(car.CarTypeId).Name} \n***************************");
            }


        }
    }
}
