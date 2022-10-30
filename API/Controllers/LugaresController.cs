using System.Diagnostics;
using System.Reflection.PortableExecutable;
using Core.Interfaces;
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
      //todo inyectar nuestro propio repositorio
      //todo Inicializarlo
        private readonly ILugarRepositorio _repo;
        public LugaresController(ILugarRepositorio repo)
        {
            _repo = repo;
            
            
        }

        //todo Metodo get para retornar una lista o multiples resultados
        [HttpGet]
        public async Task< ActionResult<List<Lugar>>> GetLugares()
        {//todo usar metodo asyncrono para un mejor control
            var lugares= await _repo.GetLugaresAsync();
            return Ok(lugares);
        }

        //todo Para retornar un lugar Especifico
        [HttpGet("{id}")]
        public async Task<ActionResult<Lugar>> GetLugar(int id)
        {

            return await _repo.GetLugarAsync(id);//todo para retornar un solo registro
        }


    }
}