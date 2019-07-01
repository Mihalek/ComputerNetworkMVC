using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerNetwork.Migrations
{
    public partial class migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameOfNetwork = table.Column<string>(nullable: true),
                    DateOfAdd = table.Column<string>(nullable: true),
                    NameOfElement = table.Column<string>(nullable: false),
                    IdOfElement = table.Column<string>(nullable: false),
                    IpAddress = table.Column<string>(maxLength: 15, nullable: false),
                    Mask = table.Column<string>(maxLength: 15, nullable: false),
                    Gateway = table.Column<string>(maxLength: 15, nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    Shape = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
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
                    From = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    NameOfNetwork = table.Column<string>(nullable: true),
                    DateOfAdd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Networks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameOfNetwork = table.Column<string>(nullable: true),
                    DateOfAdd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Networks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameOfNetwork = table.Column<string>(nullable: true),
                    DateOfAdd = table.Column<string>(nullable: true),
                    NameOfElement = table.Column<string>(nullable: false),
                    IdOfElement = table.Column<string>(nullable: false),
                    IpAddress = table.Column<string>(maxLength: 15, nullable: false),
                    Mask = table.Column<string>(maxLength: 15, nullable: false),
                    Gateway = table.Column<string>(maxLength: 15, nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    Shape = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
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
                    NameOfNetwork = table.Column<string>(nullable: true),
                    DateOfAdd = table.Column<string>(nullable: true),
                    NameOfElement = table.Column<string>(nullable: false),
                    IdOfElement = table.Column<string>(nullable: false),
                    IpAddress = table.Column<string>(maxLength: 15, nullable: false),
                    Mask = table.Column<string>(maxLength: 15, nullable: false),
                    Gateway = table.Column<string>(maxLength: 15, nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    Shape = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
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
                name: "Networks");

            migrationBuilder.DropTable(
                name: "Routers");

            migrationBuilder.DropTable(
                name: "Switches");
        }
    }
}
