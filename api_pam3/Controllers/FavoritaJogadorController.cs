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
    [Route("api/favorita_jogador")]
    [ApiController]
    public class FavoritaJogadorController : ControllerBase
    {
        // GET: api/favorita_jogador
        [HttpGet]
        public IEnumerable ListarJogadorFavorito()
        {
            FavoritaJogadorRepositorio favoritaJogadorRepositorio = new FavoritaJogadorRepositorio();
            return favoritaJogadorRepositorio.ListarJogadorFavorito();
        }

        // GET: api/favorita_jogador/{id}
        [HttpGet("{id}")]
        public FavoritaJogador ConsultarJogadorFavorito(int id)
        {
            FavoritaJogadorRepositorio favoritaJogadorRepositorio = new FavoritaJogadorRepositorio();
            return favoritaJogadorRepositorio.ConsultarJogadorFavorito(id);
        }

        // POST: api/favorita_jogador
        [HttpPost]
        public void CriarJogadorFavorito([FromBody] FavoritaJogador value)
        {
            FavoritaJogadorRepositorio favoritaJogadorRepositorio = new FavoritaJogadorRepositorio();
            favoritaJogadorRepositorio.CadastrarJogadorFavorito(value);
        }

        // DELETE: api/favorita_jogador/{id}
        [HttpDelete("{id}")]
        public void DeletarJogadorFavorito(int id)
        {
            FavoritaJogadorRepositorio favoritaJogadorRepositorio = new FavoritaJogadorRepositorio();
            favoritaJogadorRepositorio.ApagarJogadorFavorito(id);
        }
    }
}
