using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentACar_DataAccess_Layer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddEquipment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddEquipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AirportService",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isClientWant = table.Column<bool>(nullable: false),
                    City = table.Column<string>(maxLength: 200, nullable: true),
                    Airport = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportService", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehicleType = table.Column<int>(nullable: false),
                    Brand = table.Column<string>(maxLength: 50, nullable: false),
                    Model = table.Column<string>(maxLength: 50, nullable: true),
                    Doors = table.Column<int>(nullable: false),
                    Color = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isPayed = table.Column<bool>(nullable: false),
                    StatusType = table.Column<int>(nullable: false),
                    DateOfOrder = table.Column<DateTime>(nullable: false),
                    isDownPaid = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: false),
                    PaymentType = table.Column<int>(nullable: false),
                    IdCardNum = table.Column<int>(nullable: false),
                    IdBankCard = table.Column<string>(maxLength: 50, nullable: false),
                    Phone = table.Column<string>(maxLength: 50, nullable: false),
                    City = table.Column<string>(maxLength: 100, nullable: false),
                    ZipCode = table.Column<int>(nullable: false),
                    DownPayment = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehicleId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    AddEquipmenrId = table.Column<int>(nullable: false),
                    AirportServiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleOrders", x => new { x.VehicleId, x.OrderId, x.AirportServiceId, x.AddEquipmenrId });
                    table.UniqueConstraint("AK_VehicleOrders_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleOrders_AddEquipment_AddEquipmenrId",
                        column: x => x.AddEquipmenrId,
                        principalTable: "AddEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleOrders_AirportService_AirportServiceId",
                        column: x => x.AirportServiceId,
                        principalTable: "AirportService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleOrders_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleOrders_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AddEquipment",
                columns: new[] { "Id", "Description", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 1, "KINGWO NB-IOT GPS Tracker Mini GPS Tracking Device For Vehicle/Car/Motorcycle", "GPS-Wi Fi", 2.64, "KINGWO NB-IOT" },
                    { 2, "Universal Style Cross Bars: Aluminum Bar Construction&Mounting Brackets Cargo Box: Heavy Duty ABS Plastic Construction Capacity: 12 cu.ft. / Dimensions: 68 L x 31 W x 16 H Opens to 14.75 Wide to Store Bulky Items Opens from the Side and Stays Open Til you Close It", "Roof for Cars", 3.09, "Pair 120cm Adjustable Roof Rail Aluminum Cross Bar+Cargo Box Carrier w/Lock+Keys (Black)" },
                    { 3, "The Nolan N53 MX is an off-road full-face helmet by. Extremely aggressive design and ostentatious personality for a product in line with the latest trends in its class. Available in two different outer shell sizes, the N53 MX features an extra-wide window to accommodate different types of goggles. The rear of the shell itself has been designed to house the strap. ", "Motorcycle Helmet", 1.94, "Nolan N53 MX Smart - Flat Black" },
                    { 4, "Color - Gloss Black, Item Weight - 1.4 kg, Dimensions - 27 * 12 * 8 inches,  Lezyne Pressure Overdrive Floor Pump: Black ", "Bicycle Floor Pump", 1.18, "LEZYNE" },
                    { 5, "Installation Type	Seat Belt, LATCH, Color	Binx, Dimensions - LxWxH 30.67 x 18.66 x 15.59 inches, Weight - 17.5 Pounds", "Baby Car Seat", 2.45, "Graco" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "338bc9d9-4f55-4578-9bf7-66c6d29684df", "ac306897-85b3-46c1-8f27-2955eea491f2", "admin", "ADMIN" },
                    { "47060357-ce90-4933-bf04-589b9d5cb909", "47e20d85-5813-417f-bbdb-7e78f85ef904", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3a00c366-9a04-4256-9cfb-bb70a6a609ad", 0, 38, "cc077af7-ab3c-4491-b4ad-c02b4ba6a112", "rentacar@rentamkdrive.com", true, null, 0, false, null, "rentacar@rentamkdrive.com", "ADMIN", "AQAAAAEAACcQAAAAEO1v/iDRdn5GKIgL+LlT4oFuqYxCV9WTCiMFggkZftYhnS6mTcxKIKxO9N2P/GclcA==", "+389/77-102-223", true, "", true, "admin" });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "Brand", "Color", "Description", "Doors", "Model", "Price", "VehicleType" },
                values: new object[,]
                {
                    { 7, "Mercedes-Benz", "White", "produced by the German automobile manufacturer Mercedes-Benz in 2009, 6-speed Manual and 7-speed Automatic,Fuel-TurboDiesel, Top Speed 155 km/h (96 mph)", 2, "Sprinter", 24.62, 4 },
                    { 6, "Scooter", "Orange-Black", "The Super 9 is a lightweight scooter made by Kymco in Taiwan, Top Speed 56 km/h (35 mph), Power 3.5 hp (2.6 kW) at 5,500 rpm, Transmission Automatic CVT", 0, "Kymco Super-9", 12.19, 3 },
                    { 5, "Yamaha", "Yellow-Black", "produced by the Japanese manufacturer in Yamaha Company in 2003, Top Speed 217 km/h (135 mph), Power 95 hp (70.8 kW), Torque 45 lb⋅ft (61 N⋅m) (claimed)", 0, "FZS600 Fazer", 16.89, 3 },
                    { 1, "Mercedes-Benz", "Black", "produced by the German automobile manufacturer Mercedes-Benz in 2010, 5-speed Automatic,Fuel-Diesel, Top Speed 158 km/h (98 mph)", 4, "A-Class", 24.62, 1 },
                    { 3, "Toyota", "White", "produced by the Japan car manufacturer in Toyota in 2012, 4-speed automatic, Fuel-Petrol, Top Speed 180 km/h (111 mph)", 4, "Premio", 26.97, 1 },
                    { 2, "Skoda", "Metallic-Grey", "produced by the Czech car manufacturer Škoda Auto in 2008, 6-speed automatic and 5/6-speed Manual, Fuel-Petrol, Top Speed 210 km/h (130 mph)", 4, "Octavia", 20.38, 1 },
                    { 8, "Larson-Senza", "White-Red", "Larson is a 2008 craft and 6.2 metres length. The boat is capable of transferring with comfort and safety up to 8 persons. The engine is a four stroke Mercuiser 225hp and is supported with a backup engine of 5hp Yamaha for extra safety.", 0, "186", 37.19, 5 },
                    { 4, "Ford", "Red", "produced by the American car manufacturer in Ford Motor Company in 2009, 5-speed manual and 4-speed automatic, Top Speed 230 km/h (143 mph)", 4, "Explorer", 22.56, 2 },
                    { 9, "Mountain bicycle", "Blue", "29 wheels and hydraulic disc brakes.Hardtail, 100mm shock, 2x9 gears,  Shimano Deore derailleur.", 0, "Bianchi", 7.83, 6 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "3a00c366-9a04-4256-9cfb-bb70a6a609ad", "338bc9d9-4f55-4578-9bf7-66c6d29684df" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_OrderId",
                table: "Invoice",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleOrders_AddEquipmenrId",
                table: "VehicleOrders",
                column: "AddEquipmenrId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleOrders_AirportServiceId",
                table: "VehicleOrders",
                column: "AirportServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleOrders_OrderId",
                table: "VehicleOrders",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "VehicleOrders");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AddEquipment");

            migrationBuilder.DropTable(
                name: "AirportService");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
