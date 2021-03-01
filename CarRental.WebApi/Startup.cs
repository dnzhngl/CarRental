using CarRental.Business.Abstract;
using CarRental.Business.Concrete;
using CarRental.Core.Utilities.IoC;
using CarRental.Core.Utilities.Security.Encryption;
using CarRental.Core.Utilities.Security.JWT;
using CarRental.DataAccess.Abstract;
using CarRental.DataAccess.Concrete.EntityFramework;
using CarRental.WebApi.Helpers.Abstract;
using CarRental.WebApi.Helpers.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            // File helper
            services.AddScoped<IFileHelper, FileHelper>();

            #region Before Autofac IoC implementation, there were a build in IoC
            //services.AddSingleton<IBrandService, BrandManager>();
            //services.AddSingleton<IBrandDal, EfBrandDal>();

            //services.AddSingleton<ICarService, CarManager>();
            //services.AddSingleton<ICarDal, EfCarDal>();

            //services.AddSingleton<ICarTypeService, CarTypeManager>();
            //services.AddSingleton<ICarTypeDal, EfCarTypeDal>();

            //services.AddSingleton<IColorService, ColorManager>();
            //services.AddSingleton<IColorDal, EfColorDal>();

            //services.AddSingleton<IDepartmentService, DepartmentManager>();
            //services.AddSingleton<IDepartmentDal, EfDepartmentDal>();

            //services.AddSingleton<IRentalService, RentalManager>();
            //services.AddSingleton<IRentalDal, EfRentalDal>();

            //services.AddSingleton<IUserService, UserManager>();
            //services.AddSingleton<IUserDal, EfUserDal>();

            //services.AddSingleton<ICustomerService, CustomerManager>();
            //services.AddSingleton<ICustomerDal, EfCustomerDal>();

            //services.AddSingleton<IIndividualCustomerService, IndividualCustomerManager>();
            //services.AddSingleton<IIndividualCustomerDal, EfIndividualCustomerDal>();

            //services.AddSingleton<ICorporateCustomerService, CorporateCustomerManager>();
            //services.AddSingleton<ICorporateCustomerDal, EfCorporateCustomerDal>();

            //services.AddSingleton<IEmployeeService, EmployeeManager>();
            //services.AddSingleton<IEmployeeDal, EfEmployeeDal>();
            #endregion

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });

            ServiceTool.Create(services);


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarRental.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarRental.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
