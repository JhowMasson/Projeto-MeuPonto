using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.MeuPonto.WebApi.Domains;
using Senai.MeuPonto.WebApi.Interfaces;
using Senai.MeuPonto.WebApi.Repositorios;


namespace Senai.MeuPonto.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/Json")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuariosRepositorio usuarioRepositorio { get; set; }

        public UsuariosController()
        {
            usuarioRepositorio = new UsuariosRepositorio();
        }

        [HttpGet]
        public IActionResult ListarUsuarios()
        {
            return Ok(usuarioRepositorio.ListarUsuarios());
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuarios usuarios)
        {
            try
            {
                usuarioRepositorio.Cadastrar(usuarios);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}