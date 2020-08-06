using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.netKlinikDb.Migrations
{
    public partial class ExtendIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Pengguna_TenantPengguna_TenantPenggunaID1",
            //    table: "Pengguna");

            migrationBuilder.DropIndex(
                name: "IX_DetailPasien_Username",
                table: "DetailPasien");

            migrationBuilder.DropColumn(
                name: "TenantPenggunaID",
                table: "Pengguna");

            //migrationBuilder.RenameColumn(
            //    name: "TenantPenggunaID1",
            //    table: "Pengguna",
            //    newName: "TenantID");

            //migrationBuilder.RenameIndex(
            //    name: "IX_Pengguna_TenantPenggunaID1",
            //    table: "Pengguna",
            //    newName: "IX_Pengguna_TenantID");

            migrationBuilder.AddColumn<int>(
                name: "DetailPasienID",
                table: "Transaksi",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "TenantPengguna",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DetailPasienID",
                table: "PesananGigiPalsu",
                nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "IdPasien",
            //    table: "DetailPasien",
            //    nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Transaksi_DetailPasienID",
                table: "Transaksi",
                column: "DetailPasienID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TenantPengguna_Username",
            //    table: "TenantPengguna",
            //    column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_PesananGigiPalsu_DetailPasienID",
                table: "PesananGigiPalsu",
                column: "DetailPasienID");

            migrationBuilder.CreateIndex(
                name: "IX_DetailPasien_Username",
                table: "DetailPasien",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Pengguna_Tenant_TenantID",
                table: "Pengguna",
                column: "TenantID",
                principalTable: "Tenant",
                principalColumn: "TenantID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PesananGigiPalsu_DetailPasien_DetailPasienID",
                table: "PesananGigiPalsu",
                column: "DetailPasienID",
                principalTable: "DetailPasien",
                principalColumn: "DetailPasienID",
                onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_TenantPengguna_Pengguna_Username",
            //    table: "TenantPengguna",
            //    column: "Username",
            //    principalTable: "Pengguna",
            //    principalColumn: "Username",
            //    onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaksi_DetailPasien_DetailPasienID",
                table: "Transaksi",
                column: "DetailPasienID",
                principalTable: "DetailPasien",
                principalColumn: "DetailPasienID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pengguna_Tenant_TenantID",
                table: "Pengguna");

            migrationBuilder.DropForeignKey(
                name: "FK_PesananGigiPalsu_DetailPasien_DetailPasienID",
                table: "PesananGigiPalsu");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantPengguna_Pengguna_Username",
                table: "TenantPengguna");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaksi_DetailPasien_DetailPasienID",
                table: "Transaksi");

            migrationBuilder.DropIndex(
                name: "IX_Transaksi_DetailPasienID",
                table: "Transaksi");

            migrationBuilder.DropIndex(
                name: "IX_TenantPengguna_Username",
                table: "TenantPengguna");

            migrationBuilder.DropIndex(
                name: "IX_PesananGigiPalsu_DetailPasienID",
                table: "PesananGigiPalsu");

            migrationBuilder.DropIndex(
                name: "IX_DetailPasien_Username",
                table: "DetailPasien");

            migrationBuilder.DropColumn(
                name: "DetailPasienID",
                table: "Transaksi");

            migrationBuilder.DropColumn(
                name: "DetailPasienID",
                table: "PesananGigiPalsu");

            migrationBuilder.DropColumn(
                name: "IdPasien",
                table: "DetailPasien");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "TenantID",
                table: "Pengguna",
                newName: "TenantPenggunaID1");

            migrationBuilder.RenameIndex(
                name: "IX_Pengguna_TenantID",
                table: "Pengguna",
                newName: "IX_Pengguna_TenantPenggunaID1");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "TenantPengguna",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenantPenggunaID",
                table: "Pengguna",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetailPasien_Username",
                table: "DetailPasien",
                column: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_Pengguna_TenantPengguna_TenantPenggunaID1",
                table: "Pengguna",
                column: "TenantPenggunaID1",
                principalTable: "TenantPengguna",
                principalColumn: "TenantPenggunaID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
