using Doacao.Comum;
using Doacao.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doacao.Dominio.Commands.Usuario
{
    public class CriarContaCommand : Notifiable<Notification>, ICommand
    {

        public CriarContaCommand()
        {

        }

        public CriarContaCommand(string nome, string email, string senha, EnTipoUsuario tipoUsuario, string endereco, string telefone)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            TipoUsuario = tipoUsuario;
            Endereco = endereco;
            Telefone = telefone;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public EnTipoUsuario TipoUsuario { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotEmpty(Nome, "Nome", "Nome não pode ser vazio")
                .IsEmail(Email, "Email", "O formato do email está incorreto")
                .IsGreaterThan(Senha, 7, "Senha", "A senha deve ter pelo menos 8 caracteres")
                .IsNotEmpty(Endereco, "Endereço", "Endereço não pode estar vazio")
                .IsNotEmpty(Telefone, "Telefone", "Telefone não pode estar vazio")
            );
        }
    }
}
