using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tftwebapinew.Migrations
{
    /// <inheritdoc />
    public partial class Mukodj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Anomalies",
                columns: table => new
                {
                    AnomalyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AnomalyName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AnomalyEffect = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anomalies", x => x.AnomalyId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Augments",
                columns: table => new
                {
                    AugmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AugmentName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AugmentRarity = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AugmentEffect = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Augments", x => x.AugmentId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    CharacterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CharacterName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AbilityName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ability = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Health1 = table.Column<int>(type: "int", nullable: false),
                    Health2 = table.Column<int>(type: "int", nullable: false),
                    AttackSpeed = table.Column<double>(type: "double", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    Damage1 = table.Column<int>(type: "int", nullable: false),
                    Damage2 = table.Column<int>(type: "int", nullable: false),
                    AbilityPower = table.Column<int>(type: "int", nullable: false),
                    ManaStart = table.Column<int>(type: "int", nullable: false),
                    ManaMax = table.Column<int>(type: "int", nullable: false),
                    Armor = table.Column<int>(type: "int", nullable: false),
                    MagicResist = table.Column<int>(type: "int", nullable: false),
                    Range = table.Column<int>(type: "int", nullable: false),
                    Characterimageblob = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.CharacterID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClassName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BasicEffect = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Classimageblob = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.ClassId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FullItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Halfitemeffect1 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Halfitemeffect2 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    bonuseffect = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    bonuseffect1 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    bonuseffect2 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ActiveEffect = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fullitemimageblob = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullItems", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PartialItems",
                columns: table => new
                {
                    partial_item_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    effect = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    halfitemimageBlob = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartialItems", x => x.partial_item_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "boardHexes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Board_id = table.Column<int>(type: "int", nullable: false),
                    CharacterID = table.Column<int>(type: "int", nullable: false),
                    hex_x = table.Column<int>(type: "int", nullable: false),
                    hex_y = table.Column<int>(type: "int", nullable: false),
                    PostCharacterCharacterID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_boardHexes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_boardHexes_Character_PostCharacterCharacterID",
                        column: x => x.PostCharacterCharacterID,
                        principalTable: "Character",
                        principalColumn: "CharacterID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "characterclass",
                columns: table => new
                {
                    CharacterID = table.Column<int>(type: "int", nullable: false),
                    ClassID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.CharacterID, x.ClassID });
                    table.ForeignKey(
                        name: "characterclass_ibfk_1",
                        column: x => x.CharacterID,
                        principalTable: "Character",
                        principalColumn: "CharacterID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "characterclass_ibfk_2",
                        column: x => x.ClassID,
                        principalTable: "Class",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Classlevelbonus",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    CharacterCount = table.Column<int>(type: "int", nullable: true),
                    BonusEffect = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classlevelbonus", x => new { x.ClassId, x.Level });
                    table.ForeignKey(
                        name: "FK_Classlevelbonus_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FullItems_PartialItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FullItemId = table.Column<int>(type: "int", nullable: false),
                    PartialItemId1 = table.Column<int>(type: "int", nullable: false),
                    PartialItemId2 = table.Column<int>(type: "int", nullable: false),
                    PostFullitemId = table.Column<int>(type: "int", nullable: true),
                    PostFullitem_PartialitemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullItems_PartialItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FullItems_PartialItems_FullItems_PartialItems_PostFullitem_P~",
                        column: x => x.PostFullitem_PartialitemId,
                        principalTable: "FullItems_PartialItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FullItems_PartialItems_FullItems_PostFullitemId",
                        column: x => x.PostFullitemId,
                        principalTable: "FullItems",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LoginName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Hash = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Salt = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProfilePicturePath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Board",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Board_id = table.Column<int>(type: "int", nullable: false),
                    Boardname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PostUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Board", x => x.id);
                    table.ForeignKey(
                        name: "FK_Board_User_PostUserId",
                        column: x => x.PostUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Board_PostUserId",
                table: "Board",
                column: "PostUserId");

            migrationBuilder.CreateIndex(
                name: "IX_boardHexes_PostCharacterCharacterID",
                table: "boardHexes",
                column: "PostCharacterCharacterID");

            migrationBuilder.CreateIndex(
                name: "ClassID",
                table: "characterclass",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_FullItems_PartialItems_PostFullitem_PartialitemId",
                table: "FullItems_PartialItems",
                column: "PostFullitem_PartialitemId");

            migrationBuilder.CreateIndex(
                name: "IX_FullItems_PartialItems_PostFullitemId",
                table: "FullItems_PartialItems",
                column: "PostFullitemId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PermissionId",
                table: "User",
                column: "PermissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anomalies");

            migrationBuilder.DropTable(
                name: "Augments");

            migrationBuilder.DropTable(
                name: "Board");

            migrationBuilder.DropTable(
                name: "boardHexes");

            migrationBuilder.DropTable(
                name: "characterclass");

            migrationBuilder.DropTable(
                name: "Classlevelbonus");

            migrationBuilder.DropTable(
                name: "FullItems_PartialItems");

            migrationBuilder.DropTable(
                name: "PartialItems");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "FullItems");

            migrationBuilder.DropTable(
                name: "Permissions");
        }
    }
}
