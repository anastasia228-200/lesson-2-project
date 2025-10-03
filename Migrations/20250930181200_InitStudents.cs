using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lesson_2.Migrations
{
    /// <inheritdoc />
    public partial class InitStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Login = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    MiddleName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    VkProfileLink = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "Login", "MiddleName", "Phone", "VkProfileLink" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 9, 30, 21, 12, 0, 189, DateTimeKind.Unspecified).AddTicks(1849), new TimeSpan(0, 3, 0, 0, 0)), "vanya123@mail.com", "Иван", "Иванов", "vanya123", "Иванович", "+71234567890", "http://vk.com/vanya123" },
                    { 2, new DateTimeOffset(new DateTime(2025, 9, 30, 21, 12, 0, 191, DateTimeKind.Unspecified).AddTicks(6965), new TimeSpan(0, 3, 0, 0, 0)), "maria@mail.com", "Мария", "Иванова", "maria", "Ивановна", "+71234567899", "http://vk.com/maria" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
