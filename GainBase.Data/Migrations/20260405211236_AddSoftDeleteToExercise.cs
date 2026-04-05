using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GainBase.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSoftDeleteToExercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Exercises",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "485173b4-ba3a-4e00-8400-86a0355930b4", "AQAAAAIAAYagAAAAEKCq2aH/2ZlRN0wjWDQ+DGJPDbNAAlIGi69p5V3zk/SmtmQSIGqqDwaFBFHfoDPVWw==", "4260a9df-e7ab-4497-bf65-7bf019f6b47a" });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("290ed620-d909-4753-8c16-1975c6c45ff6"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("9d6eb388-fcc9-4ae2-b624-bab179d4430f"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("b8e967c6-7665-4cf6-ac73-245cbbfd8465"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("ba65e859-d292-4757-ac04-2e8cf7012869"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("bbe8aa23-04f6-43fb-993c-7ba2ba04caaa"),
                column: "IsDeleted",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Exercises");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51df033a-4b09-43f7-9f09-5f8ff2b952db", "AQAAAAIAAYagAAAAEIQtjTlmt/lsWqmzvDUqd7f90FkoVq+k/r021xgyiGvCvTYoCAMRV1d8kLSPCSIxvg==", "26c49f46-687d-4330-8d49-103691f0aecf" });
        }
    }
}
