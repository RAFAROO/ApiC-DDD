using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanOnionNetwork.Infrastructure.Migrations
{
    public partial class Migrationtwoforerrors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Stramers_StreamerId",
                table: "Videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stramers",
                table: "Stramers");

            migrationBuilder.RenameTable(
                name: "Stramers",
                newName: "Streamers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Streamers",
                table: "Streamers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Streamers_StreamerId",
                table: "Videos",
                column: "StreamerId",
                principalTable: "Streamers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Streamers_StreamerId",
                table: "Videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Streamers",
                table: "Streamers");

            migrationBuilder.RenameTable(
                name: "Streamers",
                newName: "Stramers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stramers",
                table: "Stramers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Stramers_StreamerId",
                table: "Videos",
                column: "StreamerId",
                principalTable: "Stramers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
