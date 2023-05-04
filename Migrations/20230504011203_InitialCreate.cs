using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIDM3312_Star_Wars.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    BattlePoints = table.Column<int>(type: "INTEGER", nullable: false)
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
                name: "Classification",
                columns: table => new
                {
                    CharacterID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Class = table.Column<string>(type: "TEXT", nullable: false),
                    Subclass = table.Column<string>(type: "TEXT", nullable: false),
                    Allegiance = table.Column<string>(type: "TEXT", nullable: false),
                    CharacterID1 = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classification", x => x.CharacterID);
                    table.ForeignKey(
                        name: "FK_Classification_Character_CharacterID1",
                        column: x => x.CharacterID1,
                        principalTable: "Character",
                        principalColumn: "CharacterID",
                        onDelete: ReferentialAction.Cascade);
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
                    table.PrimaryKey("PK_CharacterWeapon", x => new { x.CharacterID, x.WeaponID });
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
                name: "IX_CharacterWeapon_WeaponID",
                table: "CharacterWeapon",
                column: "WeaponID");

            migrationBuilder.CreateIndex(
                name: "IX_Classification_CharacterID1",
                table: "Classification",
                column: "CharacterID1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterWeapon");

            migrationBuilder.DropTable(
                name: "Classification");

            migrationBuilder.DropTable(
                name: "Weapon");

            migrationBuilder.DropTable(
                name: "Character");
        }
    }
}
