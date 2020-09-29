using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactBook.Data.Migrations
{
    public partial class PersonBiosadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonBio",
                columns: table => new
                {
                    PBID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    Hobbies = table.Column<string>(nullable: true),
                    Bloodgroup = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonBio", x => x.PBID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonBio");
        }
    }
}
