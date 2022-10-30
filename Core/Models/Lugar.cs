using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    //todo Instalar en nuget Microsoft.EntityFrameworkCore.Sql para trabjar con la bases de datos
    //todo Microsoft.EntityFrameworkCore.Design para las migraciones
    public class Lugar
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double GastoAproximado { get; set; }
        public string ImagenUrl { get; set; }
        public int PaisId { get; set; }//todo sera la id o llave foranea
        [ForeignKey("PaisId")]//todo referencia a que sera  la llave foranea
        public Pais Pais{get;set;}
        public int CategoriaId{get;set;}
        [ForeignKey("CategoriaId")]
        public Categoria Categoria{get;set;}
    }
}