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
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        // GET: api/usuario
        [HttpGet]
        public IEnumerable ListarUsuario()
        {
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
            return usuarioRepositorio.ListarUsuario();
        }

        // POST: api/usuario
        [HttpPost]
        public long CriarUsuario([FromBody] Usuario value)
        {
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
            return usuarioRepositorio.CadastrarUsuario(value);
        }

        // PUT: api/usuario
        [HttpPut]
        public long EditarUsuario([FromBody] Usuario value)
        {
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
           return usuarioRepositorio.EditarUsuario(value, value.IdUsuario);
        }

        // DELETE: api/usuario/{id}
        [HttpDelete("{id}")]
        public void DeletarUsuario(int id) {
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
            usuarioRepositorio.ApagarUsuario(id);
        }

        // GET: api/usuario/{id}
        [HttpGet("{id}")]
        public Usuario ConsultarUsuario(int id)
        {
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
            return usuarioRepositorio.ConsultarUsuario(id);
        }

        // POST: api/usuario/login
        [HttpPost("login")]
        public Usuario LogarUsuario([FromBody] Usuario value)
        {
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
            return usuarioRepositorio.ConsultarLogin(value);
        }
    }
}
