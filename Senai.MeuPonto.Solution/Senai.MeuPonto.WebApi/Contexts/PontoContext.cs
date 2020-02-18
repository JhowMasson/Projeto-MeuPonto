using Microsoft.EntityFrameworkCore;
using Senai.MeuPonto.WebApi.Interfaces;

namespace Senai.MeuPonto.WebApi.Domains
{
    public partial class PontoContext : DbContext
    {

        //Declaração dos DbSets do contexto
        //public DbSet<Usuarios> Usuarios { get; set; }

        //public DbSet<Pontos> Pontos { get; set; }

        //Metodo construtor passando como parametros as opções do Contexto
        public PontoContext(DbContextOptions<PontoContext> options) : base(options) { }

        public PontoContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Verifica se o contexto já não esta configurado, caso não eseja utiliza a string de conexão abaixo
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=M_MeuPonto;integrated security=true");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>().HasData(
                new Usuarios()
                {
                    Ni = "1",
                    Nome = "Admin",
                    Email = "MeuPonto@email.com",
                    Senha = "12345678",
                    Tipo = "ADMINISTRADOR"
                }
                );

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Pontos> Pontos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }


        //protected override void onmodelcreating(modelbuilder modelbuilder)
        //{
        //    modelbuilder.entity<pontos>(entity =>
        //    {
        //        entity.haskey(e => e.idponto);

        //        entity.property(e => e.datahorario).hascolumntype("datetime");

        //        entity.property(e => e.tipo)
        //            .isrequired()
        //            .hasmaxlength(255)
        //            .isunicode(false);

        //        entity.hasone(d => d.idusuarionavigation)
        //            .withmany(p => p.pontos)
        //            .hasforeignkey(d => d.idusuario)
        //            .hasconstraintname("fk__pontos__idusuari__4d94879b");

        //        entity.property(e => e.imagem)
        //           .isrequired()
        //           .hascolumntype("text");
        //    });

        //    modelbuilder.entity<usuarios>(entity =>
        //    {
        //        entity.haskey(e => e.idusuario);

        //        entity.hasindex(e => e.cpf)
        //            .hasname("uq__usuarios__c1f897319f62e2eb")
        //            .isunique();

        //        entity.hasindex(e => e.email)
        //            .hasname("uq__usuarios__a9d10534ba77533a")
        //            .isunique();

        //        entity.property(e => e.cpf)
        //            .isrequired()
        //            .hascolumnname("cpf")
        //            .hasmaxlength(11)
        //            .isunicode(false);

        //        entity.property(e => e.email)
        //            .isrequired()
        //            .hasmaxlength(255)
        //            .isunicode(false);

        //        entity.property(e => e.ni)
        //            .isrequired()
        //            .hasmaxlength(255)
        //            .isunicode(false);

        //        entity.property(e => e.nome)
        //            .isrequired()
        //            .hasmaxlength(255)
        //            .isunicode(false);

        //        entity.property(e => e.senha)
        //            .isrequired()
        //            .hasmaxlength(255)
        //            .isunicode(false);

        //        entity.property(e => e.tipo)
        //            .isrequired()
        //            .hasmaxlength(255)
        //            .isunicode(false);


        //    });
   }
}

