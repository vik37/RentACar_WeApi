using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RentACar_DataAccess_Layer;
using RentACar_DataAccess_Layer.Interfaces;
using RentACar_DataAccess_Layer.Repositories;
using RentACar_Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar_Businness_Layer.Helpers
{
    public static class DIModule
    {
        public static IServiceCollection RegisterModule(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<RentaCarDbContext>(options =>
            options.UseSqlServer(connectionString));

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = false;
                options.Password.RequireNonAlphanumeric = false;

            })
            .AddRoleManager<RoleManager<IdentityRole>>()
            .AddEntityFrameworkStores<RentaCarDbContext>()
            .AddDefaultTokenProviders();
            

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<IRepository<Vehicle>, VehicleRepository>();
            services.AddTransient<IRepository<Invoice>, InvoiceRepository>();
            services.AddTransient<IRepository<AirportService>, AirportServiceRepository>();
            services.AddTransient<IRepository<AdditionalEquipment>, AdditionalEquipmentRepository>();

            return services;
        }
    }
}
