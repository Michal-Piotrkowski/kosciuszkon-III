using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace oodajze.backend.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CollectionPoints",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionPoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CouponTemplates",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    PointsRequired = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Available = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    TotalPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CollectionVisitQrDatas",
                columns: table => new
                {
                    CollectionVisitId = table.Column<string>(type: "TEXT", nullable: false),
                    CollectionPointId = table.Column<string>(type: "TEXT", nullable: false),
                    ScannedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PointsEarned = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionVisitQrDatas", x => x.CollectionVisitId);
                    table.ForeignKey(
                        name: "FK_CollectionVisitQrDatas_CollectionPoints_CollectionPointId",
                        column: x => x.CollectionPointId,
                        principalTable: "CollectionPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectionVisitQrDatas_Users_CollectionVisitId",
                        column: x => x.CollectionVisitId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCoupons",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    CouponTemplateId = table.Column<string>(type: "TEXT", nullable: false),
                    RedeemedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsUsed = table.Column<bool>(type: "INTEGER", nullable: false),
                    RedemptionCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCoupons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCoupons_CouponTemplates_CouponTemplateId",
                        column: x => x.CouponTemplateId,
                        principalTable: "CouponTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCoupons_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductQrDatas",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "TEXT", nullable: false),
                    ProductCode = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    BatchNumber = table.Column<string>(type: "TEXT", nullable: false),
                    MaterialType = table.Column<string>(type: "TEXT", nullable: false),
                    RecyclingCode = table.Column<string>(type: "TEXT", nullable: false),
                    Points = table.Column<int>(type: "INTEGER", nullable: false),
                    CollectionVisitQrDataCollectionVisitId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductQrDatas", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductQrDatas_CollectionVisitQrDatas_CollectionVisitQrDataCollectionVisitId",
                        column: x => x.CollectionVisitQrDataCollectionVisitId,
                        principalTable: "CollectionVisitQrDatas",
                        principalColumn: "CollectionVisitId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionVisitQrDatas_CollectionPointId",
                table: "CollectionVisitQrDatas",
                column: "CollectionPointId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductQrDatas_CollectionVisitQrDataCollectionVisitId",
                table: "ProductQrDatas",
                column: "CollectionVisitQrDataCollectionVisitId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCoupons_CouponTemplateId",
                table: "UserCoupons",
                column: "CouponTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCoupons_UserId",
                table: "UserCoupons",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductQrDatas");

            migrationBuilder.DropTable(
                name: "UserCoupons");

            migrationBuilder.DropTable(
                name: "CollectionVisitQrDatas");

            migrationBuilder.DropTable(
                name: "CouponTemplates");

            migrationBuilder.DropTable(
                name: "CollectionPoints");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
