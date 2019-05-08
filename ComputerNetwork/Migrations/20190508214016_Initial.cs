using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerNetwork.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdOfElement = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Mask = table.Column<string>(nullable: true),
                    Gateway = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Edges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdOfElement = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Mask = table.Column<string>(nullable: true),
                    Gateway = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdOfElement = table.Column<string>(nullable: false),
                    IpAddress = table.Column<string>(nullable: false),
                    Mask = table.Column<string>(nullable: false),
                    Gateway = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Switches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdOfElement = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Mask = table.Column<string>(nullable: true),
                    Gateway = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Switches", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Computers");

            migrationBuilder.DropTable(
                name: "Edges");

            migrationBuilder.DropTable(
                name: "Routers");

            migrationBuilder.DropTable(
                name: "Switches");
        }
    }
}
