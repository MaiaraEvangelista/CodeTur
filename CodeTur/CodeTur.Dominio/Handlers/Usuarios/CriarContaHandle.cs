using CodeTur.Comum.Comands;
using CodeTur.Comum.Handlers.Contracts;
using CodeTur.Comum.Utils;
using CodeTur.Dominio.Commands.Usuario;
using CodeTur.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Dominio.Handlers.Usuarios
{
    public class CriarContaHandle : Notifiable<Notification>, IHandler<CriarContaCommand>
    {
        //Instanciação de IUsuario somente para leitura (readonly)
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        //Método construtor
        public CriarContaHandle(IUsuarioRepositorio usuarioRepositorio)
        {
            //indtanciando e referenciando o usuario repositorio
            _usuarioRepositorio = usuarioRepositorio;
        }

        /// <summary>
        /// Método de criar conta
        /// </summary>
        /// <param name="command">instância de usuário</param>
        /// <returns>Uma conta criada</returns>
        public ICommandResult Handler(CriarContaCommand command)
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

            //Verificação de existencia do email
            var usuarioExiste = _usuarioRepositorio.BuscarPorEmail(command.Email);
            if (usuarioExiste != null)
            {
                return new GenericCommandResult(false, "Email já existente!", "Por favor, informe um novo endereço de email.");
            }


            //Fazendo instanciação do command, e a criptografia de senha
            command.Senha = Senha.Criptografar(command.Senha);




            //Salvando informações no banco
            Usuario u1 = new Usuario
                (
                command.Nome,
                command.Email,
                command.Senha,
                command.TipoUsuario
                );

            //Se forem inválidos, retornam uma notificação
            if (!u1.IsValid)
                return new GenericCommandResult(false, "Os dados informados são inválidos", u1.Notifications);
            _usuarioRepositorio.Adicionar(u1);
            
            //Confirma a criação de conta, mensagem, identificadores
            return new GenericCommandResult(true, "usuario criado", "token");
        }
    }
}
