using Doacao.Comum.Commands;
using Doacao.Comum.Handlers.Contracts;
using Doacao.Dominio.Commands.Usuario;
using Doacao.Dominio.Repositorios;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doacao.Dominio.Handlers.Usuarios
{
    public class CriarContaHandle : Notifiable<Notification>, IHandler<CriarContaCommand>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public CriarContaHandle(IUsuarioRepositorio usurioRepositorio)
        {
            _usuarioRepositorio = usurioRepositorio;
        }

        public ICommandResult Handler(CriarContaCommand command)
        {
            //Validar nosso comando
            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult
                    (
                        false,
                        "Informe corretamente os dados de usuário",
                        command.Notifications
                    );
            }

            // Verificar se o email existe
            var usuarioExiste = _usuarioRepositorio.BuscarPorEmail(command.Email);
            if (usuarioExiste != null)
                return new GenericCommandResult(false, "Email já cadastrado", "Informe outro email");

            // Critografar senha
            // Salvar no banco
            Usuario u1 = new Usuario
                (
                    command.Nome,
                    command.Email,
                    command.Senha,
                    command.TipoUsuario,
                    command.Endereco,
                    command.Telefone
                );

            if (!u1.IsValid)
                return new GenericCommandResult(false, "Dados de usuário invalidos", u1.Notifications);

            _usuarioRepositorio.Adicionar(u1);
            // Enviar um email de boas vindas

            return new GenericCommandResult(true, "Usuário criado", "Token");
        }
    }
}
