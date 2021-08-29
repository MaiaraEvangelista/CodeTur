using CodeTur.Dominio;
using CodeTur.Dominio.Entidades;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTurInfra.Data.Contexto
{
    //Cria a classe CodeTurContexto e herda de DbContext
    public class CodeTurContexto : DbContext
    {
        //Método construtor, herda a base
        public CodeTurContexto(DbContextOptions<CodeTurContexto> options) : base(options)
        {
            
        }

        //Criação de tabelas com DbSet
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pacote> Pacotes { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
    
        //Modelagem das tabelas, usando método de sobreescrita
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Ignora a notification
            modelBuilder.Ignore<Notification>();

            //Mapeação de tabelas
            //agrupa uma quantidade grande de códigos
            #region mapeamento da tabela Usuarios

                //mudando nome da tabela se for necessário
                modelBuilder.Entity<Usuario>().ToTable("usuarios");
                //determinando chaves
                modelBuilder.Entity<Usuario>().Property(x => x.Id);
                //definição de tamanho para nome
                modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasMaxLength(40);
                //reforçando o método acima 
                modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasColumnType("varchar(40)");
                //Determina de que ele não pode ser nulo
                modelBuilder.Entity<Usuario>().Property(x => x.Nome).IsRequired();


                //definição de tamanho para email
                modelBuilder.Entity<Usuario>().Property(x => x.Email).HasMaxLength(60);
                //reforçando o método acima 
                modelBuilder.Entity<Usuario>().Property(x => x.Email).HasColumnType("varchar(60)");
                //Determina de que ele não pode ser nulo
                modelBuilder.Entity<Usuario>().Property(x => x.Email).IsRequired();


                //definição de tamanho para caracteres
                modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasMaxLength(120);
                //reforçando o método acima 
                modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasColumnType("varchar(120)");
                //Determina de que ele não pode ser nulo
                modelBuilder.Entity<Usuario>().Property(x => x.Senha).IsRequired();

                //Definição para data
                modelBuilder.Entity<Usuario>().Property(x => x.Date).HasColumnType("DateTime");
                modelBuilder.Entity<Usuario>().Property(x => x.Date).HasDefaultValueSql("getdate()");
                
                //modelBuilder.Entity<Usuario>(
                //    entity => entity.HasIndex(u => u.Email).IsUnique()
                //    );
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    
    
    
    
    
    
    }
}