using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lesson_2.Migrations
{
    /// <inheritdoc />
    public partial class InitStudents2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2025, 9, 22, 8, 10, 10, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2025, 9, 22, 8, 10, 10, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2025, 9, 30, 21, 12, 0, 189, DateTimeKind.Unspecified).AddTicks(1849), new TimeSpan(0, 3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2025, 9, 30, 21, 12, 0, 191, DateTimeKind.Unspecified).AddTicks(6965), new TimeSpan(0, 3, 0, 0, 0)));
        }
    }
}
