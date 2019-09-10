using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DbRepository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GuidebookTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidebookTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObjectsInventory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    GuidebookTypeId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 512, nullable: true),
                    Count = table.Column<int>(nullable: false),
                    Uniqcode = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectsInventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjectsInventory_GuidebookTypes_GuidebookTypeId",
                        column: x => x.GuidebookTypeId,
                        principalTable: "GuidebookTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObjectsInventory_GuidebookTypeId",
                table: "ObjectsInventory",
                column: "GuidebookTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObjectsInventory");

            migrationBuilder.DropTable(
                name: "GuidebookTypes");
        }
    }
}
