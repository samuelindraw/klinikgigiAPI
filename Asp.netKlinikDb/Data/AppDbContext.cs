using Asp.netKlinikDb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Barang> Barang { get; set; }
        public DbSet<Beli> Beli { get; set; }
        public DbSet<DetailPenggajian> DetailPenggajian { get; set; }
        public DbSet<DetailPasien> DetailPasien { get; set; }
        public DbSet<DetailBeli> DetailBeli { get; set; }
        public DbSet<DetailJual> DetailPenjualan { get; set; }
        public DbSet<DetailPegawai> DetailPegawai { get; set; }
        public DbSet<JenisTindakan> JenisTindakan { get; set; }
        public DbSet<Jual> Jual { get; set; }
        public DbSet<KatBarang> KatBarang { get; set; }
        public DbSet<KatJenis> KatJenis { get; set; }
        public DbSet<Penggajian> Penggajian { get; set; }
        public DbSet<Pengguna> Pengguna { get; set; }
        public DbSet<PesananGigiPalsu> PesananGigiPalsu { get; set; }
        public DbSet<Prosentase> Prosentase { get; set; }
        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<TenantPengguna> TenantPengguna { get; set; }
        public DbSet<Tindakan> Tindakan { get; set; }
        public DbSet<Transaksi> Transaksi { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }





    }
}
