using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Constants
{
    public static class Messages
    {
        public static string Error()
        {
            return "Bir hata oluştu";
        }
        public static string NotFound()
        {
            return "Hiç bir kayıt bulunamadı.";
        }
        public static class Brand
        {
            public static string Add(string brandName)
            {
                return $"{brandName} isimli marka sisteme başarı ile eklenmiştir.";
            }
            public static string Update(string brandName)
            {
                return $"{brandName} isimli marka bilgileri başarılı bir şekilde güncellenmiştir.";
            }
            public static string Delete(string brandName)
            {
                return $"{brandName} isimli marka sistemden başarılı bir şekilde silinmiştir.";
            }
            public static string Exists(string brandName)
            {
                return $"{brandName} aynı isimde bir marka sistemde mavcuttur.";
            }
        }
        public static class Car
        {
            public static string Add(string model, string modelYear)
            {
                return $"{model} - {modelYear} model araba sisteme başarı ile eklenmiştir.";
            }
            public static string Update(string model, string modelYear)
            {
                return $"{model} - {modelYear} model araba bilgileri başarılı bir şekilde güncellenmiştir.";
            }
            public static string Delete(string model, string modelYear)
            {
                return $"{model} - {modelYear} model araba sistemden başarılı bir şekilde silinmiştir.";
            }
            public static string Exists(string model, string modelYear, string color)
            {
                return $"{model} - {modelYear} - {color} bilgilerine sahip bir araba sistemde kayıtlıdır.";
            }
            public static string ExistsPlateNumber(string licensePlate)
            {
                return $"{licensePlate} bilgilerine sahip bir araba sistemde kayıtlıdır.";
            }
        }
        public static class CarType
        {
            public static string Add(string carTypeName)
            {
                return $"{carTypeName} araba türü sisteme başarı ile eklenmiştir.";
            }
            public static string Update(string carTypeName)
            {
                return $"{carTypeName} araba türü başarılı bir şekilde güncellenmiştir.";
            }
            public static string Delete(string carTypeName)
            {
                return $"{carTypeName} araba türü sistemden başarılı bir şekilde silinmiştir.";
            }
            public static string Exists(string carTypeName)
            {
                return $"{carTypeName} ismine sahip bir araba türü sistemde kayıtlıdır.";
            }

        }
        public static class Color
        {
            public static string Add(string colorName)
            {
                return $"{colorName} renk sisteme başarı ile eklenmiştir.";
            }
            public static string Update(string colorName)
            {
                return $"{colorName} renk bilgileri başarılı bir şekilde güncellenmiştir.";
            }
            public static string Delete(string colorName)
            {
                return $"{colorName} renk sistemden başarılı bir şekilde silinmiştir.";
            }
            public static string Exists(string colorName)
            {
                return $"{colorName} renk ismine sahip bir kayıt sistemde bulunmaktadır.";
            }

        }
        public static class CorporateCustomer
        {
            public static string Add(string companyName)
            {
                return $"{companyName} isimli müşteri sisteme başarı ile eklenmiştir.";
            }
            public static string Update(string companyName)
            {
                return $"{companyName} adlı müşterinin bilgileri başarılı bir şekilde güncellenmiştir.";
            }
            public static string Delete(string companyName)
            {
                return $"{companyName} adlı müşteri sistemden başarılı bir şekilde silinmiştir.";
            }
            public static string Exists(string companyName)
            {
                return $"{companyName} bilgilerine sahip bir müşteri sistemde kayıtlıdır.";
            }

        }
        public static class IndividualCustomer
        {
            public static string Add(string customerFirstname, string customerLastname)
            {
                return $"{customerFirstname} {customerLastname} isimli müşteri sisteme başarı ile eklenmiştir.";
            }
            public static string Update(string customerFirstname, string customerLastname)
            {
                return $"{customerFirstname} {customerLastname} adlı müşterinin bilgileri başarılı bir şekilde güncellenmiştir.";
            }
            public static string Delete(string customerFirstname, string customerLastname)
            {
                return $"{customerFirstname} {customerLastname} adlı müşteri sistemden başarılı bir şekilde silinmiştir.";
            }
            public static string Exists(string customerFirstname, string customerLastname)
            {
                return $"{customerFirstname} {customerLastname} bilgilerine sahip bir müşteri sistemde kayıtlıdır.";
            }

        }
        public static class Department
        {
            public static string Add(string departmentName)
            {
                return $"{departmentName} departmanı sisteme başarı ile eklenmiştir.";
            }
            public static string Update(string departmentName)
            {
                return $"{departmentName} departman bilgileri başarılı bir şekilde güncellenmiştir.";
            }
            public static string Delete(string departmentName)
            {
                return $"{departmentName} departmanı sistemden başarılı bir şekilde silinmiştir.";
            }
            public static string Exists(string departmentName)
            {
                return $"{departmentName} departmanı bilgilerine sahip bir kayıt sistemde bulunmaktadır.";
            }

        }
        public static class Employee
        {
            public static string Add(string firstName, string lastName)
            {
                return $"{firstName} {lastName} isimli çalışan sisteme başarı ile eklenmiştir.";
            }
            public static string Update(string firstName, string lastName)
            {
                return $"{firstName} {lastName} isimli çalışan bilgileri başarılı bir şekilde güncellenmiştir.";
            }
            public static string Delete(string firstName, string lastName)
            {
                return $"{firstName} {lastName} isimli çalışan sistemden başarılı bir şekilde silinmiştir.";
            }
            public static string Exists(string firstName, string lastName, string identityNo)
            {
                return $"{firstName} {lastName} - {identityNo} çalışan bilgilerine sahip bir kayıt sistemde bulunmaktadır.";
            }

        }
        public static class Rental
        {
            public static string Add()
            {
                return $"Araba kiralama sözleşmesi sisteme başarı ile eklenmiştir.";
            }
            public static string Update()
            {
                return $"Araba kiralama sözleşmesi bilgileri başarılı bir şekilde güncellenmiştir.";
            }
            public static string Delete()
            {
                return $"Araba kiralama sözleşmesi sistemden başarılı bir şekilde silinmiştir.";
            }
        }
        public static class RentalCar
        {
            public static string Add()
            {
                return $"Araba kiralama sözleşmesi sisteme başarı ile eklenmiştir.";
            }
            public static string Update()
            {
                return $"Araba kiralama sözleşmesi bilgileri başarılı bir şekilde güncellenmiştir.";
            }
            public static string Delete()
            {
                return $"Araba kiralama sözleşmesi sistemden başarılı bir şekilde silinmiştir.";
            }
            public static string Exists(string carModel, string carModelYear)
            {
                return $"Sözleşmeye dahil edilen {carModel} - {carModelYear} model araba müsait değildir.";
            }
        }
        public static class User
        {
            public static string Add()
            {
                return $"Kullanıcı sisteme başarı ile eklenmiştir.";
            }
            public static string Update()
            {
                return $"Kullanıcı bilgileri başarılı bir şekilde güncellenmiştir.";
            }
            public static string Delete()
            {
                return $"Kullanıcı sistemden başarılı bir şekilde silinmiştir.";
            }
            public static string Exists(string emailAddress)
            {
                return $"{emailAddress} bilgilerine sahip bir kullanıcı sistemde kayıtlıdır.";
            }

        }
        public static class CarImage
        {
            public static string Add(bool isPlural)
            {
                if (isPlural)
                {
                    return $"Fotoğraflar sisteme başarı ile eklenmiştir.";
                }
                return $"Fotoğraf sisteme başarı ile eklenmiştir.";
            }
            public static string Update(bool isPlural)
            {
                if (isPlural)
                {
                    return $"Fotoğraflar başarılı bir şekilde güncellenmiştir.";
                }
                return $"Fotoğraf başarılı bir şekilde güncellenmiştir.";
            }
            public static string Delete(bool isPlural)
            {
                if (isPlural)
                {
                    return $"Fotoğraflar sistemden başarılı bir şekilde silinmiştir.";
                }
                return $"Fotoğraf sistemden başarılı bir şekilde silinmiştir.";
            }
            public static string NumberOfPhotografsHasReachedLimit(int limit)
            {
                return $"Bir arabanın en fazla {limit} fotoğrafı olabilir.";
            }

        }
    }
}
