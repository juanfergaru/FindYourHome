using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindYourHome.API.Migrations
{
    /// <inheritdoc />
    public partial class inicialV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContractId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OwnershipId",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ContractId",
                table: "Payments",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_OwnershipId",
                table: "Contracts",
                column: "OwnershipId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_TenantId",
                table: "Contracts",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Ownerships_OwnershipId",
                table: "Contracts",
                column: "OwnershipId",
                principalTable: "Ownerships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Tenants_TenantId",
                table: "Contracts",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Contracts_ContractId",
                table: "Payments",
                column: "ContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Ownerships_OwnershipId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Tenants_TenantId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Contracts_ContractId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_ContractId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_OwnershipId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_TenantId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "OwnershipId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Contracts");
        }
    }
}
