using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImageStoringProject.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDataTypeOfIsInActiev : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsInActive",
                table: "Photos",
                type: "bit",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "IsInActive",
                table: "Photos",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
