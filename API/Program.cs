using System;
using Core.Interfaces;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//todo Variable almacene nuestra cadena de conexion

var connectionString=builder.Configuration.GetConnectionString("DefaultConnection");
//todo configurar o Agregar el servicio y la cadena de conexion al dbcontext
builder.Services.AddDbContext<ApplicationDbContext> (options=> 
    options.UseMySql(connectionString,
    ServerVersion.AutoDetect(connectionString)));

    
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//todo agregar el repositorio como un servicio para hacerlo inyectable

builder.Services.AddScoped<ILugarRepositorio, LugarRepositorio>();

var app = builder.Build();
//Aplicar las nuevas migraciones al ejecutar la aplicacion
using (var scope=app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory=services.GetRequiredService<ILoggerFactory>();

    try
    {
        var context=services.GetRequiredService<ApplicationDbContext>();
        await context.Database.MigrateAsync();
        //await BaseDatosSeed.SeedAsync(context , loggerFactory);
    }
    catch(System.Exception ex){
        var logger=loggerFactory.CreateLogger<Program>();
        logger.LogError(ex,"Hubo un Error al Realizar las Migraciones");
    }

}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
