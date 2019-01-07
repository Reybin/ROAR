using System;
using BussinessLayer.Services;
using BussinessLayer.Services.Contracts;
using DataLayer.Context;
using DataLayer.Dto_s;
using DataLayer.Models;
using DataLayer.ModelsValidation;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ROAR_API
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
           
            services.AddMvc().AddFluentValidation().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<RoarContext>(cfg => cfg.UseSqlServer(Configuration.GetConnectionString("ROAR_ERP")));  //--> Modifiquen el appsetings de acuerdo a su pc
            services.AddTransient<IValidator<BaseModel>, BaseModelValidation>();
            services.AddTransient<IValidator<Employee>, EmployeeValidation>();
            services.AddTransient<IEmployeeService,EmployeeService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }


            //Ejemplo de como utilizar el AutoMapper  
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                    .ForMember(dest => dest.Age, opt => opt.MapFrom(src =>  DateTime.Now.Year - src.BirthDate.Year))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
