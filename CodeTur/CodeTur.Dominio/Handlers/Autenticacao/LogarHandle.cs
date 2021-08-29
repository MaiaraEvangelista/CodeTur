using CodeTur.Comum.Comands;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Comum.Utils;
using CodeTur.Dominio.Commands.Autenticacao;
using CodeTur.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Dominio.Handlers.Autenticacao
{
    //criada a classe de logarH
    public class LogarHandle : Notifiable<Notification>, IHandler<LogarCommand>
    {
        //Instanciação de IUsuario somente para leitura (readonly)
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        //Método construtor
        public LogarHandle(IUsuarioRepositorio usuarioRepositorio)
        {
            //indtanciando e referenciando o usuario repositorio
            _usuarioRepositorio = usuarioRepositorio;
        }

        //método para login
        public ICommandResult Handler(LogarCommand command)
        {
            //Faz a validação
            command.Validar();

            //Se a validação for false
            if (!command.IsValid)
            {
                //retorna uma mensagem 
                return new GenericCommandResult
                (
                    false,
                    "Os dados estão incorretos, por favor escreva-os corretamente!",
                    // notificação
                    command.Notifications
                );
            }

            //Fazer busca pelo email
            var usuario = _usuarioRepositorio.BuscarPorEmail(command.Email);

            //Verificando se o usuário é existente
            if (usuario == null)
            {
                //faz a consulta/retorna o erro/mensagem
                return new GenericCommandResult(false, "Usuário não existente", null);
            }

            //Validação dos hashs/ verificando se a senha é existente
            if (!Senha.ValidarHashes(command.Senha, usuario.Senha))
            {
                return new GenericCommandResult(false, "Senha inválida", null);
            }


            return new GenericCommandResult(true, "Logado com sucesso!", usuario);
        }
    }
}
