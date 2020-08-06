using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.DAL
{
    public class JenisTindakanDAL : IJenisTindakan
    {
        private AppDbContext _context;
        public JenisTindakanDAL(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(JenisTindakan obj)
        {
            //result dengan mencari dari hasil search tenant
            var data = await getbytenantid(obj.TenantID);
            var result = data.Where(e => e.Jenis == obj.Jenis).ToList();
            //mencari data tenant ccc
            if (result.Count == 0)
            {
                _context.Add(obj);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Nama Jenis Tindakan tidak boleh sama");
            }
        }

        public async Task Delete(int id)
        {
            var data = await GetById(id);
            if (data != null)
            {
                try
                {
                    _context.JenisTindakan.Remove(data);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.InnerException.Message);
                }
            }
            else
            {
                throw new Exception("Data tidak ditemukan");
            }
        }

        public async Task<IEnumerable<JenisTindakan>> GetAll()
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(150);
            var data = await(from r in _context.JenisTindakan.Include(r => r.Tenant).Include(r => r.KatJenis).Include(r=>r.Prosentase).
                             Include(r=> r.Tindakan)
                             select r).AsNoTracking().ToListAsync();


            return data;
        }

        public async Task<JenisTindakan> GetById(int id)
        {
            var data = await(from c in _context.JenisTindakan.Include(r => r.Tenant).Include(r => r.KatJenis).Include(r => r.Prosentase).
                             Include(r => r.Tindakan)
                             where c.IdJenisTindakan == id
                             select c).SingleOrDefaultAsync();
            return data;
        }

        public async Task<IEnumerable<JenisTindakan>> getbytenantid(string tenantID)
        {
            var data = await(from c in _context.JenisTindakan.Include(r => r.Tenant).Include(r => r.KatJenis).Include(r => r.Prosentase).
                             Include(r => r.Tindakan)
                             where c.TenantID == tenantID
                             select c).ToListAsync();
            return data;
        }

        public async Task UpdateAsync(JenisTindakan obj)
        {
            var data = await GetById(obj.IdJenisTindakan);
            if (data != null)
            {
                try
                {
                    data.IdKatJenis = obj.IdKatJenis;
                    data.Jenis = obj.Jenis;
                    data.Biaya = obj.Biaya;
                    data.BiayaKelipatan = obj.BiayaKelipatan;
                    data.Keterangan = obj.Keterangan;
                    data.TenantID = obj.TenantID;
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
    }
}
