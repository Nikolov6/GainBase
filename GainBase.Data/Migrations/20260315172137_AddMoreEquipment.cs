using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GainBase.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreEquipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8298d93-677c-4250-8b0e-275397ec2256", "AQAAAAIAAYagAAAAEGVT6tx+v2txgI/pMYRa0E/0uPzINOKO7fweALr64l0L6VO0pkQxY86nxxSVMd+whQ==", "59fcb838-496e-432e-8b6f-a54e28b3cb52" });

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Dumbbells");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Barbell");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "EZ Barbell");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Resistance Band");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Squat Rack");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Bench Press");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Arm Curl Machine");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Arm Extension Machine");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Rowing Machine");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Parallel Bars");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Pull-up Bar");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Shoulder Press Machine");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Lateral Raises Machine");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "Chest Press Machine");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "Chest Fly Machine");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 17,
                column: "Name",
                value: "Back Extension Machine");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 18,
                column: "Name",
                value: "Lat Pulldown Machine");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 19,
                column: "Name",
                value: "Ab Crunch Machine");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 20,
                column: "Name",
                value: "Leg Press Machine");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 21,
                column: "Name",
                value: "Leg Extension Machine");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 22,
                column: "Name",
                value: "Leg Curl Machine");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 23,
                column: "Name",
                value: "Smith Machine");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 24,
                column: "Name",
                value: "Cable Crossover Machine");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 25,
                column: "Name",
                value: "Treadmill");

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 26, "Stationary Bike" },
                    { 27, "Elliptical Trainer" },
                    { 28, "Stair Climber" }
                });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("290ed620-d909-4753-8c16-1975c6c45ff6"),
                column: "EquipmentId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("9d6eb388-fcc9-4ae2-b624-bab179d4430f"),
                column: "EquipmentId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("b8e967c6-7665-4cf6-ac73-245cbbfd8465"),
                column: "EquipmentId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("bbe8aa23-04f6-43fb-993c-7ba2ba04caaa"),
                column: "EquipmentId",
                value: 7);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "597a3a8b-0e0d-4d45-9f0c-dd561c7b59d7", "AQAAAAIAAYagAAAAENG1culb9g5JbBbFkOyKwsKYZr7Fzg64rGpiXBNgwyfIPtH1eH1lzjW01NjBED/rXQ==", "d0bb65b5-ae2c-41fe-80e2-4e71e9803a8d" });

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Resistance Band");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Squat Rack");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Bench Press");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Arm Curl Machine");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Arm Extension Machine");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Rowing Machine");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Parallel Bars");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Pull-up Bar");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Shoulder Press Machine");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Lateral Raises Machine");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Chest Press Machine");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Chest Fly Machine");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Back Extension Machine");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "Lat Pulldown Machine");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "Ab Crunch Machine");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 17,
                column: "Name",
                value: "Leg Press Machine");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 18,
                column: "Name",
                value: "Leg Extension Machine");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 19,
                column: "Name",
                value: "Leg Curl Machine");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 20,
                column: "Name",
                value: "Smith Machine");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 21,
                column: "Name",
                value: "Cable Crossover Machine");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 22,
                column: "Name",
                value: "Treadmill");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 23,
                column: "Name",
                value: "Stationary Bike");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 24,
                column: "Name",
                value: "Elliptical Trainer");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 25,
                column: "Name",
                value: "Stair Climber");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("290ed620-d909-4753-8c16-1975c6c45ff6"),
                column: "EquipmentId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("9d6eb388-fcc9-4ae2-b624-bab179d4430f"),
                column: "EquipmentId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("b8e967c6-7665-4cf6-ac73-245cbbfd8465"),
                column: "EquipmentId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("bbe8aa23-04f6-43fb-993c-7ba2ba04caaa"),
                column: "EquipmentId",
                value: 4);
        }
    }
}
