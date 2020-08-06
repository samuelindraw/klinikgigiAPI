using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.DAL
{
    public class TenantDAL : ITenant
    {
        private AppDbContext _context;
        public TenantDAL(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Tenant obj)
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

        public async Task Delete(string id)
        {
            var data = await GetbytenantID(id.ToString());
            if (data != null)
            {
                try
                {
                    _context.Tenant.Remove(data);
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

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tenant>> GetAll()
        {
            var results = await(from t in _context.Tenant
                                orderby t.TenantID
                                select t).ToListAsync();
            return results;
        }

        public async Task<Tenant> GetbytenantID(string Id)
        {
            var data = await(from c in _context.Tenant
                             where c.TenantID == Id
                             select c).SingleOrDefaultAsync();
            return data;
        }

        public Task<Tenant> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Tenant> Getbytenantname(string tenantname)
        {
            var data = await(from c in _context.Tenant
                             where c.TenantName == tenantname
                             select c).SingleOrDefaultAsync();
            return data;
        }

        public async Task UpdateAsync(Tenant obj)
        {
            var data = await GetbytenantID(obj.TenantID.ToString());
            if (data != null)
            {
                try
                {
                    data.TenantName = obj.TenantName;
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
