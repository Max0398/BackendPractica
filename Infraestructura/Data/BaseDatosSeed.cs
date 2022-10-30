using Core.Models;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace Infraestructura.Data
{
    public class BaseDatosSeed
    {
        //todo para usar los json como fuente de datos que se encuentran en la 
        //todo carpeta SeedData
        public static async Task SeedAsync(ApplicationDbContext context, ILoggerFactory loggerfactory)
        {
            try
            {
                if (!context.Pais.Any())
                {
                    var paisData = File.ReadAllText("./Infraestructura/Data/SeedData/2paises.json");
                    var paises = JsonSerializer.Deserialize<List<Pais>>(paisData);
                    foreach (var item in paises)
                    {
                        await context.Pais.AddAsync(item);
                    }
                    await context.SaveChangesAsync();

                }

                if (!context.Categoria.Any())
                {
                    var categoriasData = File.ReadAllText("./Infraestructura/Data/SeedData/categorias.json");
                    var categorias = JsonSerializer.Deserialize<List<Categoria>>(categoriasData);
                    foreach (var item in categorias)
                    {
                        await context.Categoria.AddAsync(item);
                    }
                    await context.SaveChangesAsync();

                }

                if (!context.Lugar.Any())
                {
                    var lugaresData = File.ReadAllText("./Infraestructura/Data/SeedData/lugares.json");
                    var lugares = JsonSerializer.Deserialize<List<Lugar>>(lugaresData);
                    foreach (var item in lugares)
                    {
                        await context.Lugar.AddAsync(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex )
            {
                var logger=loggerfactory.CreateLogger<BaseDatosSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}