using Microsoft.EntityFrameworkCore.Migrations;

namespace MarkusLib.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookID",
                table: "Books",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "BookID", "author", "summary", "title" },
                values: new object[] { 1, null, "Fyodor Dostoyevsky", "One should pray for redemption, rather than punishment.", "Brothers Kazamarov" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "BookID", "author", "summary", "title" },
                values: new object[] { 2, null, " William S. Burroughs", "The dark and seedy underworld.", "Naked Lunch" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "BookID", "author", "summary", "title" },
                values: new object[] { 3, null, "Viktor E. Frankyl", "Happiness through suffering.", "Man's Search for Meaning" });

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookID",
                table: "Books",
                column: "BookID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Books_BookID",
                table: "Books",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Books_BookID",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookID",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "BookID",
                table: "Books");
        }
    }
}
