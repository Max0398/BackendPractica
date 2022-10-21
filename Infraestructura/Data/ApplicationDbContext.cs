using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Data
{
    public class ApplicationDbContext:DbContext
    {//todo para la cadena de conexion
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
            
        }

//todo propiedad para se cree la tabla en DB
        public DbSet<Lugar> Lugar { get; set; }

    }
}