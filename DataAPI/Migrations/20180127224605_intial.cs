using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataApi.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderHeaders",
                columns: table => new
                {
                    clientID = table.Column<string>(maxLength: 50, nullable: false),
                    orderID = table.Column<string>(maxLength: 50, nullable: false),
                    busAddr1 = table.Column<string>(maxLength: 50, nullable: true),
                    busAddr2 = table.Column<string>(maxLength: 50, nullable: true),
                    busCity = table.Column<string>(maxLength: 50, nullable: true),
                    busCountry = table.Column<string>(maxLength: 50, nullable: true),
                    busName = table.Column<string>(maxLength: 50, nullable: true),
                    busState = table.Column<string>(maxLength: 50, nullable: true),
                    busZip = table.Column<string>(maxLength: 50, nullable: true),
                    contTel = table.Column<string>(maxLength: 50, nullable: true),
                    dcNum = table.Column<string>(maxLength: 50, nullable: true),
                    deptNum = table.Column<string>(maxLength: 50, nullable: true),
                    ordNum = table.Column<string>(maxLength: 50, nullable: true),
                    orderType = table.Column<string>(maxLength: 50, nullable: true),
                    paymentType = table.Column<string>(maxLength: 50, nullable: true),
                    poNum = table.Column<string>(maxLength: 50, nullable: true),
                    reqDeliveryDate = table.Column<string>(maxLength: 50, nullable: true),
                    reqShipDate = table.Column<string>(maxLength: 50, nullable: true),
                    rsaFlag = table.Column<string>(maxLength: 50, nullable: true),
                    rushFlag = table.Column<string>(maxLength: 50, nullable: true),
                    salesOrdNum = table.Column<string>(maxLength: 50, nullable: true),
                    serviceLevel = table.Column<string>(maxLength: 50, nullable: true),
                    shipAddr1 = table.Column<string>(maxLength: 50, nullable: true),
                    shipAddr2 = table.Column<string>(maxLength: 50, nullable: true),
                    shipCity = table.Column<string>(maxLength: 50, nullable: true),
                    shipCountry = table.Column<string>(maxLength: 50, nullable: true),
                    shipName = table.Column<string>(maxLength: 50, nullable: true),
                    shipState = table.Column<string>(maxLength: 50, nullable: true),
                    shipToCustNum = table.Column<string>(maxLength: 50, nullable: true),
                    shipZip = table.Column<string>(maxLength: 50, nullable: true),
                    soldToCustNum = table.Column<string>(maxLength: 50, nullable: true),
                    storeName = table.Column<string>(maxLength: 50, nullable: true),
                    storeNum = table.Column<string>(maxLength: 50, nullable: true),
                    totalPrice = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeaders", x => new { x.clientID, x.orderID });
                });

            migrationBuilder.CreateTable(
                name: "ShipConfirms",
                columns: table => new
                {
                    clientID = table.Column<string>(maxLength: 50, nullable: false),
                    orderID = table.Column<string>(maxLength: 50, nullable: false),
                    hasSent = table.Column<bool>(nullable: false),
                    trackNum = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipConfirms", x => new { x.clientID, x.orderID });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderHeaders");

            migrationBuilder.DropTable(
                name: "ShipConfirms");
        }
    }
}
