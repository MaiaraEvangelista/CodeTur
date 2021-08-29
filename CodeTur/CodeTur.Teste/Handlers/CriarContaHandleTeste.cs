using CodeTur.Comum.Comands;
using CodeTur.Dominio.Commands.Usuario;
using CodeTur.Dominio.Handlers.Usuarios;
using CodeTur.Teste.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CodeTur.Teste.Handlers
{
    //Cria a classe de criar conta
    public class CriarContaHandleTeste
    {
        //-----------------------REVER---------------------------
        //Propriedade de teste
        [Fact]
        public void RetornamCasoDadosValidos()
        {
            //ATRIBUTOS
            var command = new CriarContaCommand();
            command.Nome = "Maiara";
            command.Email = "Maiara@email.com";
            command.Senha = "12345678";
            command.TipoUsuario = CodeTur.Comum.EnTipoUsuario.Adm;

            //Criando um manipulador
            var handle = new CriarContaHandle(new FakeUsuarioRepositorio());

            //Captura de resultado
            var resultado = (GenericCommandResult)handle.Handler(command);

            //Validação
            Assert.True(resultado.Sucesso, "Usuário é válido");
        }
    }
}
