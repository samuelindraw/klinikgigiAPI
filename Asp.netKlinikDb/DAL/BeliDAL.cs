using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.DAL
{
    public class BeliDAL : IBeli
    {
        private AppDbContext _context;
        private IBarang _Barang;
        public BeliDAL(AppDbContext context, IBarang barang)
        {
            _context = context;
            _Barang = barang;
        }
        //tenant terisi otomatis ketika login >
        public async Task CreateAsync(Beli obj)
        {
                try
                {
                _context.Add(obj);
                await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.InnerException.Message);
                }
        }

        public async Task Delete(int id)
        {
            var data = await GetById(id);
            if (data != null)
            {
                try
                {
                    _context.Beli.Remove(data);
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

        public async Task<IEnumerable<Beli>> GetAll()
        {
            var data = await(from r in _context.Beli.Include(r => r.Tenant)
                             orderby r.IdBeli ascending
                             select r).ToListAsync();


            return data;
        }

        public async Task<Beli> GetById(int id)
        {
            var data = await(from c in _context.Beli.Include(r => r.Tenant)
                             where c.IdBeli == id
                             select c).SingleOrDefaultAsync();
            return data;
        }

        public async Task UpdateAsync(Beli obj)
        {
            var data = await GetById(obj.IdBeli);
            if (data != null)
            {
                try
                {
                    data.IdBeli = obj.IdBeli;
                    data.Tanggal = obj.Tanggal;
                    data.TenantID = obj.TenantID;
                    data.NamaPembelian = obj.NamaPembelian;
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
        public async Task<IEnumerable<Beli>> getbelibyidtenant(string TenantID)
        {
            var data = await(from c in _context.Beli.Include(r => r.Tenant)
                             where c.TenantID == TenantID
                             select c).ToListAsync();
            return data;
        }
    }
}
