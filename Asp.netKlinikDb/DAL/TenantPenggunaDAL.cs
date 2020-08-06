using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.DAL
{
    public class TenantPenggunaDAL : ITenantPengguna
    {
        private AppDbContext _context;
        public TenantPenggunaDAL(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(TenantPengguna obj)
        {
            
            var data = await getuserbytenantid(obj.TenantID);//ini hasilnya list
            //stelah data tenant di dapat maka menncari
            //var result = data.Where(e => e.Username == obj.Username).ToList();
            //bingung efektif mana
            var cara2 = await tenantforusername(obj.TenantID, obj.Username);
            //mencari data tenant ccc
            if (cara2 == null)
            {
                _context.Add(obj);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Username telah terpakai di tenant/klinik ini");
            }
        }


        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
        public async Task Delete(string id)
        {
            var data = await GetbyTenantPenggunaID(id);
            if (data != null)
            {
                try
                {
                    _context.TenantPengguna.Remove(data);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.InnerException.Message);
                }
            }
            else
            {
                throw new Exception("Data Tenant tidak ditemukan");
            }
        }
        public async Task<TenantPengguna> GetbyTenantPenggunaID(string Id)
        {
            var data = await (from c in _context.TenantPengguna.Include(r => r.Tenant).Include(r => r.pengguna)
                              where c.TenantPenggunaID == Id
                              select c).SingleOrDefaultAsync();
            return data;
        }
        //tenantforusernmae di gunakan untuk verifikasi uxer pada saat login 
        //ketika user memilih tenant mana fungsi ini mencocokan apakah ada user yang di sort berdasarkan tenantid dan username yg di pilih
        public async Task<TenantPengguna> tenantforusername(string Id, string Username)
        {
            var data = await (from c in _context.TenantPengguna.Include(r => r.Tenant).Include(r => r.pengguna)
                              where c.TenantID == Id && c.Username == Username
                              select c).SingleOrDefaultAsync();
            return data;
        }
        public async Task<IEnumerable<TenantPengguna>> GetAll()
        {
            var results = await(from t in _context.TenantPengguna
                                orderby t.TenantPenggunaID
                                select t).ToListAsync();
            return results;
        }

        public Task<TenantPengguna> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(TenantPengguna obj)
        {
            var data = await GetbyTenantPenggunaID(obj.TenantPenggunaID);
            if (data != null)
            {
                try
                {
                    data.TenantID = obj.TenantID;
                    data.Username = obj.Username;
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception($"{ex.Message} {ex.InnerException.Message}");
                }
            }
            else
            {
                throw new Exception("Data tidak ditemukan");
            }
        }
        //untuk menampilkan data yang hasilnya lebih dari satu gunakan list
        public async Task<IEnumerable<TenantPengguna>> getusertenantlist(string Username)
        {
            var data = await(from c in _context.TenantPengguna.Include(r => r.Tenant).Include(r => r.pengguna)
                             where c.Username == Username
                             select c).ToListAsync();
            return data;
        }
        //untuk mencari apakah username sudah terdaftar di tenant id
        public async Task<IEnumerable<TenantPengguna>> getuserbytenantid(string tenantID)
        {
            var data = await (from c in _context.TenantPengguna.Include(r => r.Tenant)
                              where c.TenantID == tenantID
                              select c).ToListAsync();
            return data;
        }
    }
}
