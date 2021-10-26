using Doacao.Dominio;
using Doacao.Dominio.Entidades;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doacao.Infra.Data.Contexts
{
    public class DoacaoContext : DbContext
    {

        public DoacaoContext(DbContextOptions<DoacaoContext> options) : base(options)
        {

        }

        // Declarar tabelas que para criar, com dbset
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Doacoes> MyProperty { get; set; }

        // Modelagem das tabelas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Ignoramos que a biblioteca de notificações do Flunt seja gerada no banco automaticamente
            modelBuilder.Ignore<Notification>();

            #region Mapeamento tabela usuarios

            // Nome da Tabela
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");

            // Determinar a key , não precisa determinar como primary key já qie está nomeado como ID
            modelBuilder.Entity<Usuario>().Property(x => x.Id);

            // Nome
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasMaxLength(255);
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasColumnType("varchar(255)");
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).IsRequired();

            // Email
            modelBuilder.Entity<Usuario>().Property(x => x.Email).HasMaxLength(255);
            modelBuilder.Entity<Usuario>().Property(x => x.Email).HasColumnType("varchar(255)");
            modelBuilder.Entity<Usuario>().Property(x => x.Email).IsRequired();

            // Senha
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasMaxLength(255);
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasColumnType("varchar(255)");
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).IsRequired();
            modelBuilder.Entity<Usuario>().HasIndex(x => x.Email).IsUnique();

            // Endereco
            modelBuilder.Entity<Usuario>().Property(x => x.Endereco).HasMaxLength(255);
            modelBuilder.Entity<Usuario>().Property(x => x.Endereco).HasColumnType("varchar(255)");
            modelBuilder.Entity<Usuario>().Property(x => x.Endereco).IsRequired();

            // Telefone
            modelBuilder.Entity<Usuario>().Property(x => x.Telefone).HasMaxLength(20);
            modelBuilder.Entity<Usuario>().Property(x => x.Telefone).HasColumnType("varchar(20)");
            modelBuilder.Entity<Usuario>().Property(x => x.Telefone).IsRequired();

            // Celular
            modelBuilder.Entity<Usuario>().Property(x => x.Celular).HasMaxLength(20);
            modelBuilder.Entity<Usuario>().Property(x => x.Celular).HasColumnType("varchar(20)");
            modelBuilder.Entity<Usuario>().Property(x => x.Celular).IsRequired();

            // DataCriacao
            modelBuilder.Entity<Usuario>().Property(x => x.DataCriacao).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(x => x.DataCriacao).HasDefaultValueSql("getdate()");

            #endregion

            #region Mapeamento tabela doacoes

            // Nome da Tabela
            // modelBuilder.Entity<Doacoes>().ToTable("Doacoes");

            // Determinar a key , não precisa determinar como primary key já qie está nomeado como ID
            // modelBuilder.Entity<Doacoes>().Property(x => x.Id);

            // Titulo
            // modelBuilder.Entity<Doacoes>().Property(x => x.Titulo).HasMaxLength(255);
            // modelBuilder.Entity<Doacoes>().Property(x => x.Titulo).HasColumnType("varchar(255)");
            // modelBuilder.Entity<Doacoes>().Property(x => x.Titulo).IsRequired();

            // Descricao
            // modelBuilder.Entity<Doacoes>().Property(x => x.Descricao).HasMaxLength(2000);
            // modelBuilder.Entity<Doacoes>().Property(x => x.Descricao).HasColumnType("varchar(2000)");
            // modelBuilder.Entity<Doacoes>().Property(x => x.Descricao).IsRequired();

            // Categoria
            // modelBuilder.Entity<Doacoes>().Property(x => x.Categoria).HasMaxLength(255);
            // modelBuilder.Entity<Doacoes>().Property(x => x.Categoria).HasColumnType("varchar(255)");
            // modelBuilder.Entity<Doacoes>().Property(x => x.Categoria).IsRequired();

            // Imagem
            // modelBuilder.Entity<Doacoes>().Property(x => x.Imagem).HasMaxLength(255);
            // modelBuilder.Entity<Doacoes>().Property(x => x.Imagem).HasColumnType("varchar(255)");
            //  modelBuilder.Entity<Doacoes>().Property(x => x.Imagem).IsRequired();

            #endregion


            base.OnModelCreating(modelBuilder);
        }

    }
}
