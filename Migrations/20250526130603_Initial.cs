using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crud.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ای_دی = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    نام = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    شماره_تلفن = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    ایمیل = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ای_دی);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
