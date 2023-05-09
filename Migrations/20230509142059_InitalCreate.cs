using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIDM3312_Star_Wars.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    CharacterID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Health = table.Column<int>(type: "INTEGER", nullable: false),
                    BattlePoints = table.Column<int>(type: "INTEGER", nullable: false),
                    Class = table.Column<string>(type: "TEXT", nullable: false),
                    Subclass = table.Column<string>(type: "TEXT", nullable: false),
                    Allegiance = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.CharacterID);
                });

            migrationBuilder.CreateTable(
                name: "Weapon",
                columns: table => new
                {
                    WeaponID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WeaponName = table.Column<string>(type: "TEXT", nullable: false),
                    WeaponDamage = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapon", x => x.WeaponID);
                });

            migrationBuilder.CreateTable(
                name: "CharacterWeapon",
                columns: table => new
                {
                    CharacterID = table.Column<int>(type: "INTEGER", nullable: false),
                    WeaponID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterWeapon", x => new { x.WeaponID, x.CharacterID });
                    table.ForeignKey(
                        name: "FK_CharacterWeapon_Character_CharacterID",
                        column: x => x.CharacterID,
                        principalTable: "Character",
                        principalColumn: "CharacterID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterWeapon_Weapon_WeaponID",
                        column: x => x.WeaponID,
                        principalTable: "Weapon",
                        principalColumn: "WeaponID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterWeapon_CharacterID",
                table: "CharacterWeapon",
                column: "CharacterID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterWeapon");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Weapon");
        }
    }
}
