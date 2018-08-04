using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ETLSuite.Data.Migrations
{
    public partial class Added_DbConnectionDefinitions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbConnectionDefinitions",
                columns: table => new
                {
                    Created = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ConnectionString = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbConnectionDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbConnectionDefinitions_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DbConnectionDefinitions",
                columns: new[] { "Id", "ConnectionString", "Created", "CreatedBy", "Modified", "ModifiedBy", "Name", "ProjectId", "Type" },
                values: new object[] { 1, "Data Source=.\\SQLEXPRESS;Initial Catalog=ETLSuite_UploadSource;Integrated Security=True", new DateTime(2018, 8, 3, 20, 48, 18, 259, DateTimeKind.Local), "test", new DateTime(2018, 8, 3, 20, 48, 18, 259, DateTimeKind.Local), "test", "Sql Server 1", 1, 0 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2018, 8, 3, 20, 48, 18, 255, DateTimeKind.Local), new DateTime(2018, 8, 3, 20, 48, 18, 257, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_DbConnectionDefinitions_ProjectId",
                table: "DbConnectionDefinitions",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbConnectionDefinitions");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Modified" },
                values: new object[] { new DateTime(2018, 7, 29, 16, 2, 17, 38, DateTimeKind.Local), new DateTime(2018, 7, 29, 16, 2, 17, 40, DateTimeKind.Local) });
        }
    }
}
