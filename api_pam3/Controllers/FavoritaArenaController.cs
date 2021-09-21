using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api_pam3.Repositorio;
using api_pam3.Models;

namespace api_pam3.Controllers
{
    [Route("api/favorita_arena")]
    [ApiController]
    public class FavoritaArenaController : ControllerBase
    {
        // GET: api/favorita_arena
        [HttpGet]
        public IEnumerable ListarArenaFavorita()
        {
            FavoritaArenaRepositorio favoritaArenaRepositorio = new FavoritaArenaRepositorio();
            return favoritaArenaRepositorio.ListarArenaFavorita();
        }

        // GET: api/favorita_arena/{id}
        [HttpGet("{id}")]
        public FavoritaArena ConsultarArenaFavorita(int id)
        {
            FavoritaArenaRepositorio favoritaArenaRepositorio = new FavoritaArenaRepositorio();
            return favoritaArenaRepositorio.ConsultarArenaFavorita(id);
        }

        // POST: api/favorita_arena
        [HttpPost]
        public void CriarArenaFavorita([FromBody] FavoritaArena value)
        {
            FavoritaArenaRepositorio favoritaArenaRepositorio = new FavoritaArenaRepositorio();
            favoritaArenaRepositorio.CadastrarArenaFavorita(value);
        }

        // DELETE: api/favorita_arena/{id}
        [HttpDelete("{id}")]
        public void DeletarArenaFavorita(int id)
        {
            FavoritaArenaRepositorio favoritaArenaRepositorio = new FavoritaArenaRepositorio();
            favoritaArenaRepositorio.ApagarArenaFavorita(id);
        }

    }
}
