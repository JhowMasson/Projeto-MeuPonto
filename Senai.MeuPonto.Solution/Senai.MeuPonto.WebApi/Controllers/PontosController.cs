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
    public class PontosController : ControllerBase
    {
        private IPontosRepositorio pontosRepositorio { get; set; }

        public PontosController()
        {
            pontosRepositorio = new PontosRepositorio();
        }

        [HttpGet]
        public IActionResult ListarPontos()
        {
            return Ok(pontosRepositorio.ListarPontos());
        }

        [HttpPost]
        public IActionResult CadastrarPontos(Pontos pontos)
        {
            try
            {
                pontosRepositorio.Cadastrar(pontos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}