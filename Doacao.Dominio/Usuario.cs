using Doacao.Comum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doacao.Dominio
{
    public class Usuario : Base
    {

        public Usuario(string nome, string email, string senha, EnTipoUsuario tipoUsuario, string endereco, string telefone)
        {

            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotEmpty(nome, "Nome", "Nome não pode ser vazio")
                    .IsEmail(email, "Email","O formato do email está incorreto")
                    .IsGreaterThan(senha, 7, "Senha", "A senha deve ter pelo menos 8 caracteres")
                    .IsNotEmpty(endereco, "Endereço", "Endereço não pode estar vazio")
                    .IsNotEmpty(telefone, "Telefone", "Telefone não pode estar vazio")
                );

            Nome = nome;
            Email = email;
            Senha = senha;
            TipoUsuario = tipoUsuario;
            Endereco = endereco;
            Telefone = telefone;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public EnTipoUsuario TipoUsuario { get; private set; }
        public string Endereco { get; private set; }
        public string Telefone { get; private set; }
    }
}
