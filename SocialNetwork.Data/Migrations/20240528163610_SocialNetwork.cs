using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.Data.Migrations
{
    public partial class SocialNetwork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeGender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeGender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeTopic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeTopic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Birthdate = table.Column<DateTime>(type: "date", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TypeGenderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_TypeGender_TypeGenderId",
                        column: x => x.TypeGenderId,
                        principalTable: "TypeGender",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeTopicId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_TypeTopic_TypeTopicId",
                        column: x => x.TypeTopicId,
                        principalTable: "TypeTopic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commentary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commentary_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Commentary_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recommendations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recommendations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recommendations_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recommendations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TypeGender",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" },
                    { 3, "Other" }
                });

            migrationBuilder.InsertData(
                table: "TypeTopic",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Office" },
                    { 2, "Books" },
                    { 3, "eLearning" },
                    { 4, "Innovation" },
                    { 5, "Others" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthdate", "Email", "FirstName", "LastName", "Login", "Password", "Phone", "TypeGenderId" },
                values: new object[,]
                {
                    { 1, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Usuario1@gmail.com", "Usuario", "1", "Usuario1", "Usuario1_pass", "123456789", 1 },
                    { 2, new DateTime(2002, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Usuario2@gmail.com", "Usuario", "2", "Usuario2", "Usuario2_pass", "223456789", 2 },
                    { 3, new DateTime(1996, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Usuario3@gmail.com", "Usuario", "3", "Usuario3", "Usuario3_pass", "323456789", 1 },
                    { 4, new DateTime(1995, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Usuario4@gmail.com", "Usuario", "4", "Usuario4", "Usuario4_pass", "423456789", 2 },
                    { 5, new DateTime(1988, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Usuario5@gmail.com", "Usuario", "5", "Usuario5", "Usuario5_pass", "523456789", 3 },
                    { 6, new DateTime(2005, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Usuario6@gmail.com", "Usuario", "6", "Usuario6", "Usuario6_pass", "623456789", 2 },
                    { 7, new DateTime(2001, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Usuario7@gmail.com", "Usuario", "7", "Usuario7", "Usuario7_pass", "723456789", 2 },
                    { 8, new DateTime(2000, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Usuario8@gmail.com", "Usuario", "8", "Usuario8", "Usuario8_pass", "823456789", 1 },
                    { 9, new DateTime(1999, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Usuario9@gmail.com", "Usuario", "9", "Usuario9", "Usuario9_pass", "923456789", 3 },
                    { 10, new DateTime(1991, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Usuario10@gmail.com", "Usuario", "10", "Usuario10", "Usuario10_pass", "023456789", 1 }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Content", "CreationDate", "Title", "TypeTopicId", "UserId" },
                values: new object[,]
                {
                    { 1, "Este es el contenido del primer artículo del Usuario 1", new DateTime(2024, 5, 28, 18, 36, 10, 233, DateTimeKind.Local).AddTicks(4189), "Titulo del primer artículo del Usuario 1", 1, 1 },
                    { 2, "Este es el contenido del primer artículo del Usuario 2", new DateTime(2024, 5, 28, 18, 36, 10, 233, DateTimeKind.Local).AddTicks(4223), "Titulo del primer artículo del Usuario 2", 2, 2 },
                    { 3, "Este es el contenido del primer artículo del Usuario 3", new DateTime(2024, 5, 28, 18, 36, 10, 233, DateTimeKind.Local).AddTicks(4226), "Titulo del primer artículo del Usuario 3", 3, 3 },
                    { 4, "Este es el contenido del primer artículo del Usuario 6", new DateTime(2024, 5, 28, 18, 36, 10, 233, DateTimeKind.Local).AddTicks(4228), "Titulo del primer artículo del Usuario 6", 4, 6 },
                    { 5, "Este es el contenido del segundo artículo del Usuario 6", new DateTime(2024, 5, 28, 18, 36, 10, 233, DateTimeKind.Local).AddTicks(4231), "Titulo del segundo artículo del Usuario 6", 5, 6 },
                    { 6, "Este es el contenido del primer artículo del Usuario 8", new DateTime(2024, 5, 28, 18, 36, 10, 233, DateTimeKind.Local).AddTicks(4234), "Titulo del primer artículo del Usuario 8", 3, 8 }
                });

            migrationBuilder.InsertData(
                table: "Commentary",
                columns: new[] { "Id", "ArticleId", "Date", "Description", "Rating", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 28, 18, 36, 10, 233, DateTimeKind.Local).AddTicks(4292), "Descripcion de comentario en articulo 1 de usuario 4", 4, "Titulo de comentario en articulo 1 de usuario 4", 4 },
                    { 2, 2, new DateTime(2024, 5, 28, 18, 36, 10, 233, DateTimeKind.Local).AddTicks(4296), "Descripcion de comentario en articulo 2 de usuario 3", 2, "Titulo de comentario en articulo 2 de usuario 3", 3 },
                    { 3, 2, new DateTime(2024, 5, 28, 18, 36, 10, 233, DateTimeKind.Local).AddTicks(4299), "Descripcion de comentario en articulo 2 de usuario 6", 5, "Titulo de comentario en articulo 2 de usuario 6", 6 },
                    { 4, 4, new DateTime(2024, 5, 28, 18, 36, 10, 233, DateTimeKind.Local).AddTicks(4302), "Descripcion de comentario en articulo  4 de usuario 1", 5, "Titulo de comentario en articulo 4 de usuario 1", 1 },
                    { 5, 6, new DateTime(2024, 5, 28, 18, 36, 10, 233, DateTimeKind.Local).AddTicks(4305), "Descripcion de comentario en articulo 6 de usuario 10", 2, "Titulo de comentario en articulo 6 de usuario 10", 10 },
                    { 6, 6, new DateTime(2024, 5, 28, 18, 36, 10, 233, DateTimeKind.Local).AddTicks(4307), "Descripcion de comentario en articulo 6 de usuario 7", 1, "Titulo de comentario en articulo 6 de usuario 7", 7 }
                });

            migrationBuilder.InsertData(
                table: "Recommendations",
                columns: new[] { "Id", "ArticleId", "Date", "UserId" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2024, 5, 28, 18, 36, 10, 233, DateTimeKind.Local).AddTicks(4363), 2 },
                    { 2, 4, new DateTime(2024, 5, 28, 18, 36, 10, 233, DateTimeKind.Local).AddTicks(4367), 4 },
                    { 3, 2, new DateTime(2024, 5, 28, 18, 36, 10, 233, DateTimeKind.Local).AddTicks(4370), 7 },
                    { 4, 6, new DateTime(2024, 5, 28, 18, 36, 10, 233, DateTimeKind.Local).AddTicks(4372), 8 },
                    { 5, 1, new DateTime(2024, 5, 28, 18, 36, 10, 233, DateTimeKind.Local).AddTicks(4375), 9 },
                    { 6, 2, new DateTime(2024, 5, 28, 18, 36, 10, 233, DateTimeKind.Local).AddTicks(4377), 2 },
                    { 7, 4, new DateTime(2024, 5, 28, 18, 36, 10, 233, DateTimeKind.Local).AddTicks(4380), 10 },
                    { 8, 4, new DateTime(2024, 5, 28, 18, 36, 10, 233, DateTimeKind.Local).AddTicks(4382), 3 },
                    { 9, 2, new DateTime(2024, 5, 28, 18, 36, 10, 233, DateTimeKind.Local).AddTicks(4385), 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_TypeTopicId",
                table: "Articles",
                column: "TypeTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentary_ArticleId",
                table: "Commentary",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Commentary_UserId",
                table: "Commentary",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_ArticleId",
                table: "Recommendations",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_UserId",
                table: "Recommendations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_TypeGenderId",
                table: "Users",
                column: "TypeGenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commentary");

            migrationBuilder.DropTable(
                name: "Recommendations");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "TypeTopic");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "TypeGender");
        }
    }
}
