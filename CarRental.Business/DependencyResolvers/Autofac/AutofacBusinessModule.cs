using Autofac;
using Autofac.Extras.DynamicProxy;
using CarRental.Business.Abstract;
using CarRental.Business.Concrete;
using CarRental.Core.Utilities.Interceptors;
using CarRental.Core.Utilities.Security.JWT;
using CarRental.DataAccess.Abstract;
using CarRental.DataAccess.Concrete.EntityFramework;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Brand
            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();

            // Car
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            // CarType
            builder.RegisterType<CarTypeManager>().As<ICarTypeService>().SingleInstance();
            builder.RegisterType<EfCarTypeDal>().As<ICarTypeDal>().SingleInstance();

            // Color
            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();

            // Department
            builder.RegisterType<DepartmentManager>().As<IDepartmentService>().SingleInstance();
            builder.RegisterType<EfDepartmentDal>().As<IDepartmentDal>().SingleInstance();

            // User
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            // Employee
            builder.RegisterType<EmployeeManager>().As<IEmployeeService>().SingleInstance();
            builder.RegisterType<EfEmployeeDal>().As<IEmployeeDal>().SingleInstance();

            // Customer
            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            // IndividualCustomer
            builder.RegisterType<IndividualCustomerManager>().As<IIndividualCustomerService>().SingleInstance();
            builder.RegisterType<EfIndividualCustomerDal>().As<IIndividualCustomerDal>().SingleInstance();

            // CorporateCustomer
            builder.RegisterType<CorporateCustomerManager>().As<ICorporateCustomerService>().SingleInstance();
            builder.RegisterType<EfCorporateCustomerDal>().As<ICorporateCustomerDal>().SingleInstance();

            // Rental
            builder.RegisterType<RentalManager>().As<IRentalService>().InstancePerDependency();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().InstancePerDependency();

            // CarImage
            builder.RegisterType<CarImageManager>().As<ICarImageService>().InstancePerDependency();
            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().InstancePerDependency();

            // Authentication
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();


            //builder.RegisterType<FileHelper>().As<IFileHelper>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
