using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.netKlinikDb.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AspNetRoles",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(nullable: false),
            //        Name = table.Column<string>(maxLength: 256, nullable: true),
            //        NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
            //        ConcurrencyStamp = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //    });

        //    migrationBuilder.CreateTable(
        //        name: "AspNetUsers",
        //        columns: table => new
        //        {
        //            Id = table.Column<string>(nullable: false),
        //            UserName = table.Column<string>(maxLength: 256, nullable: true),
        //            NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
        //            Email = table.Column<string>(maxLength: 256, nullable: true),
        //            NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
        //            EmailConfirmed = table.Column<bool>(nullable: false),
        //            PasswordHash = table.Column<string>(nullable: true),
        //            SecurityStamp = table.Column<string>(nullable: true),
        //            ConcurrencyStamp = table.Column<string>(nullable: true),
        //            PhoneNumber = table.Column<string>(nullable: true),
        //            PhoneNumberConfirmed = table.Column<bool>(nullable: false),
        //            TwoFactorEnabled = table.Column<bool>(nullable: false),
        //            LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
        //            LockoutEnabled = table.Column<bool>(nullable: false),
        //            AccessFailedCount = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AspNetUsers", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Tenant",
        //        columns: table => new
        //        {
        //            TenantID = table.Column<string>(nullable: false),
        //            TenantName = table.Column<string>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Tenant", x => x.TenantID);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "User",
        //        columns: table => new
        //        {
        //            Username = table.Column<string>(nullable: false),
        //            FirstName = table.Column<string>(nullable: true),
        //            LastName = table.Column<string>(nullable: true),
        //            Password = table.Column<string>(nullable: true),
        //            Token = table.Column<string>(nullable: true),
        //            Email = table.Column<string>(nullable: true),
        //            Aturan = table.Column<string>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_User", x => x.Username);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "AspNetRoleClaims",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            RoleId = table.Column<string>(nullable: false),
        //            ClaimType = table.Column<string>(nullable: true),
        //            ClaimValue = table.Column<string>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
        //                column: x => x.RoleId,
        //                principalTable: "AspNetRoles",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "AspNetUserClaims",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            UserId = table.Column<string>(nullable: false),
        //            ClaimType = table.Column<string>(nullable: true),
        //            ClaimValue = table.Column<string>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
        //                column: x => x.UserId,
        //                principalTable: "AspNetUsers",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "AspNetUserLogins",
        //        columns: table => new
        //        {
        //            LoginProvider = table.Column<string>(nullable: false),
        //            ProviderKey = table.Column<string>(nullable: false),
        //            ProviderDisplayName = table.Column<string>(nullable: true),
        //            UserId = table.Column<string>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
        //            table.ForeignKey(
        //                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
        //                column: x => x.UserId,
        //                principalTable: "AspNetUsers",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "AspNetUserRoles",
        //        columns: table => new
        //        {
        //            UserId = table.Column<string>(nullable: false),
        //            RoleId = table.Column<string>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
        //            table.ForeignKey(
        //                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
        //                column: x => x.RoleId,
        //                principalTable: "AspNetRoles",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
        //                column: x => x.UserId,
        //                principalTable: "AspNetUsers",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "AspNetUserTokens",
        //        columns: table => new
        //        {
        //            UserId = table.Column<string>(nullable: false),
        //            LoginProvider = table.Column<string>(nullable: false),
        //            Name = table.Column<string>(nullable: false),
        //            Value = table.Column<string>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
        //            table.ForeignKey(
        //                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
        //                column: x => x.UserId,
        //                principalTable: "AspNetUsers",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "KatBarang",
        //        columns: table => new
        //        {
        //            IdKategori = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            NamaKategori = table.Column<string>(nullable: true),
        //            TenantID = table.Column<string>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_KatBarang", x => x.IdKategori);
        //            table.ForeignKey(
        //                name: "FK_KatBarang_Tenant_TenantID",
        //                column: x => x.TenantID,
        //                principalTable: "Tenant",
        //                principalColumn: "TenantID",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "KatJenis",
        //        columns: table => new
        //        {
        //            IdKatJenis = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            KategoriName = table.Column<string>(nullable: true),
        //            TenantID = table.Column<string>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_KatJenis", x => x.IdKatJenis);
        //            table.ForeignKey(
        //                name: "FK_KatJenis_Tenant_TenantID",
        //                column: x => x.TenantID,
        //                principalTable: "Tenant",
        //                principalColumn: "TenantID",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "TenantPengguna",
        //        columns: table => new
        //        {
        //            TenantPenggunaID = table.Column<string>(nullable: false),
        //            TenantID = table.Column<string>(nullable: true),
        //            Username = table.Column<string>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_TenantPengguna", x => x.TenantPenggunaID);
        //            table.ForeignKey(
        //                name: "FK_TenantPengguna_Tenant_TenantID",
        //                column: x => x.TenantID,
        //                principalTable: "Tenant",
        //                principalColumn: "TenantID",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Barang",
        //        columns: table => new
        //        {
        //            IdBarang = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            NamaBarang = table.Column<string>(nullable: true),
        //            Harga = table.Column<int>(nullable: false),
        //            Stok = table.Column<short>(nullable: false),
        //            IdKatBarang = table.Column<int>(nullable: false),
        //            Keterangan = table.Column<string>(nullable: true),
        //            Minstok = table.Column<int>(nullable: false),
        //            KatBarangIdKategori = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Barang", x => x.IdBarang);
        //            table.ForeignKey(
        //                name: "FK_Barang_KatBarang_KatBarangIdKategori",
        //                column: x => x.KatBarangIdKategori,
        //                principalTable: "KatBarang",
        //                principalColumn: "IdKategori",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "JenisTindakan",
        //        columns: table => new
        //        {
        //            IdJenisTindakan = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            IdKatJenis = table.Column<int>(nullable: false),
        //            Jenis = table.Column<string>(nullable: true),
        //            Biaya = table.Column<int>(nullable: false),
        //            BiayaKelipatan = table.Column<int>(nullable: true),
        //            Keterangan = table.Column<string>(nullable: true),
        //            TenantID = table.Column<string>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_JenisTindakan", x => x.IdJenisTindakan);
        //            table.ForeignKey(
        //                name: "FK_JenisTindakan_KatJenis_IdKatJenis",
        //                column: x => x.IdKatJenis,
        //                principalTable: "KatJenis",
        //                principalColumn: "IdKatJenis",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_JenisTindakan_Tenant_TenantID",
        //                column: x => x.TenantID,
        //                principalTable: "Tenant",
        //                principalColumn: "TenantID",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Pengguna",
        //        columns: table => new
        //        {
        //            Username = table.Column<string>(nullable: false),
        //            IdPasien = table.Column<string>(nullable: true),
        //            Nama = table.Column<string>(nullable: true),
        //            Gender = table.Column<string>(nullable: true),
        //            Umur = table.Column<short>(nullable: false),
        //            Alamat = table.Column<string>(nullable: true),
        //            Kota = table.Column<string>(nullable: true),
        //            NoTelpon = table.Column<string>(nullable: true),
        //            NoHP = table.Column<string>(nullable: true),
        //            TenantPenggunaID = table.Column<string>(nullable: true),
        //            rolename = table.Column<string>(nullable: true),
        //            Email = table.Column<string>(nullable: true),
        //            TenantPenggunaID1 = table.Column<string>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Pengguna", x => x.Username);
        //            table.ForeignKey(
        //                name: "FK_Pengguna_TenantPengguna_TenantPenggunaID1",
        //                column: x => x.TenantPenggunaID1,
        //                principalTable: "TenantPengguna",
        //                principalColumn: "TenantPenggunaID",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Beli",
        //        columns: table => new
        //        {
        //            IdBeli = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Tanggal = table.Column<DateTime>(nullable: false),
        //            NamaPembelian = table.Column<string>(nullable: true),
        //            Keterangan = table.Column<string>(nullable: true),
        //            TenantID = table.Column<string>(nullable: true),
        //            BarangIdBarang = table.Column<int>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Beli", x => x.IdBeli);
        //            table.ForeignKey(
        //                name: "FK_Beli_Barang_BarangIdBarang",
        //                column: x => x.BarangIdBarang,
        //                principalTable: "Barang",
        //                principalColumn: "IdBarang",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_Beli_Tenant_TenantID",
        //                column: x => x.TenantID,
        //                principalTable: "Tenant",
        //                principalColumn: "TenantID",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "DetailPasien",
        //        columns: table => new
        //        {
        //            DetailPasienID = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Registrasi = table.Column<DateTime>(nullable: false),
        //            RwPenyakit = table.Column<string>(nullable: true),
        //            Username = table.Column<string>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_DetailPasien", x => x.DetailPasienID);
        //            table.ForeignKey(
        //                name: "FK_DetailPasien_Pengguna_Username",
        //                column: x => x.Username,
        //                principalTable: "Pengguna",
        //                principalColumn: "Username",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "DetailPegawai",
        //        columns: table => new
        //        {
        //            DetailPegawaiID = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Jabatan = table.Column<string>(nullable: true),
        //            Gaji = table.Column<int>(nullable: false),
        //            TanggalJoin = table.Column<DateTime>(nullable: false),
        //            Username = table.Column<string>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_DetailPegawai", x => x.DetailPegawaiID);
        //            table.ForeignKey(
        //                name: "FK_DetailPegawai_Pengguna_Username",
        //                column: x => x.Username,
        //                principalTable: "Pengguna",
        //                principalColumn: "Username",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "PesananGigiPalsu",
        //        columns: table => new
        //        {
        //            IdPesanan = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            TanggalPesan = table.Column<DateTime>(nullable: false),
        //            JenisGigi = table.Column<string>(nullable: true),
        //            Username = table.Column<string>(nullable: true),
        //            IdPasien = table.Column<string>(nullable: true),
        //            HargaBeli = table.Column<int>(nullable: false),
        //            HargaJual = table.Column<int>(nullable: false),
        //            Status = table.Column<bool>(nullable: false),
        //            IdTindakanPesan = table.Column<int>(nullable: true),
        //            IdTransaksiPasang = table.Column<int>(nullable: false),
        //            Keterangan = table.Column<string>(nullable: true),
        //            TenantID = table.Column<string>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_PesananGigiPalsu", x => x.IdPesanan);
        //            table.ForeignKey(
        //                name: "FK_PesananGigiPalsu_Tenant_TenantID",
        //                column: x => x.TenantID,
        //                principalTable: "Tenant",
        //                principalColumn: "TenantID",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_PesananGigiPalsu_Pengguna_Username",
        //                column: x => x.Username,
        //                principalTable: "Pengguna",
        //                principalColumn: "Username",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Transaksi",
        //        columns: table => new
        //        {
        //            IdTransaksi = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            IdPasien = table.Column<string>(nullable: true),
        //            Username = table.Column<string>(nullable: true),
        //            Tanggal = table.Column<DateTime>(nullable: false),
        //            Anamnesis = table.Column<string>(nullable: true),
        //            Resep = table.Column<string>(nullable: true),
        //            TenantID = table.Column<string>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Transaksi", x => x.IdTransaksi);
        //            table.ForeignKey(
        //                name: "FK_Transaksi_Tenant_TenantID",
        //                column: x => x.TenantID,
        //                principalTable: "Tenant",
        //                principalColumn: "TenantID",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_Transaksi_Pengguna_Username",
        //                column: x => x.Username,
        //                principalTable: "Pengguna",
        //                principalColumn: "Username",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "DetailBeli",
        //        columns: table => new
        //        {
        //            DetailBeliId = table.Column<string>(nullable: false),
        //            IdBeli = table.Column<int>(nullable: false),
        //            Tanggal = table.Column<DateTime>(nullable: false),
        //            IdBarang = table.Column<int>(nullable: false),
        //            Qty = table.Column<short>(nullable: false),
        //            Harga = table.Column<int>(nullable: false),
        //            TotalHarga = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_DetailBeli", x => x.DetailBeliId);
        //            table.ForeignKey(
        //                name: "FK_DetailBeli_Barang_IdBarang",
        //                column: x => x.IdBarang,
        //                principalTable: "Barang",
        //                principalColumn: "IdBarang",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_DetailBeli_Beli_IdBeli",
        //                column: x => x.IdBeli,
        //                principalTable: "Beli",
        //                principalColumn: "IdBeli",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "DetailPenjualan",
        //        columns: table => new
        //        {
        //            DetailJualId = table.Column<string>(nullable: false),
        //            IdJual = table.Column<int>(nullable: false),
        //            IdBarang = table.Column<int>(nullable: false),
        //            Qty = table.Column<short>(nullable: false),
        //            Harga = table.Column<int>(nullable: false),
        //            beliIdBeli = table.Column<int>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_DetailPenjualan", x => x.DetailJualId);
        //            table.ForeignKey(
        //                name: "FK_DetailPenjualan_Barang_IdBarang",
        //                column: x => x.IdBarang,
        //                principalTable: "Barang",
        //                principalColumn: "IdBarang",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_DetailPenjualan_Beli_beliIdBeli",
        //                column: x => x.beliIdBeli,
        //                principalTable: "Beli",
        //                principalColumn: "IdBeli",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Penggajian",
        //        columns: table => new
        //        {
        //            IdGaji = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Username = table.Column<string>(nullable: true),
        //            TanggalGaji = table.Column<DateTime>(nullable: false),
        //            TanggalAwal = table.Column<DateTime>(nullable: true),
        //            TanggalAkhir = table.Column<DateTime>(nullable: true),
        //            TotalGaji = table.Column<int>(nullable: false),
        //            MasaWaktu = table.Column<string>(nullable: true),
        //            TenantID = table.Column<string>(nullable: true),
        //            DetailPegawaiID = table.Column<int>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Penggajian", x => x.IdGaji);
        //            table.ForeignKey(
        //                name: "FK_Penggajian_DetailPegawai_DetailPegawaiID",
        //                column: x => x.DetailPegawaiID,
        //                principalTable: "DetailPegawai",
        //                principalColumn: "DetailPegawaiID",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_Penggajian_Tenant_TenantID",
        //                column: x => x.TenantID,
        //                principalTable: "Tenant",
        //                principalColumn: "TenantID",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_Penggajian_Pengguna_Username",
        //                column: x => x.Username,
        //                principalTable: "Pengguna",
        //                principalColumn: "Username",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Prosentase",
        //        columns: table => new
        //        {
        //            IdProsentase = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            Username = table.Column<string>(nullable: true),
        //            IdJenisTindakan = table.Column<int>(nullable: false),
        //            Prosen = table.Column<double>(nullable: false),
        //            TenantID = table.Column<string>(nullable: true),
        //            DetailPegawaiID = table.Column<int>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Prosentase", x => x.IdProsentase);
        //            table.ForeignKey(
        //                name: "FK_Prosentase_DetailPegawai_DetailPegawaiID",
        //                column: x => x.DetailPegawaiID,
        //                principalTable: "DetailPegawai",
        //                principalColumn: "DetailPegawaiID",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_Prosentase_JenisTindakan_IdJenisTindakan",
        //                column: x => x.IdJenisTindakan,
        //                principalTable: "JenisTindakan",
        //                principalColumn: "IdJenisTindakan",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Prosentase_Tenant_TenantID",
        //                column: x => x.TenantID,
        //                principalTable: "Tenant",
        //                principalColumn: "TenantID",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_Prosentase_Pengguna_Username",
        //                column: x => x.Username,
        //                principalTable: "Pengguna",
        //                principalColumn: "Username",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Jual",
        //        columns: table => new
        //        {
        //            IdJual = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            IdTransaksi = table.Column<int>(nullable: false),
        //            NamaPenjualan = table.Column<string>(nullable: true),
        //            TenantID = table.Column<string>(nullable: true),
        //            BarangIdBarang = table.Column<int>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Jual", x => x.IdJual);
        //            table.ForeignKey(
        //                name: "FK_Jual_Barang_BarangIdBarang",
        //                column: x => x.BarangIdBarang,
        //                principalTable: "Barang",
        //                principalColumn: "IdBarang",
        //                onDelete: ReferentialAction.Restrict);
        //            table.ForeignKey(
        //                name: "FK_Jual_Transaksi_IdTransaksi",
        //                column: x => x.IdTransaksi,
        //                principalTable: "Transaksi",
        //                principalColumn: "IdTransaksi",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Jual_Tenant_TenantID",
        //                column: x => x.TenantID,
        //                principalTable: "Tenant",
        //                principalColumn: "TenantID",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Tindakan",
        //        columns: table => new
        //        {
        //            IdTindakan = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            IdTransaksi = table.Column<int>(nullable: false),
        //            Posisi = table.Column<string>(nullable: true),
        //            IdJenisTindakan = table.Column<int>(nullable: false),
        //            Biaya = table.Column<int>(nullable: false),
        //            Persenan = table.Column<int>(nullable: false),
        //            Diagnosis = table.Column<string>(nullable: true),
        //            BiayaDasar = table.Column<int>(nullable: true),
        //            BiayaKelipatan = table.Column<int>(nullable: true),
        //            Status = table.Column<string>(nullable: true),
        //            TenantID = table.Column<string>(nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Tindakan", x => x.IdTindakan);
        //            table.ForeignKey(
        //                name: "FK_Tindakan_JenisTindakan_IdJenisTindakan",
        //                column: x => x.IdJenisTindakan,
        //                principalTable: "JenisTindakan",
        //                principalColumn: "IdJenisTindakan",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Tindakan_Transaksi_IdTransaksi",
        //                column: x => x.IdTransaksi,
        //                principalTable: "Transaksi",
        //                principalColumn: "IdTransaksi",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_Tindakan_Tenant_TenantID",
        //                column: x => x.TenantID,
        //                principalTable: "Tenant",
        //                principalColumn: "TenantID",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "DetailPenggajian",
        //        columns: table => new
        //        {
        //            IdDetailGaji = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
        //            IdGaji = table.Column<int>(nullable: false),
        //            IdTransaksi = table.Column<int>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_DetailPenggajian", x => x.IdDetailGaji);
        //            table.ForeignKey(
        //                name: "FK_DetailPenggajian_Penggajian_IdGaji",
        //                column: x => x.IdGaji,
        //                principalTable: "Penggajian",
        //                principalColumn: "IdGaji",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_DetailPenggajian_Transaksi_IdTransaksi",
        //                column: x => x.IdTransaksi,
        //                principalTable: "Transaksi",
        //                principalColumn: "IdTransaksi",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_AspNetRoleClaims_RoleId",
        //        table: "AspNetRoleClaims",
        //        column: "RoleId");

        //    migrationBuilder.CreateIndex(
        //        name: "RoleNameIndex",
        //        table: "AspNetRoles",
        //        column: "NormalizedName",
        //        unique: true,
        //        filter: "[NormalizedName] IS NOT NULL");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_AspNetUserClaims_UserId",
        //        table: "AspNetUserClaims",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_AspNetUserLogins_UserId",
        //        table: "AspNetUserLogins",
        //        column: "UserId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_AspNetUserRoles_RoleId",
        //        table: "AspNetUserRoles",
        //        column: "RoleId");

        //    migrationBuilder.CreateIndex(
        //        name: "EmailIndex",
        //        table: "AspNetUsers",
        //        column: "NormalizedEmail");

        //    migrationBuilder.CreateIndex(
        //        name: "UserNameIndex",
        //        table: "AspNetUsers",
        //        column: "NormalizedUserName",
        //        unique: true,
        //        filter: "[NormalizedUserName] IS NOT NULL");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Barang_KatBarangIdKategori",
        //        table: "Barang",
        //        column: "KatBarangIdKategori");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Beli_BarangIdBarang",
        //        table: "Beli",
        //        column: "BarangIdBarang");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Beli_TenantID",
        //        table: "Beli",
        //        column: "TenantID");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_DetailBeli_IdBarang",
        //        table: "DetailBeli",
        //        column: "IdBarang");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_DetailBeli_IdBeli",
        //        table: "DetailBeli",
        //        column: "IdBeli");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_DetailPasien_Username",
        //        table: "DetailPasien",
        //        column: "Username");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_DetailPegawai_Username",
        //        table: "DetailPegawai",
        //        column: "Username");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_DetailPenggajian_IdGaji",
        //        table: "DetailPenggajian",
        //        column: "IdGaji");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_DetailPenggajian_IdTransaksi",
        //        table: "DetailPenggajian",
        //        column: "IdTransaksi");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_DetailPenjualan_IdBarang",
        //        table: "DetailPenjualan",
        //        column: "IdBarang");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_DetailPenjualan_beliIdBeli",
        //        table: "DetailPenjualan",
        //        column: "beliIdBeli");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_JenisTindakan_IdKatJenis",
        //        table: "JenisTindakan",
        //        column: "IdKatJenis");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_JenisTindakan_TenantID",
        //        table: "JenisTindakan",
        //        column: "TenantID");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Jual_BarangIdBarang",
        //        table: "Jual",
        //        column: "BarangIdBarang");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Jual_IdTransaksi",
        //        table: "Jual",
        //        column: "IdTransaksi");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Jual_TenantID",
        //        table: "Jual",
        //        column: "TenantID");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_KatBarang_TenantID",
        //        table: "KatBarang",
        //        column: "TenantID");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_KatJenis_TenantID",
        //        table: "KatJenis",
        //        column: "TenantID");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Penggajian_DetailPegawaiID",
        //        table: "Penggajian",
        //        column: "DetailPegawaiID");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Penggajian_TenantID",
        //        table: "Penggajian",
        //        column: "TenantID");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Penggajian_Username",
        //        table: "Penggajian",
        //        column: "Username");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Pengguna_TenantPenggunaID1",
        //        table: "Pengguna",
        //        column: "TenantPenggunaID1");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_PesananGigiPalsu_TenantID",
        //        table: "PesananGigiPalsu",
        //        column: "TenantID");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_PesananGigiPalsu_Username",
        //        table: "PesananGigiPalsu",
        //        column: "Username");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Prosentase_DetailPegawaiID",
        //        table: "Prosentase",
        //        column: "DetailPegawaiID");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Prosentase_IdJenisTindakan",
        //        table: "Prosentase",
        //        column: "IdJenisTindakan");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Prosentase_TenantID",
        //        table: "Prosentase",
        //        column: "TenantID");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Prosentase_Username",
        //        table: "Prosentase",
        //        column: "Username");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_TenantPengguna_TenantID",
        //        table: "TenantPengguna",
        //        column: "TenantID");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Tindakan_IdJenisTindakan",
        //        table: "Tindakan",
        //        column: "IdJenisTindakan");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Tindakan_IdTransaksi",
        //        table: "Tindakan",
        //        column: "IdTransaksi");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Tindakan_TenantID",
        //        table: "Tindakan",
        //        column: "TenantID");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Transaksi_TenantID",
        //        table: "Transaksi",
        //        column: "TenantID");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Transaksi_Username",
        //        table: "Transaksi",
        //        column: "Username");
        //}

        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropTable(
        //        name: "AspNetRoleClaims");

        //    migrationBuilder.DropTable(
        //        name: "AspNetUserClaims");

        //    migrationBuilder.DropTable(
        //        name: "AspNetUserLogins");

        //    migrationBuilder.DropTable(
        //        name: "AspNetUserRoles");

        //    migrationBuilder.DropTable(
        //        name: "AspNetUserTokens");

        //    migrationBuilder.DropTable(
        //        name: "DetailBeli");

        //    migrationBuilder.DropTable(
        //        name: "DetailPasien");

        //    migrationBuilder.DropTable(
        //        name: "DetailPenggajian");

        //    migrationBuilder.DropTable(
        //        name: "DetailPenjualan");

        //    migrationBuilder.DropTable(
        //        name: "Jual");

        //    migrationBuilder.DropTable(
        //        name: "PesananGigiPalsu");

        //    migrationBuilder.DropTable(
        //        name: "Prosentase");

        //    migrationBuilder.DropTable(
        //        name: "Tindakan");

        //    migrationBuilder.DropTable(
        //        name: "User");

        //    migrationBuilder.DropTable(
        //        name: "AspNetRoles");

        //    migrationBuilder.DropTable(
        //        name: "AspNetUsers");

        //    migrationBuilder.DropTable(
        //        name: "Penggajian");

        //    migrationBuilder.DropTable(
        //        name: "Beli");

        //    migrationBuilder.DropTable(
        //        name: "JenisTindakan");

        //    migrationBuilder.DropTable(
        //        name: "Transaksi");

        //    migrationBuilder.DropTable(
        //        name: "DetailPegawai");

        //    migrationBuilder.DropTable(
        //        name: "Barang");

        //    migrationBuilder.DropTable(
        //        name: "KatJenis");

        //    migrationBuilder.DropTable(
        //        name: "Pengguna");

        //    migrationBuilder.DropTable(
        //        name: "KatBarang");

        //    migrationBuilder.DropTable(
        //        name: "TenantPengguna");

        //    migrationBuilder.DropTable(
        //        name: "Tenant");
        }
    }

}
