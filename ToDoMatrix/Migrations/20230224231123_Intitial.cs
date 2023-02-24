using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoMatrix.Migrations
{
    public partial class Intitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Task = table.Column<string>(nullable: false),
                    Urgent = table.Column<string>(nullable: false),
                    Completed = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Responses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "Home" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "School" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 3, "Work" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 4, "Church" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "TaskId", "CategoryId", "Completed", "Date", "Task", "Urgent" },
                values: new object[] { 1, 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wash the dog", "Q1" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "TaskId", "CategoryId", "Completed", "Date", "Task", "Urgent" },
                values: new object[] { 2, 2, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IS 413 Assignment", "Q2" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "TaskId", "CategoryId", "Completed", "Date", "Task", "Urgent" },
                values: new object[] { 3, 3, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Big Presentation", "Q3" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "TaskId", "CategoryId", "Completed", "Date", "Task", "Urgent" },
                values: new object[] { 4, 4, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sacrament Meeting Talk", "Q4" });

            migrationBuilder.CreateIndex(
                name: "IX_Responses_CategoryId",
                table: "Responses",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
