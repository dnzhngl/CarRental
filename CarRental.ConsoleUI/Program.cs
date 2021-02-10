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
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            EmployeeManager employeeManager = new EmployeeManager(new EfEmployeeDal());
            DepartmentManager departmentManager = new DepartmentManager(new EfDepartmentDal());

            // RegisterCustomer(userManager, customerManager);
            // RegisterEmployee(userManager, employeeManager, departmentManager);

            // DepartmentAdd(departmentManager);
            // GetAllCarsDetails(carManager);
            // GetCarDetail(carManager, 2);


            // AddColor(colorManager);
            // UpdateColor(colorManager);
            // UpdateCar(carManager, carTypeManager, brandManager, colorManager);

            // DeleteColor(colorManager);
        }


        private static void RegisterCustomer(UserManager userManager, CustomerManager customerManager)
        {
            var customerType = CorporateOrIndividual();
            if (customerType == "1")
            {
                RegisterIndividualCustomer(userManager, customerManager);
            }
            else if (customerType == "2")
            {
                RegisterCorporateCustomer(userManager, customerManager);
            }
        }
        private static string CorporateOrIndividual()
        {
            Console.WriteLine("Kişisel hesap oluşturmak için 1'e, Kurumsal hesap oluşturmak için 2'ye basınız.");
            var result = Console.ReadLine();

            if (result == "1" || result == "2")
            {
                return result;
            }
            Console.WriteLine("Yanlış giriş yaptınız. Lütfen tekrar deneyiniz.");
            return CorporateOrIndividual();
        }
        private static void RegisterIndividualCustomer(UserManager userManager, CustomerManager customerManager)
        {
            Console.WriteLine("Sisteme kayıt olmak için lütfen aşağıdaki bilgileri doldurunuz.");

            IndividualCustomer individualCustomer = new IndividualCustomer();
            Console.WriteLine("TC Kimlik No: ");
            individualCustomer.IdentityNo = Console.ReadLine();
            Console.WriteLine("Ad: ");
            individualCustomer.FirstName = Console.ReadLine();
            Console.WriteLine("Soyad: ");
            individualCustomer.LastName = Console.ReadLine();
            Console.WriteLine("Doğum Tarihi (gg/aa/yyyy): ");
            individualCustomer.DOB = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Telefon Numarası: ");
            individualCustomer.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Adres Bilgisi: ");
            individualCustomer.Address = Console.ReadLine();

            User user = new User();
            Console.WriteLine("E-mail: ");
            user.Email = Console.ReadLine();
            Console.WriteLine("Şifre: ");
            user.PasswordHash = Console.ReadLine();
            user.JoinDate = DateTime.Now;

            userManager.Add(user);
            customerManager.Add(individualCustomer);

        }
        private static void RegisterCorporateCustomer(UserManager userManager, CustomerManager customerManager)
        {
            Console.WriteLine("Sisteme kayıt olmak için lütfen aşağıdaki bilgileri doldurunuz.");

            CorporateCustomer corporateCustomer = new CorporateCustomer();
            Console.WriteLine("Şirket Adı: ");
            corporateCustomer.CompanyName = Console.ReadLine();
            Console.WriteLine("Vergi Numarası: ");
            corporateCustomer.TaxNumber = Console.ReadLine();
            Console.WriteLine("Telefon Numarası: ");
            corporateCustomer.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Adres Bilgisi: ");
            corporateCustomer.Address = Console.ReadLine();

            User user = new User();
            Console.WriteLine("Yetkili Kişinin E-mail Adresi: ");
            user.Email = Console.ReadLine();
            Console.WriteLine("Şifre: ");
            user.PasswordHash = Console.ReadLine();
            user.JoinDate = DateTime.Now;

            userManager.Add(user);
            customerManager.Add(corporateCustomer);

        }

        private static void RegisterEmployee(UserManager userManager, EmployeeManager employeeManager, DepartmentManager departmentManager)
        {
            Console.WriteLine("Sisteme çalışan kayıt etmek için lütfen aşağıdaki bilgileri doldurunuz.");

            Employee employee = new Employee();
            Console.WriteLine("TC Kimlik No: ");
            employee.IdentityNo = Console.ReadLine();
            Console.WriteLine("Ad: ");
            employee.FirstName = Console.ReadLine();
            Console.WriteLine("Soyad: ");
            employee.LastName = Console.ReadLine();
            Console.WriteLine("Doğum Tarihi (ay.gün.yıl): ");
            employee.DOB = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Cinsiyet (Kadın için F, Erkek için M giriniz): ");
            employee.Gender = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Telefon Numarası: ");
            employee.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Adres Bilgisi: ");
            employee.Address = Console.ReadLine();

            Console.WriteLine("Çalıştığı Departman: ");
            var departmentName = Console.ReadLine();
            employee.DepartmantId = departmentManager.GetByName(departmentName).Id;
            Console.WriteLine("Çalışan Pozisyonu: ");
            employee.Position = Console.ReadLine();

            Console.WriteLine("E-mail: ");
            employee.Email = Console.ReadLine();
            Console.WriteLine("Şifre: ");
            employee.PasswordHash = Console.ReadLine();
            employee.JoinDate = DateTime.Now;

            User user = new User
            {
                Email = employee.Email,
                PasswordHash = employee.PasswordHash,
                JoinDate = employee.JoinDate
            };

            //User user = new User();
            //Console.WriteLine("E-mail: ");
            //user.Email = Console.ReadLine();
            //Console.WriteLine("Şifre: ");
            //user.PasswordHash = Console.ReadLine();
            //user.JoinDate = DateTime.Now;
            userManager.Add(user);
            var userId = userManager.GetByEmail(user.Email).Id;
            employee.Id = userId;
            
            employeeManager.Add(employee);
            Console.WriteLine("Çalışan sisteme başarıyla kaydedildi.");
        }

        private static void AddDepartment(DepartmentManager departmentManager)
        {
            Console.WriteLine("Sisteme departman eklemek içi lütfen istenilen bilgileri giriniz.");

            Department department = new Department();
            Console.WriteLine("Departman Adı : ");
            department.Name = Console.ReadLine();

            departmentManager.Add(department);
        }
        private static void AddCar(CarManager carManager, CarTypeManager carTypeManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("Eklemek istediğiniz arabanın özelliklerini giriniz.");

            Car car = new Car();
            Console.WriteLine("Marka: ");
            var brandName = Console.ReadLine();
            car.BrandId = brandManager.GetByName(brandName).Id;
            Console.WriteLine("Model: ");
            car.Model = Console.ReadLine();
            Console.WriteLine("Model yılı: ");
            car.ModelYear = Console.ReadLine();
            Console.WriteLine("Kapasite: ");
            car.Capacity = (byte)int.Parse(Console.ReadLine());
            Console.WriteLine("Araba Tipi: ");
            var carTypeName = Console.ReadLine();
            car.CarTypeId = carTypeManager.GetByName(carTypeName).Id;
            Console.WriteLine("Adet: ");
            car.QuantityInStock = int.Parse(Console.ReadLine());
            Console.WriteLine("Renk: ");
            var colorName = Console.ReadLine();
            car.ColorId = colorManager.GetByName(colorName).Id;
            Console.WriteLine("Günlük Fiyat: ");
            car.DailyPrice = double.Parse(Console.ReadLine());
            Console.WriteLine("Açıklama: ");
            car.Description = Console.ReadLine();

            carManager.Add(car);
        }
        private static void AddCarType(CarTypeManager carTypeManager)
        {
            CarType carType = new CarType();
            Console.WriteLine("Araba tipi eklemek için gerekli olan bilgileri doldurunuz.");
            Console.WriteLine("Tip Adı: ");
            carType.Name = Console.ReadLine();
            carTypeManager.Add(carType);
            Console.WriteLine($"{carType.Name} sisteme başarıyla eklendi.");
        }
        private static void AddBrand(BrandManager brandManager)
        {
            Brand brand = new Brand();
            Console.WriteLine("Marka eklemek için gerekli olan bilgileri doldurunuz.");
            Console.WriteLine("Marka Adı: ");
            brand.Name = Console.ReadLine();
            brandManager.Add(brand);
            Console.WriteLine($"{brand.Name} sisteme başarıyla eklendi.");

        }
        private static void AddColor(ColorManager colorManager)
        {
            Color color = new Color();
            Console.WriteLine("Renk eklemek için gerekli olan bilgileri doldurunuz.");
            Console.WriteLine("Renk Adı: ");
            color.Name = Console.ReadLine();
            colorManager.Add(color);
            Console.WriteLine($"{color.Name} sisteme başarıyla eklendi.");
        }

        private static void GetEmployeeDetail(EmployeeManager employeeManager)
        {
            Console.WriteLine("Bilgilerini görmek istediğiniz çalışanın Id'sini giriniz: ");
            var employeeId = int.Parse(Console.ReadLine());

            Console.WriteLine("Çalışan Bilgileri \n");

            var employee = employeeManager.GetEmployeeDetail(employeeId);
            Console.WriteLine($"***Kimlik Bilgileri*** \nTC Kimlik No: {employee.IdentityNo} \nAd Soyad: {employee.FullName} \nCinsiyeti: {employee.Gender} \nDoğum Tarihi: {employee.DOB} \n***İletişim Bilgileri*** \nTelefon Numarası: {employee.PhoneNumber} \nAdres Bilgisi: {employee.Address} \n***İş ile İlgili Bilgileri*** \nDepartman: {employee.Department} \nMevki: {employee.Position} \nKatıldığı Tarih: {employee.JoinDate} \n ***Sistem Kullanıcı Bilgisi*** \nE-Mail: {employee.Email} \nŞifre: {employee.PasswordHash}");
        }
        private static void GetAllCarsDetails(CarManager carManager)
        {
            var carList = carManager.GetAllCarsDetails();
            foreach (var car in carList)
            {
                Console.WriteLine($"Marka: {car.Brand} \nModel : {car.Model} \nModel Yılı : {car.ModelYear} \nKapasitesi : {car.Capacity} \nRengi: {car.Color} \nTipi : {car.CarType} \nFiyatı : {car.DailyPrice}tl \n***************************");
            }
        }
        private static void GetCarDetail(CarManager carManager, int carId)
        {

            Console.WriteLine("Detay bilgilerini görmek istediğiniz arabanın Id'sini giriniz: ");
            carId = int.Parse(Console.ReadLine());

            var car = carManager.GetCarDetail(carId);
            Console.WriteLine($"Marka: {car.Brand} \nModel : {car.Model} \nModel Yılı : {car.ModelYear} \nKapasitesi : {car.Capacity} \nRengi: {car.Color} \nTipi : {car.CarType} \nFiyatı : {car.DailyPrice}tl \n***************************");

        }
        private static void GetColors(ColorManager colorManager)
        {
            Console.WriteLine("Renk Listesi");
            var colorList = colorManager.GetAll();
            foreach (var color in colorList)
            {
                Console.WriteLine($"Renk: {color.Name}");
            }
        }
        private static void GetBrands(BrandManager brandManager)
        {
            Console.WriteLine("Marka Listesi");
            var brandList = brandManager.GetAll();
            foreach (var brand in brandList)
            {
                Console.WriteLine($"Marka: {brand.Name}");
            }
        }
        private static void GetCarTypes(CarTypeManager carTypeManager)
        {
            Console.WriteLine("Araba Türleri Listesi");
            var carTypeList = carTypeManager.GetAll();
            foreach (var carType in carTypeList)
            {
                Console.WriteLine($"Araba Türü: {carType.Name}");
            }
        }
        private static void GetDepartments(DepartmentManager departmentManager)
        {
            Console.WriteLine("Departman Listesi");
            var departmentList = departmentManager.GetAll();
            foreach (var department in departmentList)
            {
                Console.WriteLine($"Departman Adı: {department.Name}");
            }
        }

        private static void DeleteCar(CarManager carManager)
        {
            Console.WriteLine("Silmek istediğiniz arabanın Id'sini giriniz: ");
            var carId = int.Parse(Console.ReadLine());
            var carToBeDeleted = carManager.GetById(carId);
            carManager.Delete(carToBeDeleted);
            Console.WriteLine("Araba sistemden başarıyla silinmiştir.");
        }
        private static void DeleteBrand(BrandManager brandManager)
        {
            Console.WriteLine("Silmek istediğiniz markanın adını giriniz: ");
            var brandName = Console.ReadLine();
            var brandToBeDeleted = brandManager.GetByName(brandName);
            brandManager.Delete(brandToBeDeleted);
            Console.WriteLine("Marka sistemden başarıyla silinmiştir.");
        }
        private static void DeleteColor(ColorManager colorManager)
        {
            Console.WriteLine("Silmek istediğiniz rengin adını giriniz: ");
            var colorName = Console.ReadLine();
            var colorToBeDeleted = colorManager.GetByName(colorName);
            colorManager.Delete(colorToBeDeleted);
            Console.WriteLine("Renk sistemden başarıyla silinmiştir.");
        }
        private static void DeleteCarType(CarTypeManager carTypeManager)
        {
            Console.WriteLine("Silmek istediğiniz araba türünün adını giriniz: ");
            var carTypeName = Console.ReadLine();
            var carTypeToBeDeleted = carTypeManager.GetByName(carTypeName);
            carTypeManager.Delete(carTypeToBeDeleted);
            Console.WriteLine("Araba türü sistemden başarıyla silinmiştir.");
        }
        private static void DeleteDepartment(DepartmentManager departmentManager)
        {
            Console.WriteLine("Silmek istediğiniz departmanın adını giriniz: ");
            var departmentName = Console.ReadLine();
            var departmentToBeDeleted = departmentManager.GetByName(departmentName);
            departmentManager.Delete(departmentToBeDeleted);
            Console.WriteLine("Departman sistemden başarıyla silinmiştir.");
        }

        private static void UpdateColor(ColorManager colorManager)
        {
            Console.WriteLine("Güncellemek istediğiniz rengin adını giriniz: ");
            string colorName = Console.ReadLine();
            var colorToBeUpdated = colorManager.GetByName(colorName);
            Console.WriteLine($"Güncellenecek Renk \nRenk :{colorToBeUpdated.Name} \nYeni Renk: ");
            colorToBeUpdated.Name = Console.ReadLine();
            colorManager.Update(colorToBeUpdated);
            Console.WriteLine($"{colorToBeUpdated.Name} rengi başarıyla güncellenmiştir.");
        }
        private static void UpdateBrand(BrandManager brandManager)
        {
            Console.WriteLine("Güncellemek istediğiniz markanın adını giriniz: ");
            string brandName = Console.ReadLine();
            var brandToBeUpdated = brandManager.GetByName(brandName);
            Console.WriteLine($"Güncellenecek Marka: {brandToBeUpdated.Name} \nYeni marka adı: ");
            brandToBeUpdated.Name = Console.ReadLine();
            brandManager.Update(brandToBeUpdated);
            Console.WriteLine($"{brandToBeUpdated.Name} markası başarıyla güncellenmiştir.");
        }
        private static void UpdateCarType(CarTypeManager carTypeManager)
        {
            Console.WriteLine("Güncellemek istediğiniz araba türünün Id'sini giriniz: ");
            int carTypeId = int.Parse(Console.ReadLine());
            var carTypeToBeUpdated = carTypeManager.GetById(carTypeId);
            Console.WriteLine($"Güncellenecek Araba Türü \nAraba türü :{carTypeToBeUpdated.Name} \nAraba türü: ");
            carTypeToBeUpdated.Name = Console.ReadLine();
            carTypeManager.Update(carTypeToBeUpdated);
            Console.WriteLine($"{carTypeToBeUpdated.Name} araba türü başarıyla güncellenmiştir.");
        }
        private static void UpdateCar(CarManager carManager, CarTypeManager carTypeManager, BrandManager brandManager, ColorManager colorManager)
        {
            Console.WriteLine("Bilgilerini güncellemek istediğiniz arabanın Id'sini giriniz: ");
            int carId = int.Parse(Console.ReadLine());
            var carToBeUpdated = carManager.GetCarDetail(carId);
            Console.WriteLine("Güncellenmek istenen arabanın bilgileri;");
            Console.WriteLine($"Marka : {carToBeUpdated.Brand} \nModel : {carToBeUpdated.Model} \nModel Yılı : {carToBeUpdated.ModelYear} \nKapasite : {carToBeUpdated.Capacity} \nRenk : {carToBeUpdated.Color} \nAraba Tipi : {carToBeUpdated.CarType} \nGünlük Fiyat : {carToBeUpdated.DailyPrice}tl \nAdet : {carToBeUpdated.QuantityInStock} \nAçıklama : {carToBeUpdated.Description} \n***************************");

            Car car = new Car();
            car.Id = carToBeUpdated.Id;

            Console.WriteLine("Marka: ");
            var brandName = Console.ReadLine();
            car.BrandId = brandManager.GetByName(brandName).Id;

            Console.WriteLine("Model: ");
            car.Model = Console.ReadLine();

            Console.WriteLine("Model yılı: ");
            car.ModelYear = Console.ReadLine();

            Console.WriteLine("Kapasite: ");
            car.Capacity = (byte)int.Parse(Console.ReadLine());

            Console.WriteLine("Renk: ");
            var colorName = Console.ReadLine();
            car.ColorId = colorManager.GetByName(colorName).Id;

            Console.WriteLine("Araba Tipi: ");
            var carTypeName = Console.ReadLine();
            car.CarTypeId = carTypeManager.GetByName(carTypeName).Id;

            Console.WriteLine("Günlük Fiyat: ");
            car.DailyPrice = double.Parse(Console.ReadLine());

            Console.WriteLine("Adet: ");
            car.QuantityInStock = int.Parse(Console.ReadLine());

            
            Console.WriteLine("Açıklama: ");
            car.Description = Console.ReadLine();

            carManager.Update(car);
            Console.WriteLine("Araba bilgileri başarı ile güncellenmiştir.");
        }
        private static void UpdateDepartment(DepartmentManager departmentManager)
        {
            Console.WriteLine("Güncellemek istediğiniz departmanın adını giriniz: ");
            string departmentName = Console.ReadLine();
            var departmentToBeUpdated = departmentManager.GetByName(departmentName);
            Console.WriteLine($"Güncellenecek Departman \nDepartman Adı :{departmentToBeUpdated.Name} \nYeni Departman Adı: ");
            departmentToBeUpdated.Name = Console.ReadLine();
            departmentManager.Update(departmentToBeUpdated);
            Console.WriteLine($"{departmentToBeUpdated.Name} araba türü başarıyla güncellenmiştir.");
        }

        #region Before EfCore, Generic Repository and Dto implementation
        private static void GetCarByColor(CarManager carManager, ColorManager colorManager, CarTypeManager carTypeManager)
        {
            var cars = carManager.GetAllByColorId(1);
            foreach (var car in cars)
            {
                Console.WriteLine($"Model : {car.Model} \nModel Yılı : {car.ModelYear} \nFiyatı : {car.DailyPrice} \nKapasitesi : {car.Capacity} \nRengi: {colorManager.GetById(car.ColorId).Name} \nTipi : {carTypeManager.GetById(car.CarTypeId).Name} \n***************************");
            }
        }
        private static void CreateandAdd(CarManager carManager, BrandManager brandManager, ColorManager colorManager, CarTypeManager carTypeManager)
        {
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
            foreach (var brand in brandList)
            {
                brandManager.Add(brand);
            }
            foreach (var color in colorList)
            {
                colorManager.Add(color);
            }
            foreach (var types in carTypes)
            {
                carTypeManager.Add(types);
            }
            foreach (var car in carList)
            {
                carManager.Add(car);
            }
        }

        #endregion
    }
}
