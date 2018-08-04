using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ETLSuite.Data.Migrations
{
    public partial class Added_Description_To_DbConnectionDefinition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "LogEntries",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DbConnectionDefinitions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConnectionString",
                table: "DbConnectionDefinitions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DbConnectionDefinitions",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DbConnectionDefinitions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Description", "Modified" },
                values: new object[] { new DateTime(2018, 8, 3, 21, 26, 52, 944, DateTimeKind.Local), "Sql Server 1 description", new DateTime(2018, 8, 3, 21, 26, 52, 944, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2018, 8, 3, 21, 26, 52, 939, DateTimeKind.Local), new DateTime(2018, 8, 3, 21, 26, 52, 941, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "DbConnectionDefinitions");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "LogEntries",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DbConnectionDefinitions",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ConnectionString",
                table: "DbConnectionDefinitions",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "DbConnectionDefinitions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2018, 8, 3, 20, 48, 18, 259, DateTimeKind.Local), new DateTime(2018, 8, 3, 20, 48, 18, 259, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2018, 8, 3, 20, 48, 18, 255, DateTimeKind.Local), new DateTime(2018, 8, 3, 20, 48, 18, 257, DateTimeKind.Local) });
        }
    }
}
