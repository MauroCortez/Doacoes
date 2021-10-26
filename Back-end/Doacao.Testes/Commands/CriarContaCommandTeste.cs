using Doacao.Dominio.Commands.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Doacao.Testes.Commands
{
    public class CriarContaCommandTeste
    {

        [Fact]
        public void DeveRetornarSucessoSeDadosForemValidos()
        {
            var command = new CriarContaCommand();
            command.Nome = "Mauro";
            command.Email = "mauro.cortez@gmail.com";
            command.Senha = "12345678";
            command.TipoUsuario = Comum.EnTipoUsuario.Doador;
            command.Endereco = "Rua Aracanguira";
            command.Telefone = "1138510879";
            command.Celular = "11995634201";

            command.Validar();

            Assert.True(command.IsValid, "Os dados foram preenchidos corretamente");
        }

    }
}
