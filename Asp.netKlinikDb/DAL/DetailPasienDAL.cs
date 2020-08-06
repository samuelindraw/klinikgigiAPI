using Asp.netKlinikDb.Data;
using Asp.netKlinikDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.netKlinikDb.DAL
{
    public class DetailPasienDAL : IDetailPasien
    {
        private AppDbContext _context;

        public DetailPasienDAL(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(DetailPasien obj)
        {
            var datapengguna = await getusername(obj.Username);
            if (datapengguna == null)
            {
                _context.Add(obj);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Username telah terpakai !");
            }
        }

        public async Task Delete(int id)
        {
            var data = await GetById(id);
            if (data != null)
            {
                try
                {
                    _context.DetailPasien.Remove(data); 
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.InnerException.Message);
                }
            }
            else
            {
                throw new Exception("Data Pengguna tidak ditemukan");
            }
        }

        public async Task DeleteByuser(string Username)
        {
            var data = await getusername(Username);
            if (data != null)
            {
                try
                {
                    _context.DetailPasien.Remove(data);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.InnerException.Message);
                }
            }
            else
            {
                throw new Exception("Data Pengguna tidak ditemukan");
            }
        }

        public async Task<IEnumerable<DetailPasien>> GetAll()
        {
            var results = await(from t in _context.DetailPasien
                                orderby t.Username
                                select t).ToListAsync();
            return results;
        }

        public async Task<DetailPasien> GetById(int id)
        {
            var data = await (from c in _context.DetailPasien
                              where c.DetailPasienID == id
                             select c).SingleOrDefaultAsync();
            return data;
        }

        public async Task<DetailPasien> getbyidpasien(string IdPasien)
        {
            var data = await(from c in _context.DetailPasien
                             where c.IdPasien == IdPasien
                             select c).SingleOrDefaultAsync();

            if(data == null)
            {
                throw new Exception("Data tidak ditemukan");
            }
            else
            {
                return data;
            }
            
        }

        public async Task<DetailPasien> getusername(string Username)
        {
            var data = await (from c in _context.DetailPasien.Include(r => r.Pengguna)
                              where c.Username == Username
                              select c).SingleOrDefaultAsync();
            return data;
        }

        public async Task UpdateAsync(DetailPasien obj)
        {
            var data = await getbyidpasien(obj.IdPasien);
            if (data != null)
            {
                try
                {
                    data.Registrasi = obj.Registrasi;
                    data.RwPenyakit = obj.RwPenyakit;
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
