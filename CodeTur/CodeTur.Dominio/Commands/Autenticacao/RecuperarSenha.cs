using CodeTur.Comum.Comands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Dominio.Commands.Autenticacao
{
    //Feita a classe de recuperação de senha
    public class RecuperarSenha : Notifiable<Notification>, ICommand
    {
        //Método construtor 
        public RecuperarSenha(string email)
        {
            Email = email;
        }

        //Atributos
        public string Email { get; set; }

        //Método de validação
        public void Validar()
        {
            //Parâmetros 
            AddNotifications(
             new Contract<Notification>()
             .Requires()
             .IsEmail(Email, "Email", "Verifique novamente o endereço de email")
             );
        }
    }
}
