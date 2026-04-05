using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GainBase.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkoutSoftDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Workouts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51df033a-4b09-43f7-9f09-5f8ff2b952db", "AQAAAAIAAYagAAAAEIQtjTlmt/lsWqmzvDUqd7f90FkoVq+k/r021xgyiGvCvTYoCAMRV1d8kLSPCSIxvg==", "26c49f46-687d-4330-8d49-103691f0aecf" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Workouts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1b2c3d4-e5f6-7890-abcd-ef1234567890",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e33fb333-55ab-40e1-aeb7-8249e7913af8", "AQAAAAIAAYagAAAAEBLhv0+RzV1RtBYdiOHAP2Drc4/PYIlVjegUTro7wPL5UqmutJ4tZ7RNaWYxJZ8qFA==", "ace19f2d-c45a-48a1-898a-2483cd0d2b02" });
        }
    }
}
