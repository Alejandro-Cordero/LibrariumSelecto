using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.Data.Migrations
{
    public partial class SeedInicialBaseDeDatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 1, "Este es el contenido del primer artículo del Usuario 1", new DateTime(2024, 5, 8, 15, 56, 32, 878, DateTimeKind.Local).AddTicks(5611), "Titulo del primer artículo del Usuario 1", 1, 1 },
                    { 2, "Este es el contenido del primer artículo del Usuario 2", new DateTime(2024, 5, 8, 15, 56, 32, 878, DateTimeKind.Local).AddTicks(5649), "Titulo del primer artículo del Usuario 2", 2, 2 },
                    { 3, "Este es el contenido del primer artículo del Usuario 3", new DateTime(2024, 5, 8, 15, 56, 32, 878, DateTimeKind.Local).AddTicks(5651), "Titulo del primer artículo del Usuario 3", 3, 3 },
                    { 4, "Este es el contenido del primer artículo del Usuario 6", new DateTime(2024, 5, 8, 15, 56, 32, 878, DateTimeKind.Local).AddTicks(5652), "Titulo del primer artículo del Usuario 6", 4, 6 },
                    { 5, "Este es el contenido del segundo artículo del Usuario 6", new DateTime(2024, 5, 8, 15, 56, 32, 878, DateTimeKind.Local).AddTicks(5654), "Titulo del segundo artículo del Usuario 6", 5, 6 },
                    { 6, "Este es el contenido del primer artículo del Usuario 8", new DateTime(2024, 5, 8, 15, 56, 32, 878, DateTimeKind.Local).AddTicks(5655), "Titulo del primer artículo del Usuario 8", 3, 8 }
                });

            migrationBuilder.InsertData(
                table: "Commentary",
                columns: new[] { "Id", "ArticleId", "Date", "Description", "Rating", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 8, 15, 56, 32, 878, DateTimeKind.Local).AddTicks(5683), "Descripcion de comentario en articulo 1 de usuario 4", 4, "Titulo de comentario en articulo 1 de usuario 4", 4 },
                    { 2, 2, new DateTime(2024, 5, 8, 15, 56, 32, 878, DateTimeKind.Local).AddTicks(5685), "Descripcion de comentario en articulo 2 de usuario 3", 2, "Titulo de comentario en articulo 2 de usuario 3", 3 },
                    { 3, 2, new DateTime(2024, 5, 8, 15, 56, 32, 878, DateTimeKind.Local).AddTicks(5687), "Descripcion de comentario en articulo 2 de usuario 6", 5, "Titulo de comentario en articulo 2 de usuario 6", 6 },
                    { 4, 4, new DateTime(2024, 5, 8, 15, 56, 32, 878, DateTimeKind.Local).AddTicks(5688), "Descripcion de comentario en articulo  4 de usuario 1", 5, "Titulo de comentario en articulo 4 de usuario 1", 1 },
                    { 5, 6, new DateTime(2024, 5, 8, 15, 56, 32, 878, DateTimeKind.Local).AddTicks(5690), "Descripcion de comentario en articulo 6 de usuario 10", 2, "Titulo de comentario en articulo 6 de usuario 10", 10 },
                    { 6, 6, new DateTime(2024, 5, 8, 15, 56, 32, 878, DateTimeKind.Local).AddTicks(5691), "Descripcion de comentario en articulo 6 de usuario 7", 1, "Titulo de comentario en articulo 6 de usuario 7", 7 }
                });

            migrationBuilder.InsertData(
                table: "Recommendations",
                columns: new[] { "Id", "ArticleId", "Date", "UserId" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2024, 5, 8, 15, 56, 32, 878, DateTimeKind.Local).AddTicks(5718), 2 },
                    { 2, 4, new DateTime(2024, 5, 8, 15, 56, 32, 878, DateTimeKind.Local).AddTicks(5720), 4 },
                    { 3, 2, new DateTime(2024, 5, 8, 15, 56, 32, 878, DateTimeKind.Local).AddTicks(5721), 7 },
                    { 4, 6, new DateTime(2024, 5, 8, 15, 56, 32, 878, DateTimeKind.Local).AddTicks(5723), 8 },
                    { 5, 1, new DateTime(2024, 5, 8, 15, 56, 32, 878, DateTimeKind.Local).AddTicks(5724), 9 },
                    { 6, 2, new DateTime(2024, 5, 8, 15, 56, 32, 878, DateTimeKind.Local).AddTicks(5725), 2 },
                    { 7, 4, new DateTime(2024, 5, 8, 15, 56, 32, 878, DateTimeKind.Local).AddTicks(5727), 10 },
                    { 8, 4, new DateTime(2024, 5, 8, 15, 56, 32, 878, DateTimeKind.Local).AddTicks(5728), 3 },
                    { 9, 2, new DateTime(2024, 5, 8, 15, 56, 32, 878, DateTimeKind.Local).AddTicks(5729), 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Commentary",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Commentary",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Commentary",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Commentary",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Commentary",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Commentary",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Recommendations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
