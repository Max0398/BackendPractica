using System.Diagnostics;
using System.Reflection.PortableExecutable;
using Core.Models;
using Infraestructura.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LugaresController : ControllerBase
    {
        //todo Aplicando El DBContext al Controlador
        private readonly ApplicationDbContext _db;//todo inicializar el del constructor
        public LugaresController(ApplicationDbContext db)
        {
            _db = db;
            
        }

        //todo Metodo get para retornar una lista o multiples resultados
        [HttpGet]
        public async Task< ActionResult<List<Lugar>>> GetLugares()
        {//todo usar metodo asyncrono para un mejor control
            var lugares= await _db.Lugar.ToListAsync();
            return Ok(lugares);
        }

        //todo Para retornar un lugar Especifico
        [HttpGet("{id}")]
        public async Task<ActionResult<Lugar>> GetLugar(int id)
        {

            return await _db.Lugar.FindAsync(id);//todo para retornar un solo registro
        }


    }
}