﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_commerce_program.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Elektronik och tekniska produkter", "Electronics" },
                    { 2, "Produkter för hemmet och köket", "Home & Kitchen" },
                    { 3, "Kläder och accessoarer", "Clothing" },
                    { 4, "Sportutrustning och träningsprodukter", "Sports" },
                    { 5, "Böcker och litteratur", "Books" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Storgatan 1, Stockholm", "anders@example.com", "Anders Svensson", "070-111-2233" },
                    { 2, "Kungsgatan 15, Göteborg", "emma@example.com", "Emma Johansson", "073-222-3344" },
                    { 3, "Drottninggatan 8, Malmö", "lars@example.com", "Lars Nilsson", "076-333-4455" },
                    { 4, "Sveavägen 22, Uppsala", "sofia@example.com", "Sofia Lindgren", "072-444-5566" },
                    { 5, "Järntorget 5, Göteborg", "peter@example.com", "Peter Karlsson", "070-555-6677" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "ContactPerson", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Anna Lindberg", "anna@techvision.se", "TechVision AB", "070-123-4567" },
                    { 2, "Johan Bergman", "johan@homestyle.se", "HomeStyle", "073-234-5678" },
                    { 3, "Maria Ek", "maria@fashionfirst.se", "Fashion First", "076-345-6789" },
                    { 4, "Erik Strand", "erik@sportmax.se", "SportMax", "072-456-7890" },
                    { 5, "Karl Holm", "karl@nordicelec.se", "Nordic Electronics", "070-567-8901" },
                    { 6, "Lisa Björk", "lisa@globalgadgets.se", "Global Gadgets", "073-678-9012" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CustomerId", "OrderDate", "Status", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2021), "Levererad", 11999.0 },
                    { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2017), "Levererad ", 9798.0 },
                    { 3, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2012), "Behandlas", 18999.0 },
                    { 4, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2010), "Levererad", 3499.0 },
                    { 5, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2007), "Skickad", 16994.0 },
                    { 6, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2003), "Levererad", 899.0 },
                    { 7, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1998), "Levererad", 2498.0 },
                    { 8, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2004), "Skickad", 1598.0 },
                    { 9, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2002), "Behandlas", 5794.0 },
                    { 10, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(2000), "Behandlas", 1299.0 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Name", "Price", "StockQuantity", "SupplierId" },
                values: new object[,]
                {
                    { 1, 1, "Smartphone med 128GB lagring", "iPhone 13 Pro", 11999, 15, 1 },
                    { 2, 1, "4K Smart TV med HDR", "Samsung TV 55\"", 8999, 8, 5 },
                    { 3, 1, "Trådlösa hörlurar med brusreducering", "Sony WH-1000XM4", 3499, 7, 5 },
                    { 4, 1, "Laptop med M1-chip och 8GB RAM", "MacBook Air", 12499, 12, 1 },
                    { 5, 2, "Automatisk espressomaskin", "Espressomaskin", 4995, 6, 2 },
                    { 6, 2, "Multifunktionell köksmaskin", "Matberedare", 1299, 20, 2 },
                    { 7, 3, "Varm jacka för vinterbruk", "Vinterjacka", 1999, 25, 3 },
                    { 8, 4, "Skor för långdistanslöpning", "Löparskor", 1499, 18, 4 },
                    { 9, 4, "Halkfri yogamatta", "Yogamatta", 349, 30, 4 },
                    { 10, 5, "Populär skönlitterär roman", "Bestsellerroman", 249, 40, 2 },
                    { 11, 1, "Högpresterande dator för gaming", "Gaming PC", 18999, 5, 6 },
                    { 12, 1, "10\" surfplatta med WiFi", "Tablet", 4299, 9, 5 },
                    { 13, 1, "Portabel högtalare med 20h batteritid", "Bluetooth-högtalare", 899, 22, 6 },
                    { 14, 2, "Programmerbar kaffebryggare", "Kaffebryggare", 799, 14, 2 },
                    { 15, 3, "Funktionströja för träning", "Träningströja", 499, 35, 3 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderDetailId", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 11999.0 },
                    { 2, 2, 3, 2, 3499.0 },
                    { 3, 2, 13, 3, 899.0 },
                    { 4, 3, 11, 1, 18999.0 },
                    { 5, 4, 3, 1, 3499.0 },
                    { 6, 5, 4, 1, 12499.0 },
                    { 7, 5, 5, 1, 4495.0 },
                    { 8, 6, 13, 1, 899.0 },
                    { 9, 7, 8, 1, 1499.0 },
                    { 10, 7, 9, 3, 349.0 },
                    { 11, 8, 7, 1, 1999.0 },
                    { 12, 8, 15, 3, 499.0 },
                    { 13, 9, 2, 1, 8999.0 },
                    { 14, 9, 6, 1, 1299.0 },
                    { 15, 9, 14, 2, 799.0 },
                    { 16, 10, 6, 1, 1299.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
