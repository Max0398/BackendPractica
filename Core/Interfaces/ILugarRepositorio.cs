using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces
{
    public interface ILugarRepositorio
    {
        //todo firmas de nuestros metodos
        //todo estos metodos se implementaran en Infraestructura
        Task<Lugar> GetLugarAsync(int id);
        
        Task<IReadOnlyList<Lugar>>GetLugaresAsync();

    }
}