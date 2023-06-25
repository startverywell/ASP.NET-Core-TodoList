using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoCRUD.Migrations
{
    /// <inheritdoc />
    public partial class Complete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Todos",
                table: "Todos");

            migrationBuilder.RenameTable(
                name: "Todos",
                newName: "todo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "todo",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "todo",
                newName: "name");

            migrationBuilder.AddColumn<short>(
                name: "active",
                table: "todo",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_todo",
                table: "todo",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_todo",
                table: "todo");

            migrationBuilder.DropColumn(
                name: "active",
                table: "todo");

            migrationBuilder.RenameTable(
                name: "todo",
                newName: "Todos");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Todos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Todos",
                newName: "Title");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todos",
                table: "Todos",
                column: "Id");
        }
    }
}
