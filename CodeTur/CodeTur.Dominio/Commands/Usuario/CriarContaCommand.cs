using CodeTur.Comum;
using CodeTur.Comum.Comands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeTur.Dominio.Commands.Usuario
{
    //Feita a classe de criação de conta, e herdando not/Icommand
    public class CriarContaCommand : Notifiable<Notification>, ICommand
    {
        public CriarContaCommand()
        {

        }

        //Método construtor 
        public CriarContaCommand(string nome, string email, string senha, EnTipoUsuario tipoUsuario)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            TipoUsuario = tipoUsuario;
        }

        //Atributos
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        //Enumerador de identificação de usuário
        public EnTipoUsuario TipoUsuario { get;  set; }


        //Método de validação
        public void Validar()
        {
            //Passando os parâmetros para validação
            AddNotifications(
              new Contract<Notification>()
              .Requires()
              .IsNotEmpty(Nome, "Nome", "Nome não pode ser nulo")
              .IsEmail(Email, "Email", "Verifique novamente o endereço de email")
              .IsGreaterThan(Senha, 5, "Senha", "A senha deve conter no mínimo 8 caracteres")
              );
        }
    }
}
