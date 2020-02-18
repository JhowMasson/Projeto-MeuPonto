using Microsoft.EntityFrameworkCore;
using Senai.MeuPonto.WebApi.Domains;
using Senai.MeuPonto.WebApi.Repositorios;
using Xunit;

namespace Senai.MeuPonto.Teste.XUnit.Repositorios
{
    public class TestesPonto
    {

        [Fact]
        public void VerificaSeUsuarioEInvalido()
        {
            var options = new DbContextOptionsBuilder<PontoContext>()
               .UseInMemoryDatabase(databaseName: "UsuarioEInvalido")
               .Options;

            //Use a clean instance of the context to run the test
            using (var context = new PontoContext(options))
            {
                var repo = new UsuariosRepositorio(context);
                var validacao = repo.EfetuarLogin("MeuPonto@email.com", "12345678");

                Assert.Null(validacao);
            }
        }

        [Fact]
        public void VerificaSeUsuarioEValido()
        {
            var options = new DbContextOptionsBuilder<PontoContext>()
               .UseInMemoryDatabase(databaseName: "UsuarioEValido")
               .Options;

            // Use a clean instance of the context to run the test
            using (var context = new PontoContext(options))
            {
                var repo = new UsuariosRepositorio(context);
                var validacao = repo.EfetuarLogin("MeuPonto@email.com", "12345678");

                Assert.Null(validacao);
            }
        }

        [Fact]
        public void VerificaSeUsuarioEValidoEInfoCorretas()
        {
            var options = new DbContextOptionsBuilder<PontoContext>()
               .UseInMemoryDatabase(databaseName: "UsuarioEValidoEInfoCorretas")
               .Options;

            Usuarios usuario = new Usuarios()
            {
                Email = "MeuPonto@email.com",
                Senha = "12345678",
                Tipo = "ADMINISTRADOR"
            };
        }
    }
}