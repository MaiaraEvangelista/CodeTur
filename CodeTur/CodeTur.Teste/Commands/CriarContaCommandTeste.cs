using CodeTur.Dominio.Commands.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CodeTur.Teste.Commands
{
    //Criação da classe criar conta 
    public class CriarContaCommandTeste
    {
        //Feito o método de teste
        //Atributo para indicar que é teste
        [Fact]
        public void RetornoDeSucessoDadosForemValidos()
        {
            //Fazendo uma instância
            var command = new CriarContaCommand();

            //Passando os atributos
            command.Nome = "Maiara";
            command.Email = "Maiara@email.com";
            command.Senha = "12345678";
            //Mostrando que o tipo usuário é adm, e usando o n=gerador de id
            command.TipoUsuario = CodeTur.Comum.EnTipoUsuario.Adm;

            //Fazendo validação
            command.Validar();

            //Confirmação de sucesso (dados corretos)
            Assert.True(command.IsValid, "Dados preenchidos corretamente");
        }
    }
}
