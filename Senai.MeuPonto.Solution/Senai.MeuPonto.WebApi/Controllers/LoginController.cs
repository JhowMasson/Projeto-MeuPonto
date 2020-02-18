using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.MeuPonto.WebApi.Domains;
using Senai.MeuPonto.WebApi.Interfaces;
using Senai.MeuPonto.WebApi.Repositorios;
using Senai.MeuPonto.WebApi.ViewModels;

namespace Senai.MeuPonto.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/Json")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuariosRepositorio UsuarioRepositorio { get; set; }

        public LoginController()
        {
            UsuarioRepositorio = new UsuariosRepositorio();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuarios usuario = UsuarioRepositorio.EfetuarLogin(login);
                if (usuario == null)
                {
                    return NotFound(new { mensagem = "Usuario ou senha invalidos" });
                }

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}