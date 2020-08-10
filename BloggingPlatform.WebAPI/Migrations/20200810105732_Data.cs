using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BloggingPlatform.WebAPI.Migrations
{
    public partial class Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogPost",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Slug = table.Column<string>(maxLength: 200, nullable: true),
                    Title = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPost", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogPost_Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlugId = table.Column<int>(nullable: true),
                    TagId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPost_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "fk_SlugId",
                        column: x => x.SlugId,
                        principalTable: "BlogPost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BlogPost",
                columns: new[] { "Id", "Body", "CreatedAt", "Description", "Slug", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "The app is simple to use, and will help you decide on your best furniture fit.", new DateTime(2020, 8, 10, 12, 57, 31, 64, DateTimeKind.Local).AddTicks(8526), "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.", "augmented-reality-ios-application", "Augmented Reality iOS Application", new DateTime(2020, 8, 10, 12, 57, 31, 79, DateTimeKind.Local).AddTicks(8852) },
                    { 2, "The app is simple to use, and will help you decide on your best furniture fit.", new DateTime(2020, 8, 10, 12, 57, 31, 81, DateTimeKind.Local).AddTicks(317), "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.", "augmented-reality-ios-application-2", "Augmented Reality iOS Application 2", new DateTime(2020, 8, 10, 12, 57, 31, 81, DateTimeKind.Local).AddTicks(533) },
                    { 3, "This is the best way to introduce to the Angular", new DateTime(2020, 8, 10, 12, 57, 31, 81, DateTimeKind.Local).AddTicks(1022), "Course where the user can learn the most useful tips and triks while learning Angular", "course-for-begginers-Angular", "Course for begginers - Angular", new DateTime(2020, 8, 10, 12, 57, 31, 81, DateTimeKind.Local).AddTicks(1053) },
                    { 4, "This is the best way to introduce to the HTML5 and CSS3", new DateTime(2020, 8, 10, 12, 57, 31, 81, DateTimeKind.Local).AddTicks(1235), "Course where the user can learn the most useful tips and triks for web development applications!", "course-for-begginers-HTML5-CSS3", "Course for begginers - HTML5 and CSS3", new DateTime(2020, 8, 10, 12, 57, 31, 81, DateTimeKind.Local).AddTicks(1260) },
                    { 5, "This is the best way to introduce to the train the dataset", new DateTime(2020, 8, 10, 12, 57, 31, 81, DateTimeKind.Local).AddTicks(1424), "Course where the user can learn how to clean unstructured dataset, train it and after that test the dataset!", "course-for-begginers-AWS-Comprehend", "Course for begginers - AWS Comprehend", new DateTime(2020, 8, 10, 12, 57, 31, 81, DateTimeKind.Local).AddTicks(1452) }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "AR" },
                    { 2, "iOS" },
                    { 3, "Angular" },
                    { 4, ".Net Core" },
                    { 5, "C++" },
                    { 6, "HTML5" },
                    { 7, "Xamarin" },
                    { 8, "CSS3" },
                    { 9, "AWS Comprehend" },
                    { 10, "Android" }
                });

            migrationBuilder.InsertData(
                table: "BlogPost_Tags",
                columns: new[] { "Id", "SlugId", "TagId" },
                values: new object[,]
                {
                    { 4, 2, 1 },
                    { 5, 1, 1 },
                    { 6, 1, 2 },
                    { 7, 2, 2 },
                    { 3, 4, 6 },
                    { 2, 4, 8 },
                    { 1, 5, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPost_Tags_SlugId",
                table: "BlogPost_Tags",
                column: "SlugId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPost_Tags_TagId",
                table: "BlogPost_Tags",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPost_Tags");

            migrationBuilder.DropTable(
                name: "BlogPost");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
