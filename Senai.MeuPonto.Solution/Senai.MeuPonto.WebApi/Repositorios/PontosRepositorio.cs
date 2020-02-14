using Microsoft.EntityFrameworkCore;
using Senai.MeuPonto.WebApi.Domains;
using Senai.MeuPonto.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MeuPonto.WebApi.Repositorios
{
    public class PontosRepositorio : IPontosRepositorio
    {
        public void Cadastrar(Pontos ponto)
        {
            using(PontoContext ctx = new PontoContext())
            {
                ctx.Pontos.Add(ponto);
                ctx.SaveChanges();
            }
        }

        public List<Pontos> ListarPontos()
        {
            using(PontoContext ctx = new PontoContext())
            {
                return ctx.Pontos.Include(x => x.IdUsuarioNavigation).ToList();
            }
        }
    }
}
