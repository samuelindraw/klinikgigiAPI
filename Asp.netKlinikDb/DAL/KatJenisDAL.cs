using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.DAL
{
    public class KatJenisDAL : IKatJenis
    {
        private AppDbContext _context;
        public KatJenisDAL(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(KatJenis obj)
        {
            //How to convert System.Linq.Enumerable.WhereListIterator<int> to List<int>?
            //mencari data tenant "ccc"
            //result dengan mencari dari hasil search tenant
            var data = await getbytenantid(obj.TenantID);
            //stelah data tenant di dapat maka menncari
            var result = data.Where(e => e.KategoriName == obj.KategoriName).ToList();
            //mencari data tenant ccc
            if (result.Count == 0)
            {
                _context.Add(obj);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Nama Kategori Jenis tidak boleh sama");
            }
        }

        public async Task Delete(int id)
        {
            var data = await GetById(id);
            if (data != null)
            {
                try
                {
                    _context.KatJenis.Remove(data);
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

        public async Task<IEnumerable<KatJenis>> GetAll()
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(150);
            var data = await(from r in _context.KatJenis.Include(r => r.Tenant).Include(r => r.JenisTindakan)
                             select r).AsNoTracking().ToListAsync();


            return data;
        }

        public async Task<KatJenis> GetById(int id)
        {
            var data = await(from c in _context.KatJenis.Include(r => r.Tenant)
                             where c.IdKatJenis == id
                             select c).SingleOrDefaultAsync();
            return data;
        }

        public async Task<IEnumerable<KatJenis>> getbytenantid(string tenantID)
        {
            var data = await (from c in _context.KatJenis.Include(r => r.Tenant)
                              where c.TenantID == tenantID
                              select c).ToListAsync();
            return data;
        }

        public async Task UpdateAsync(KatJenis obj)
        {
            var data = await GetById(obj.IdKatJenis);
            if (data != null)
            {
                try
                {
                    data.KategoriName = obj.KategoriName;
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
