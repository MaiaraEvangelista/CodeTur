using CodeTur.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CodeTur.Teste
{
    //Criando a classe de testes
    public class UsuarioTeste
    {
        //Identifica que isso é um teste
        [Fact]
        //não obtém retorno
        public void DeveRetornarSeUsuarioValido()
        {
            //Faz a instância de usuário
            Usuario usuario = new Usuario(
                //Passa os atributos obrigatórios
                "Maiara",
                "Maiara@email.com",
                "12345678",
                //Define de qual projeto pega a info, e define qual tipo de usuário
                CodeTur.Comum.EnTipoUsuario.Adm
                );
            //verificação de teste para cumprimento das obrigatoriedades(todos os campos preenchidos corretamente)
            Assert.True(usuario.IsValid);



        }


        //Exemplo Inválido apenas para teste
        //[Fact]
        //public void DeveRetornarSeUsuarioInvalido()
        //{
        //    //Faz a instância de usuário
        //    Usuario usuario = new Usuario(
        //        //Passa os atributos obrigatórios
        //        "Maiara",
        //        "Maiara@email",
        //        "1234",
        //        //Define de qual projeto pega a info, e define qual tipo de usuário
        //        CodeTur.Comum.EnTipoUsuario.Adm
        //        );
        //    //verificação de teste para cumprimento das obrigatoriedades(todos os campos preenchidos corretamente)
        //    Assert.True(usuario.IsValid);
        //}
    }
}
