using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Data
{
    public class LugarRepositorio : ILugarRepositorio
    {
        //todo agregar el dbcontext y inicializarlo
        private readonly ApplicationDbContext _db;
        public LugarRepositorio(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Lugar> GetLugarAsync(int id)
        {
            return await _db.Lugar.Include(p=>p.Pais).Include(c=>c.Categoria).FirstOrDefaultAsync(i=>i.Id==id);
        }

        public async Task<IReadOnlyList<Lugar>> GetLugaresAsync()
        {
            return await _db.Lugar.Include(p=>p.Pais).Include(c=>c.Categoria).ToListAsync();
        }
    }
}