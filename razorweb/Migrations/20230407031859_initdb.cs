using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace razorweb.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.Id);
                });
                // Fake data Bogus
            migrationBuilder.InsertData(
                table: "articles",
                columns: new[] {"Title","PublishDate","Content"},
                values: new object[] {
                    "bai 1",
                    new DateTime(2023,4,7),
                    "Noi dung 1"
                }
            );
             migrationBuilder.InsertData(
                table: "articles",
                columns: new[] {"Title","PublishDate","Content"},
                values: new object[] {
                    "bai 2",
                    new DateTime(2023,4,7),
                    "Noi dung 2"
                }
            );
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");
        }
    }
}
