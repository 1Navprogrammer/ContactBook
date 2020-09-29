using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactBook.Data.Migrations
{
    public partial class socialaccountsadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Social",
                columns: table => new
                {
                    SId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    InstagramId = table.Column<string>(nullable: true),
                    FacebookId = table.Column<string>(nullable: true),
                    WhatsappNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Social", x => x.SId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Social");
        }
    }
}
