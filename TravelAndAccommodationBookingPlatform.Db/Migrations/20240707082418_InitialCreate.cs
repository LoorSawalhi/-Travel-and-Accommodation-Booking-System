using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAndAccommodationBookingPlatform.Db.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Post_Office = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__City__3214EC27AB428730", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Passport_ID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Phone_number = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Role = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__3214EC27606C6153", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Star_Rating = table.Column<int>(type: "int", nullable: true),
                    Owner = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    City_ID = table.Column<int>(type: "int", nullable: true),
                    Min_price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Max_price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Hotel__3214EC27FB92D2E5", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Hotel__City_ID__398D8EEE",
                        column: x => x.City_ID,
                        principalTable: "City",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Hotel_ID = table.Column<int>(type: "int", nullable: true),
                    Availability = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Adults_count = table.Column<int>(type: "int", nullable: true),
                    Children_count = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Room__3214EC278E7FF14A", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Room__Hotel_ID__3C69FB99",
                        column: x => x.Hotel_ID,
                        principalTable: "Hotel",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    User_ID = table.Column<int>(type: "int", nullable: true),
                    Hotel_ID = table.Column<int>(type: "int", nullable: true),
                    Room_ID = table.Column<int>(type: "int", nullable: true),
                    Start_date = table.Column<DateOnly>(type: "date", nullable: true),
                    End_date = table.Column<DateOnly>(type: "date", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reservat__3214EC27D62B486B", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Reservati__Hotel__4222D4EF",
                        column: x => x.Hotel_ID,
                        principalTable: "Hotel",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Reservati__Room___4316F928",
                        column: x => x.Room_ID,
                        principalTable: "Room",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Reservati__User___412EB0B6",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_City_ID",
                table: "Hotel",
                column: "City_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Hotel_ID",
                table: "Reservations",
                column: "Hotel_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Room_ID",
                table: "Reservations",
                column: "Room_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_User_ID",
                table: "Reservations",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Room_Hotel_ID",
                table: "Room",
                column: "Hotel_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
