using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hermes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Addedinitialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MailRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorUsername = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    PatientUsername = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MailTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    SenderEmail = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    TargetEmail = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    MailSubject = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    MailBody = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailTemplates", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MailRequests");

            migrationBuilder.DropTable(
                name: "MailTemplates");
        }
    }
}
