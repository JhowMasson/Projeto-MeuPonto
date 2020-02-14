using Senai.MeuPonto.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.MeuPonto.WebApi.Interfaces
{
    public interface IPontosRepositorio
    {
        List<Pontos> ListarPontos();
        void Cadastrar(Pontos ponto);
    }
}
