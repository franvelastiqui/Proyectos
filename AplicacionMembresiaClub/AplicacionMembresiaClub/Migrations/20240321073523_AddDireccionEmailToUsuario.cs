using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplicacionMembresiaClub.Migrations
{
    /// <inheritdoc />
    public partial class AddDireccionEmailToUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DireccionEmail",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DireccionEmail",
                table: "Usuarios");
        }
    }
}
