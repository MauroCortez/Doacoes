using Doacao.Comum;
using Doacao.Comum.Enum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doacao.Dominio.Entidades
{
    public class Doacoes : Base
    {

        public Doacoes(string titulo, string descricao, EnCategoria categoria, string imagem)
        {

            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(titulo, "Título", "Título não pode ser vazio")
                    .IsNotEmpty(descricao, "Descrição", "Descrição não pode estar vazio")
                    .IsNotNull(categoria, "Categoria", "Selecione uma Categoria")
                    .IsNotEmpty(imagem, "Imagem", "Imagem não pode ser vazio")
                );

            if (IsValid)
            {
                Titulo = titulo;
                Descricao = descricao;
                Categoria = categoria;
                Imagem = imagem;
            }
        }

        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public EnCategoria Categoria { get; private set; }
        public string Imagem { get; private set; }

        // Composições

        public Guid IdUsuario { get; private set; }
        public Usuario Usuario { get; private set; }

        // Atualizar a Doacoes

        public void AtualizarDoacao(string titulo, string descricao, EnCategoria categoria, string imagem)
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(titulo, "Título", "Título não pode ser vazio")
                    .IsNotEmpty(descricao, "Descrição", "Descrição não pode estar vazio")
                    .IsNotNull(categoria, "Categoria", "Selecione uma Categoria")
                    .IsNotEmpty(imagem, "Imagem", "Imagem não pode ser vazio")
                );

            if (IsValid)
                Titulo = titulo;
                Descricao = descricao;
                Categoria = categoria;
                Imagem = imagem;
        }
    }
}
