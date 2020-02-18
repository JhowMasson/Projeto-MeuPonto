using Senai.MeuPonto.WebApi.Domains;
using Senai.MeuPonto.WebApi.Interfaces;
using Senai.MeuPonto.WebApi.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Senai.MeuPonto.WebApi.Repositorios
{
    public class UsuariosRepositorio : IUsuariosRepositorio
    {
        private PontoContext Context;

        public UsuariosRepositorio()
        {
        }

        public UsuariosRepositorio(PontoContext context)
        {
            this.Context = context;
        }

        public void Cadastrar(Usuarios usuario)
        {
            using(PontoContext ctx = new PontoContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public Usuarios EfetuarLogin(string v, LoginViewModel login)
        {
            using(PontoContext ctx = new PontoContext())
            {
                Usuarios usuario = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (usuario == null)
                {
                    return null;
                }
                return usuario;
            }
        }

        public Usuarios EfetuarLogin(LoginViewModel login)
        {
            throw new System.NotImplementedException();
        }

        public List<Usuarios> ListarUsuarios()
        {
            using (PontoContext ctx = new PontoContext())
            {
                return ctx.Usuarios.ToList();
            }
        }
    }
}
