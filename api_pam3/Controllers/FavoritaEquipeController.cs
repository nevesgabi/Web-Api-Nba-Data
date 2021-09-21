using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_pam3.Models;
using api_pam3.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_pam3.Controllers
{
    [Route("api/favorita_equipe")]
    [ApiController]
    public class FavoritaEquipeController : ControllerBase
    {
        // GET: api/Favorita_equipe
        [HttpGet]
        public IEnumerable ListarEquipeFavorita()
        {
            FavoritaEquipeRepositorio favoritaEquipeRepositorio = new FavoritaEquipeRepositorio();
            return favoritaEquipeRepositorio.ListarEquipeFavorita();
        }

        // GET: api/Favorita_equipe/{id}
        [HttpGet("{id}")]
        public FavoritaEquipe ConsultarEquipeFavorita(int id)
        {
            FavoritaEquipeRepositorio favoritaEquipeRepositorio = new FavoritaEquipeRepositorio();
            return favoritaEquipeRepositorio.ConsultarEquipeFavorita(id);
        }

        // POST: api/Favorita_equipe
        [HttpPost]
        public void CriarEquipeFavorita([FromBody] FavoritaEquipe value)
        {
            FavoritaEquipeRepositorio favoritaEquipeRepositorio = new FavoritaEquipeRepositorio();
            favoritaEquipeRepositorio.CadastrarEquipeFavorita(value);
        }

        // DELETE: api/Favorita_equipe/{id}
        [HttpDelete("{id}")]
        public void DeletarEquipeFavorita(int id)
        {
            FavoritaEquipeRepositorio favoritaEquipeRepositorio = new FavoritaEquipeRepositorio();
            favoritaEquipeRepositorio.ApagarEquipeFavorita(id);
        }
    }
}
