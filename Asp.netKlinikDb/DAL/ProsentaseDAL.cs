using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.DAL
{
    public class ProsentaseDAL : IProsentase
    {
        private AppDbContext _context;
        public ProsentaseDAL(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Prosentase obj)
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
                    _context.Prosentase.Remove(data);
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

        public async Task Deletebyusername(string Username)
        {
            var userprosentase = await getbyusername(Username);
            if (userprosentase != null)
            {
                foreach (var data in userprosentase)
                {
                    _context.Prosentase.Remove(data);
                }
            }
            else
            {
                throw new Exception("Data tidak ditemukan");
            }
 
        }

        public async Task<IEnumerable<Prosentase>> GetAll()
        {
            var data = await (from r in _context.Prosentase.Include(r => r.Tenant).Include(r => r.JenisTindakan).Include(r => r.Pengguna).
                             Include(r => r.IdProsentase)
                              select r).AsNoTracking().ToListAsync();


            return data;
        }

        public async Task<Prosentase> GetById(int id)
        {
            var data = await (from c in _context.Prosentase.Include(r => r.Tenant).Include(r => r.JenisTindakan).Include(r => r.Pengguna)
                              where c.IdProsentase == id
                              select c).SingleOrDefaultAsync();
            return data;
        }

        public async Task<IEnumerable<Prosentase>> getbytenantid(string tenantID)
        {
            var data = await (from c in _context.Prosentase.Include(r => r.Tenant).Include(r => r.JenisTindakan).Include(r => r.Pengguna)
                              where c.TenantID == tenantID
                               select c).ToListAsync();
            return data;
        }

        public async Task<IEnumerable<Prosentase>> getbyusername(string Username)
        {
            var data = await(from c in _context.Prosentase.Include(r => r.Tenant).Include(r => r.JenisTindakan).Include(r => r.Pengguna)
                             where c.Username == Username
                             select c).ToListAsync();
            return data;
        }

        public async Task UpdateAsync(Prosentase obj)
        {
            var data = await GetById(obj.IdProsentase);
            if (data != null)
            {
                try
                {
                    data.Username = obj.Username;
                    data.IdJenisTindakan = obj.IdJenisTindakan;
                    data.Prosen = obj.Prosen;
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
