using Doacao.Comum.Commands;
using Doacao.Dominio.Commands.Usuario;
using Doacao.Dominio.Handlers.Usuarios;
using Doacao.Testes.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Doacao.Testes.Handlers
{
    public class CriarContaHandleTeste
    {
        [Fact]
        public void DeveRetoenarCasoDadosDoHandleSejamValidos()
        {

            // Comando
            var command = new CriarContaCommand();
            command.Nome = "Mauro";
            command.Email = "mauro@gmail.com";
            command.Senha = "123456789";
            command.TipoUsuario = Comum.EnTipoUsuario.Doador;
            command.Endereco = "Rua Arroz";
            command.Telefone = "1138510879";
            command.Celular = "11995634201";

            // Manipulador
            var handle = new CriarContaHandle(new FakeUsuarioRepositorio() );

            // Pegar resultado
            var resultado = (GenericCommandResult)handle.Handler(command);

            // Validar a condição
            Assert.True(resultado.Sucesso, "Usuário válido");
        }
    }
}
