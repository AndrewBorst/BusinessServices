using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShipConfirms",
                columns: table => new
                {
                    ClientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HasSent = table.Column<bool>(type: "bit", nullable: false),
                    TrackNum = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipConfirms", x => new { x.ClientID, x.OrderID });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShipConfirms");
        }
    }
}
