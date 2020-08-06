using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.DAL
{
    public class KatBarangDAL : IKatBarang
    {
        private AppDbContext _context;
        public KatBarangDAL(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(KatBarang obj)
        {
            //How to convert System.Linq.Enumerable.WhereListIterator<int> to List<int>?
            //mencari data tenant "ccc"
            //result dengan mencari dari hasil search tenant
            var data = await getbytenantid(obj.TenantID);
            var result = data.Where(e => e.NamaKategori == obj.NamaKategori).ToList();
            //mencari data tenant ccc
            if (result.Count == 0)
            {
                    _context.Add(obj);
                    await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Nama Kategori tidak boleh sama");
            }
           
        }

        public async Task Delete(int id)
        {
            var data = await GetById(id);
            if (data != null)
            {
                try
                {
                    _context.KatBarang.Remove(data);
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

        public async Task<IEnumerable<KatBarang>> GetAll()
        {

            TimeSpan ts = TimeSpan.FromMilliseconds(150);
            var data = await (from r in _context.KatBarang.Include(r => r.Tenant).Include(r => r.Barang)
                        select r).AsNoTracking().ToListAsync();
            
            
            return data;
        }
        public async Task<IEnumerable<Barang>> GetBarang()
        {
            var data = await (from r in _context.Barang
                              orderby r.IdBarang ascending
                              select r).ToListAsync();


            return data;
        }

        public async Task<KatBarang> GetById(int id)
        {
            var data = await(from c in _context.KatBarang.Include(r => r.Tenant)
                             where c.IdKategori == id
                             select c).SingleOrDefaultAsync();
            return data;
        }

        public async Task<IEnumerable<KatBarang>> getbytenantid(string TenantID)
        {
            var data = await (from c in _context.KatBarang.Include(r => r.Tenant)
                              where c.TenantID == TenantID
                              select c).ToListAsync();
            return data;
        }

        public async Task<IEnumerable<KatBarang>> sortbytenantandidkategori(string tenantID, string NamaKategori)
        {
            var data = await (from c in _context.KatBarang.Include(r => r.Tenant)
                              where c.TenantID == tenantID && c.NamaKategori == NamaKategori
                              select c).ToListAsync();
            return data;
        }

        public async Task UpdateAsync(KatBarang obj)
        {
            var data = await GetById(obj.IdKategori);
            if (data != null)
            {
                try
                {
                    data.NamaKategori = obj.NamaKategori;
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
