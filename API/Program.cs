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

var app = builder.Build();

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