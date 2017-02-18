using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SonOfCodSeafood.Migrations
{
    public partial class AddRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "NewsletterMembers",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "NewsletterMembers",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "NewsletterMembers",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "NewsletterMembers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "NewsletterMembers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "NewsletterMembers",
                nullable: true);
        }
    }
}
