using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SonOfCodSeafood.Migrations
{
    public partial class AddNameToNewletter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "NewsletterMembers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "NewsletterMembers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "NewsletterMembers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "NewsletterMembers");
        }
    }
}
