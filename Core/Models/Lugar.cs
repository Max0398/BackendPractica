using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    //todo Instalar en nuget Microsoft.EntityFrameworkCore.Sql para trabjar con la bases de datos
    //todo Microsoft.EntityFrameworkCore.Design para las migraciones
    public class Lugar
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}