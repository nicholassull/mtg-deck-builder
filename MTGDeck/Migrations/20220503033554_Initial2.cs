using Microsoft.EntityFrameworkCore.Migrations;

namespace MTGDeck.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FiveCost",
                table: "Decks");

            migrationBuilder.DropColumn(
                name: "FourCost",
                table: "Decks");

            migrationBuilder.DropColumn(
                name: "OneCost",
                table: "Decks");

            migrationBuilder.DropColumn(
                name: "SevenCost",
                table: "Decks");

            migrationBuilder.DropColumn(
                name: "SixCost",
                table: "Decks");

            migrationBuilder.DropColumn(
                name: "ThreeCost",
                table: "Decks");

            migrationBuilder.DropColumn(
                name: "TwoCost",
                table: "Decks");

            migrationBuilder.DropColumn(
                name: "Cmc",
                table: "Cards");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FiveCost",
                table: "Decks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FourCost",
                table: "Decks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OneCost",
                table: "Decks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SevenCost",
                table: "Decks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SixCost",
                table: "Decks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ThreeCost",
                table: "Decks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TwoCost",
                table: "Decks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Cmc",
                table: "Cards",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
