using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ETLSuite.Data.Migrations
{
    public partial class AddingSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Created", "CreatedBy", "Description", "Modified", "ModifiedBy", "Name", "Status" },
                values: new object[] { 1, new DateTime(2018, 7, 29, 16, 2, 17, 38, DateTimeKind.Local), "test", "Project 1 Description", new DateTime(2018, 7, 29, 16, 2, 17, 40, DateTimeKind.Local), "test", "Project 1", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
