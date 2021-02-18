using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentACar_Domain_Layer.Enum;
using RentACar_Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar_DataAccess_Layer
{
    public class RentaCarDbContext : IdentityDbContext<User>
    {
        public RentaCarDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Order> Order { get; set; }
        public DbSet<VehicleOrder> VehicleOrders { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<AdditionalEquipment> AddEquipment { get; set; }
        public DbSet<AirportService> AirportService { get; set; }

        public void Seed(ModelBuilder modelBuilder)
        {
            string adminId = Guid.NewGuid().ToString();
            string roleId = Guid.NewGuid().ToString();
            string userRoleId = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>()
                .HasData(
                   new IdentityRole
                   {
                       Id = roleId,
                       Name = "admin",
                       NormalizedName = "ADMIN"
                   },
                    new IdentityRole
                    {
                        Id = userRoleId,
                        Name = "user",
                        NormalizedName = "USER"
                    }
                );

            var hasher = new PasswordHasher<User>();

            modelBuilder.Entity<User>()
                .HasData(
                   new User
                   {
                       Id = adminId,
                       UserName = "admin",
                       NormalizedUserName = "ADMIN",
                       Email = "rentacar@rentamkdrive.com",
                       NormalizedEmail = "rentacar@rentamkdrive.com",
                       EmailConfirmed = true,
                       PasswordHash = hasher.HashPassword(null, "Admin123#"),
                       SecurityStamp = string.Empty,
                       Age = 38,
                       PhoneNumber = "+389/77-102-223",
                       PhoneNumberConfirmed = true,
                       TwoFactorEnabled = true
                   }
                );
            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(
                   new IdentityUserRole<string>
                   {
                       RoleId = roleId,
                       UserId = adminId
                   }
                );
            modelBuilder.Entity<Vehicle>()
                .HasData(
                   new Vehicle() { Id = 1, VehicleType = VehicleType.Car, Brand = "Mercedes-Benz",Model = "A-Class",Doors = 4, Color = "Black",
                       Description = "produced by the German automobile manufacturer Mercedes-Benz in 2010, 5-speed Automatic,Fuel-Diesel, Top Speed 158 km/h (98 mph)",
                       Price = 24.62
                   },
                   new Vehicle()
                   {
                       Id = 2,VehicleType = VehicleType.Car,Brand = "Skoda",Model = "Octavia",Doors = 4,Color = "Metallic-Grey",                       
                       Description = "produced by the Czech car manufacturer Škoda Auto in 2008, 6-speed automatic and 5/6-speed Manual, Fuel-Petrol, Top Speed 210 km/h (130 mph)",
                       Price = 20.38
                   },
                   new Vehicle()
                   {
                       Id = 3,
                       VehicleType = VehicleType.Car,Brand = "Toyota",Model = "Premio",Doors = 4,Color = "White",                                                                                                
                       Description = "produced by the Japan car manufacturer in Toyota in 2012, 4-speed automatic, Fuel-Petrol, Top Speed 180 km/h (111 mph)",
                       Price = 26.97
                   },
                   new Vehicle()
                   {
                       Id = 4,VehicleType = VehicleType.SportUtalityVehicle,Brand = "Ford",Model = "Explorer",Doors = 4,Color = "Red",                                                                                                        
                       Description = "produced by the American car manufacturer in Ford Motor Company in 2009, 5-speed manual and 4-speed automatic, Top Speed 230 km/h (143 mph)",
                       Price = 22.56
                   },
                   new Vehicle()
                   {
                       Id = 5,VehicleType = VehicleType.Motorcycle,Brand = "Yamaha",Model = "FZS600 Fazer",Color = "Yellow-Black",             
                       Description = "produced by the Japanese manufacturer in Yamaha Company in 2003, Top Speed 217 km/h (135 mph), Power 95 hp (70.8 kW), Torque 45 lb⋅ft (61 N⋅m) (claimed)",
                       Price = 16.89
                   },
                   new Vehicle()
                   {
                       Id = 6, VehicleType = VehicleType.Motorcycle,Brand = "Scooter",Model = "Kymco Super-9",Color = "Orange-Black",                                                                                           
                       Description = "The Super 9 is a lightweight scooter made by Kymco in Taiwan, Top Speed 56 km/h (35 mph), Power 3.5 hp (2.6 kW) at 5,500 rpm, Transmission Automatic CVT",
                       Price = 12.19
                   },
                   new Vehicle()
                   {
                       Id = 7,VehicleType = VehicleType.Van,Brand = "Mercedes-Benz",Model = "Sprinter",Doors = 2,Color = "White",                                                                                                                 
                       Description = "produced by the German automobile manufacturer Mercedes-Benz in 2009, 6-speed Manual and 7-speed Automatic,Fuel-TurboDiesel, Top Speed 155 km/h (96 mph)",
                       Price = 24.62
                   },
                   new Vehicle()
                   {
                       Id = 8,VehicleType = VehicleType.Boat,Brand = "Larson-Senza",Model = "186",Color = "White-Red",                                                                                                                     
                       Description = "Larson is a 2008 craft and 6.2 metres length. The boat is capable of transferring with comfort and safety up to 8 persons. " +
                        "The engine is a four stroke Mercuiser 225hp and is supported with a backup engine of 5hp Yamaha for extra safety.",
                       Price = 37.19
                   },
                   new Vehicle()
                   {
                       Id = 9,VehicleType = VehicleType.Bicycle,Brand = "Mountain bicycle",Model = "Bianchi",Color = "Blue",                                                                                                              
                       Description = "29 wheels and hydraulic disc brakes.Hardtail, 100mm shock, 2x9 gears,  Shimano Deore derailleur.",
                       Price = 7.83
                   }
                );
            modelBuilder.Entity<AdditionalEquipment>()
                .HasData(
                    new AdditionalEquipment()
                    {
                        Id = 1,
                        Name = "GPS-Wi Fi",
                        Type = "KINGWO NB-IOT",
                        Description = "KINGWO NB-IOT GPS Tracker Mini GPS Tracking Device For Vehicle/Car/Motorcycle",
                        Price = 2.64
                    },
                    new AdditionalEquipment()
                    {
                        Id = 2,
                        Name = "Roof for Cars",
                        Type = "Pair 120cm Adjustable Roof Rail Aluminum Cross Bar+Cargo Box Carrier w/Lock+Keys (Black)",
                        Description = "Universal Style Cross Bars: Aluminum Bar Construction&Mounting Brackets " +
                                        "Cargo Box: Heavy Duty ABS Plastic Construction " +
                                        "Capacity: 12 cu.ft. / Dimensions: 68 L x 31 W x 16 H Opens to 14.75 Wide to Store Bulky Items " +
                                        "Opens from the Side and Stays Open Til you Close It",
                        Price = 3.09
                    },
                    new AdditionalEquipment()
                    {
                        Id = 3,
                        Name = "Motorcycle Helmet",
                        Type = "Nolan N53 MX Smart - Flat Black",
                        Description = "The Nolan N53 MX is an off-road full-face helmet by. " +
                            "Extremely aggressive design and ostentatious personality for a product in line with the latest trends in its class. " +
                            "Available in two different outer shell sizes, " +
                            "the N53 MX features an extra-wide window to accommodate different types of goggles. " +
                            "The rear of the shell itself has been designed to house the strap. ",
                        Price = 1.94
                    },
                    new AdditionalEquipment()
                    {
                        Id = 4, Name = "Bicycle Floor Pump", Type = "LEZYNE",                                                
                        Description = "Color - Gloss Black, Item Weight - 1.4 kg, Dimensions - 27 * 12 * 8 inches, " +
                                      " Lezyne Pressure Overdrive Floor Pump: Black ",
                        Price = 1.18
                    },
                     new AdditionalEquipment()
                     {
                         Id = 5, Name = "Baby Car Seat", Type = "Graco",                                                                         
                         Description = "Installation Type	Seat Belt, LATCH, Color	Binx, Dimensions - LxWxH 30.67 x 18.66 x 15.59 inches, Weight - 17.5 Pounds",
                         Price = 2.45
                     }
               );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VehicleOrder>()
                .HasKey(vo => new { vo.VehicleId, vo.OrderId, vo.AirportServiceId, vo.AddEquipmenrId });

            modelBuilder.Entity<User>()
                .HasMany(x => x.Orders)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Order>()
                .HasMany(x => x.VehicleOrders)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);

            modelBuilder.Entity<Order>()
                .HasOne(x => x.Invoice)
                .WithOne(x => x.Order)
                .HasForeignKey<Invoice>(x => x.OrderId);

            modelBuilder.Entity<Vehicle>()
                .HasMany(x => x.VehicleOrders)
                .WithOne(x => x.Vehicle)
                .HasForeignKey(x => x.VehicleId);

            modelBuilder.Entity<AdditionalEquipment>()
                .HasMany(x => x.VehicleOrders)
                .WithOne(x => x.AddEquipment)
                .HasForeignKey(x => x.AddEquipmenrId);

            modelBuilder.Entity<AirportService>()
                .HasMany(x => x.VehicleOrders)
                .WithOne(x => x.AirportService)
                .HasForeignKey(x => x.AirportServiceId);
                

            Seed(modelBuilder);
        }
    }
}
