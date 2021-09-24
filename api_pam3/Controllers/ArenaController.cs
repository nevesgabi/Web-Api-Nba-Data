using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api_pam3.Repositorio;
using api_pam3.Models;
using System.Collections;

namespace api_pam3.Controllers
{
    [Route("api/arena")]
    [ApiController]
    public class ArenaController : ControllerBase
    {
        // GET: api/arena
        [HttpGet]
        public IEnumerable ListarArena()
        {
            ArenaRepositorio arenaRepositorio = new ArenaRepositorio();
            return arenaRepositorio.ListarArena();
        }

        // GET: api/arena/{id}
        [HttpGet("{id}")]
        public Arena ConsultarArena(int id)
        {
            ArenaRepositorio arenaRepositorio = new ArenaRepositorio();
            return arenaRepositorio.ConsultarArena(id);
        }

        // POST: api/usuario
        [HttpPost]
        public long CriarArena([FromBody] Arena value)
        {
            ArenaRepositorio arenaRepositorio = new ArenaRepositorio();
            return arenaRepositorio.CadastrarArena(value);
        }
    }
}
