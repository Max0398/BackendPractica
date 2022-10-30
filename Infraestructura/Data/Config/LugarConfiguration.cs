using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Config
{
    //todo para configurar las migraciones
    public class LugarConfiguration : IEntityTypeConfiguration<Lugar>
    {
        public void Configure(EntityTypeBuilder<Lugar> builder)
        {
            //todo para acceder a todas las propiedades
            builder.Property(i=>i.Id).IsRequired();
            builder.Property(i=>i.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(i=>i.Descripcion).IsRequired();
            builder.Property(i=>i.GastoAproximado).IsRequired();
            /*Relaciones*/
            builder.HasOne(c=>c.Categoria).WithMany()
            .HasForeignKey(i=>i.CategoriaId);

            builder.HasOne(p=>p.Pais).WithMany()
            .HasForeignKey(i=>i.PaisId);

        }
    }
}