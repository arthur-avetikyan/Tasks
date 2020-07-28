using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.DAL.Migrations
{
    public partial class FKConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Price_Product_ProductId",
                table: "Price");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Product_ProductId",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Stock_ProductId",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Price_ProductId",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Price");

            migrationBuilder.AddColumn<Guid>(
                name: "PriceId",
                table: "Product",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StockId",
                table: "Product",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Product_PriceId",
                table: "Product",
                column: "PriceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_StockId",
                table: "Product",
                column: "StockId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Price_PriceId",
                table: "Product",
                column: "PriceId",
                principalTable: "Price",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Stock_StockId",
                table: "Product",
                column: "StockId",
                principalTable: "Stock",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Price_PriceId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Stock_StockId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_PriceId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_StockId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "Product");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Stock",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Price",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Stock_ProductId",
                table: "Stock",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Price_ProductId",
                table: "Price",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Price_Product_ProductId",
                table: "Price",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Product_ProductId",
                table: "Stock",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
