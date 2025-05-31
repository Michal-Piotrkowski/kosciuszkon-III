using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace oodajze.backend.Migrations
{
    /// <inheritdoc />
    public partial class ChangedIdInModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionVisitQrDatas_Users_CollectionVisitId",
                table: "CollectionVisitQrDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductQrDatas_CollectionVisitQrDatas_CollectionVisitQrDataCollectionVisitId",
                table: "ProductQrDatas");

            migrationBuilder.RenameColumn(
                name: "CollectionVisitQrDataCollectionVisitId",
                table: "ProductQrDatas",
                newName: "CollectionVisitQrDataId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductQrDatas",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ProductQrDatas_CollectionVisitQrDataCollectionVisitId",
                table: "ProductQrDatas",
                newName: "IX_ProductQrDatas_CollectionVisitQrDataId");

            migrationBuilder.RenameColumn(
                name: "CollectionVisitId",
                table: "CollectionVisitQrDatas",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionVisitQrDatas_Users_Id",
                table: "CollectionVisitQrDatas",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductQrDatas_CollectionVisitQrDatas_CollectionVisitQrDataId",
                table: "ProductQrDatas",
                column: "CollectionVisitQrDataId",
                principalTable: "CollectionVisitQrDatas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionVisitQrDatas_Users_Id",
                table: "CollectionVisitQrDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductQrDatas_CollectionVisitQrDatas_CollectionVisitQrDataId",
                table: "ProductQrDatas");

            migrationBuilder.RenameColumn(
                name: "CollectionVisitQrDataId",
                table: "ProductQrDatas",
                newName: "CollectionVisitQrDataCollectionVisitId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProductQrDatas",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductQrDatas_CollectionVisitQrDataId",
                table: "ProductQrDatas",
                newName: "IX_ProductQrDatas_CollectionVisitQrDataCollectionVisitId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CollectionVisitQrDatas",
                newName: "CollectionVisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionVisitQrDatas_Users_CollectionVisitId",
                table: "CollectionVisitQrDatas",
                column: "CollectionVisitId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductQrDatas_CollectionVisitQrDatas_CollectionVisitQrDataCollectionVisitId",
                table: "ProductQrDatas",
                column: "CollectionVisitQrDataCollectionVisitId",
                principalTable: "CollectionVisitQrDatas",
                principalColumn: "CollectionVisitId");
        }
    }
}
