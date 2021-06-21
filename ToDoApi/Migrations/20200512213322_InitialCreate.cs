using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Todo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    DateCreated = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todo", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Todo",
                columns: new[] { "Id", "Date", "DateCreated", "Description", "Priority", "Title" },
                values: new object[] { 1, "12/05/2020 12:00:00 AM", "12/05/2020 12:00:00 AM", "Need to buy groccery", 4, "Other" });

            migrationBuilder.InsertData(
                table: "Todo",
                columns: new[] { "Id", "Date", "DateCreated", "Description", "Priority", "Title" },
                values: new object[] { 2, "12/05/2020 12:00:00 AM", "12/05/2020 12:00:00 AM", "Do monthly Budget", 2, "Budget" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todo");
        }
    }
}
