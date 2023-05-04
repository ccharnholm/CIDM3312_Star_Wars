using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIDM3312_Star_Wars.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classification_Character_CharacterID1",
                table: "Classification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classification",
                table: "Classification");

            migrationBuilder.DropIndex(
                name: "IX_Classification_CharacterID1",
                table: "Classification");

            migrationBuilder.RenameColumn(
                name: "CharacterID1",
                table: "Classification",
                newName: "CharacterIdFK");

            migrationBuilder.AlterColumn<int>(
                name: "CharacterID",
                table: "Classification",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "CharacterIdFK",
                table: "Classification",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classification",
                table: "Classification",
                column: "CharacterIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_Classification_CharacterID",
                table: "Classification",
                column: "CharacterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Classification_Character_CharacterID",
                table: "Classification",
                column: "CharacterID",
                principalTable: "Character",
                principalColumn: "CharacterID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classification_Character_CharacterID",
                table: "Classification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classification",
                table: "Classification");

            migrationBuilder.DropIndex(
                name: "IX_Classification_CharacterID",
                table: "Classification");

            migrationBuilder.RenameColumn(
                name: "CharacterIdFK",
                table: "Classification",
                newName: "CharacterID1");

            migrationBuilder.AlterColumn<int>(
                name: "CharacterID",
                table: "Classification",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "CharacterID1",
                table: "Classification",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classification",
                table: "Classification",
                column: "CharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_Classification_CharacterID1",
                table: "Classification",
                column: "CharacterID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Classification_Character_CharacterID1",
                table: "Classification",
                column: "CharacterID1",
                principalTable: "Character",
                principalColumn: "CharacterID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
