using Doacao.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doacao.Dominio.Commands.Autenticacao
{
    public class AlterarSenhaCommand : Notifiable<Notification>, ICommand
    {
        public AlterarSenhaCommand(string senha)
        {
            Senha = senha;
        }

        public string Senha { get; set; }

        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsGreaterThan(Senha, 7, "Senha", "A senha deve ter pelo menos 8 caracteres")
            );
        }
    }
}
