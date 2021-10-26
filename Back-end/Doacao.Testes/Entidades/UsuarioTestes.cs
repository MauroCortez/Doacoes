using Doacao.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Doacao.Testes
{
    public class UsuarioTestes
    {
        [Fact]
        public void DeveRetornarSeUsuarioForValido()
        {
            Usuario usuario = new Usuario(
                    "Mauro",
                    "mauro.cortez@gmail.com",
                    "123456789",
                    Comum.EnTipoUsuario.Doador,
                    "Rua Aracanguira",
                    "1138510879",
                    "11995634201"
                );

                Assert.True(usuario.IsValid, "Usuário validado");
        }


        [Fact]
        public void DeveRetornarSeUsuarioForInvalidoSemNome()
        {
            Usuario usuario = new Usuario(
                    "",
                    "mauro.cortez@gmail.com",
                    "123456789",
                    Comum.EnTipoUsuario.Doador,
                    "Rua Aracanguira",
                    "1138510879",
                    "11995634201"
                );

            Assert.True(!usuario.IsValid, "Usuário invalido sem nome");
        }


        [Fact]
        public void DeveRetornarSeUsuarioForInvalidoSemEmail()
        {
            Usuario usuario = new Usuario(
                    "Mauro",
                    "mauro.cortez@",
                    "123456789",
                    Comum.EnTipoUsuario.Doador,
                    "Rua Aracanguira",
                    "1138510879",
                    "11995634201"
                );

            Assert.True(!usuario.IsValid, "Usuário invalido com email errado");
        }

        [Fact]
        public void DeveRetornarSeUsuarioForInvalidoComSenhaFraca()
        {
            Usuario usuario = new Usuario(
                    "Mauro",
                    "mauro.cortez@gmail.com",
                    "1234",
                    Comum.EnTipoUsuario.Doador,
                    "Rua Aracanguira",
                    "1138510879",
                    "11995634201"
                );

            Assert.True(!usuario.IsValid, "Usuário invalidado com senha fraca");
        }

        [Fact]
        public void DeveRetornarSeUsuarioForInvalidoSemTelefone()
        {
            Usuario usuario = new Usuario(
                    "Mauro",
                    "mauro.cortez@gmail.com",
                    "123456789",
                    Comum.EnTipoUsuario.Doador,
                    "Rua Aracanguira",
                    "",
                    "11995634201"
                );

            Assert.True(!usuario.IsValid, "Usuário invalidado sem telefone");
        }

        [Fact]
        public void DeveRetornarSeUsuarioForInvalidoComSemCelular()
        {
            Usuario usuario = new Usuario(
                    "Mauro",
                    "mauro.cortez@gmail.com",
                    "123456789",
                    Comum.EnTipoUsuario.Doador,
                    "Rua Aracanguira",
                    "1138510879",
                    ""
                );

            Assert.True(!usuario.IsValid, "Usuário invalidado sem celular");
        }
    }
}
