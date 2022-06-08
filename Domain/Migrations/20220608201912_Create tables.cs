using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Domain.Migrations
{
    public partial class Createtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblIncident",
                columns: table => new
                {
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblIncident", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "tblAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    IncidentNameKey = table.Column<string>(type: "character varying(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblAccount_tblIncident_IncidentNameKey",
                        column: x => x.IncidentNameKey,
                        principalTable: "tblIncident",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "tblContact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    AccountId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblContact_tblAccount_AccountId",
                        column: x => x.AccountId,
                        principalTable: "tblAccount",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblAccount_IncidentNameKey",
                table: "tblAccount",
                column: "IncidentNameKey");

            migrationBuilder.CreateIndex(
                name: "IX_tblContact_AccountId",
                table: "tblContact",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblContact");

            migrationBuilder.DropTable(
                name: "tblAccount");

            migrationBuilder.DropTable(
                name: "tblIncident");
        }
    }
}
