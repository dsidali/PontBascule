using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PontBascule.Model.Migrations
{
    /// <inheritdoc />
    public partial class bigbang2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parcs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    actuel = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Privileges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privileges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transporteurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Interne = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transporteurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeDeCamions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeCamion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeDeCamions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeDeTransports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeTransport = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeDeTransports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeProduits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypedeProduit = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeProduits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Achats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumBonA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParcId = table.Column<int>(type: "int", nullable: false),
                    Mat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transporteur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeureOP = table.Column<TimeSpan>(type: "time", nullable: false),
                    NumTicket = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PCC = table.Column<int>(type: "int", nullable: false),
                    PCV = table.Column<int>(type: "int", nullable: false),
                    PB = table.Column<int>(type: "int", nullable: false),
                    PQRa = table.Column<int>(type: "int", nullable: false),
                    PQS = table.Column<int>(type: "int", nullable: false),
                    Termine = table.Column<bool>(type: "bit", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FournisseurOuClient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeTransport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeCamion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Achats_Parcs_ParcId",
                        column: x => x.ParcId,
                        principalTable: "Parcs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pesages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumBonA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParcId = table.Column<int>(type: "int", nullable: false),
                    Mat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transporteur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeTransport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeCamion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeureOP = table.Column<TimeSpan>(type: "time", nullable: false),
                    NumTicket = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PCC = table.Column<int>(type: "int", nullable: false),
                    PCV = table.Column<int>(type: "int", nullable: false),
                    QP = table.Column<int>(type: "int", nullable: false),
                    Termine = table.Column<bool>(type: "bit", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pesages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pesages_Parcs_ParcId",
                        column: x => x.ParcId,
                        principalTable: "Parcs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceptionRondBetons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumBonA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParcId = table.Column<int>(type: "int", nullable: false),
                    Mat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeureOP = table.Column<TimeSpan>(type: "time", nullable: false),
                    NumTicket = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PCC = table.Column<int>(type: "int", nullable: false),
                    PCV = table.Column<int>(type: "int", nullable: false),
                    PB = table.Column<int>(type: "int", nullable: false),
                    PQRa = table.Column<int>(type: "int", nullable: false),
                    PQS = table.Column<int>(type: "int", nullable: false),
                    Termine = table.Column<bool>(type: "bit", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FournisseurOuClient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transporteur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeTransport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeCamion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceptionRondBetons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceptionRondBetons_Parcs_ParcId",
                        column: x => x.ParcId,
                        principalTable: "Parcs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SortieRondBetons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumBonA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParcId = table.Column<int>(type: "int", nullable: false),
                    Mat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeureOP = table.Column<TimeSpan>(type: "time", nullable: false),
                    NumTicket = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PCC = table.Column<int>(type: "int", nullable: false),
                    PCV = table.Column<int>(type: "int", nullable: false),
                    PB = table.Column<int>(type: "int", nullable: false),
                    PQRa = table.Column<int>(type: "int", nullable: false),
                    PQS = table.Column<int>(type: "int", nullable: false),
                    Termine = table.Column<bool>(type: "bit", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FournisseurOuClient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transporteur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeTransport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeCamion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SortieRondBetons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SortieRondBetons_Parcs_ParcId",
                        column: x => x.ParcId,
                        principalTable: "Parcs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParcId = table.Column<int>(type: "int", nullable: false),
                    PrivilegeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Utilisateurs_Parcs_ParcId",
                        column: x => x.ParcId,
                        principalTable: "Parcs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Utilisateurs_Privileges_PrivilegeId",
                        column: x => x.PrivilegeId,
                        principalTable: "Privileges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceptionTransferts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumBL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParcId = table.Column<int>(type: "int", nullable: false),
                    DateOp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeureOP = table.Column<TimeSpan>(type: "time", nullable: false),
                    TypeProduitId = table.Column<int>(type: "int", nullable: false),
                    PCC = table.Column<int>(type: "int", nullable: false),
                    PCV = table.Column<int>(type: "int", nullable: false),
                    PQR = table.Column<int>(type: "int", nullable: false),
                    Termine = table.Column<bool>(type: "bit", nullable: false),
                    Mat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Provenance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transporteur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeTransport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeCamion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceptionTransferts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceptionTransferts_Parcs_ParcId",
                        column: x => x.ParcId,
                        principalTable: "Parcs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceptionTransferts_TypeProduits_TypeProduitId",
                        column: x => x.TypeProduitId,
                        principalTable: "TypeProduits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SortieTransferts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumBL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParcId = table.Column<int>(type: "int", nullable: false),
                    DateOp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeureOP = table.Column<TimeSpan>(type: "time", nullable: false),
                    PCC = table.Column<int>(type: "int", nullable: false),
                    PCV = table.Column<int>(type: "int", nullable: false),
                    PQS = table.Column<int>(type: "int", nullable: false),
                    TypeProduitId = table.Column<int>(type: "int", nullable: false),
                    Termine = table.Column<bool>(type: "bit", nullable: false),
                    Mat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transporteur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeTransport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeCamion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SortieTransferts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SortieTransferts_Parcs_ParcId",
                        column: x => x.ParcId,
                        principalTable: "Parcs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SortieTransferts_TypeProduits_TypeProduitId",
                        column: x => x.TypeProduitId,
                        principalTable: "TypeProduits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeProduitId = table.Column<int>(type: "int", nullable: false),
                    DateJour = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_TypeProduits_TypeProduitId",
                        column: x => x.TypeProduitId,
                        principalTable: "TypeProduits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Achats_ParcId",
                table: "Achats",
                column: "ParcId");

            migrationBuilder.CreateIndex(
                name: "IX_Pesages_ParcId",
                table: "Pesages",
                column: "ParcId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceptionRondBetons_ParcId",
                table: "ReceptionRondBetons",
                column: "ParcId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceptionTransferts_ParcId",
                table: "ReceptionTransferts",
                column: "ParcId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceptionTransferts_TypeProduitId",
                table: "ReceptionTransferts",
                column: "TypeProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_SortieRondBetons_ParcId",
                table: "SortieRondBetons",
                column: "ParcId");

            migrationBuilder.CreateIndex(
                name: "IX_SortieTransferts_ParcId",
                table: "SortieTransferts",
                column: "ParcId");

            migrationBuilder.CreateIndex(
                name: "IX_SortieTransferts_TypeProduitId",
                table: "SortieTransferts",
                column: "TypeProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_TypeProduitId",
                table: "Stocks",
                column: "TypeProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_ParcId",
                table: "Utilisateurs",
                column: "ParcId");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_PrivilegeId",
                table: "Utilisateurs",
                column: "PrivilegeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achats");

            migrationBuilder.DropTable(
                name: "Pesages");

            migrationBuilder.DropTable(
                name: "ReceptionRondBetons");

            migrationBuilder.DropTable(
                name: "ReceptionTransferts");

            migrationBuilder.DropTable(
                name: "SortieRondBetons");

            migrationBuilder.DropTable(
                name: "SortieTransferts");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Transporteurs");

            migrationBuilder.DropTable(
                name: "TypeDeCamions");

            migrationBuilder.DropTable(
                name: "TypeDeTransports");

            migrationBuilder.DropTable(
                name: "Utilisateurs");

            migrationBuilder.DropTable(
                name: "TypeProduits");

            migrationBuilder.DropTable(
                name: "Parcs");

            migrationBuilder.DropTable(
                name: "Privileges");
        }
    }
}
