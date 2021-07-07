using Microsoft.EntityFrameworkCore.Migrations;

namespace REP_CRIME01.Police.Infrastructure.Migrations
{
    public partial class AddUniqueConstraintOnLawEnforcementCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "LawEnforcement",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LawEnforcement_Code",
                table: "LawEnforcement",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LawEnforcement_Code",
                table: "LawEnforcement");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "LawEnforcement",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
