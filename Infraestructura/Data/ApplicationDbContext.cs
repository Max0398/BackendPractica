using System.Reflection;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Data
{
    public class ApplicationDbContext:DbContext
    {//todo para la cadena de conexion
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
            //todo para Remover las migraciones desde cmd
            //todo  dotnet ef migrations remove -p Infraestructura -s API
        }
//todo Para hacer las Migraciones Raiz del Proyecto
//todo para la migraciones dotnet ef migrations add InicialMigracion -p Infraestructura -s API -o Data/Migrations
//todo propiedad DbSet<> para se cree la tabla en DB
        public DbSet<Lugar> Lugar { get; set; }
        public DbSet<Pais>Pais { get; set; }
        public DbSet<Categoria>Categoria { get; set; }

        //todo para terminar lo de config de las migraciones

        protected override void OnModelCreating(ModelBuilder modelBuilder)//Encargado de crear las migraciones
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

    }
}