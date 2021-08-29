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
    //Gerando a classe de LogarC, tendo herança
    public class LogarCommand : Notifiable<Notification>, ICommand
    {
        //Método construtor
        public LogarCommand(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        //Atributos
        public string Email { get; set; }
        public string Senha { get; set; }


        //Implementado o método de validar
        public void Validar()
        {
            //Valores para validação
            AddNotifications(
              new Contract<Notification>()
              .Requires()
              .IsEmail(Email, "Email", "Verifique novamente o endereço de email")
               .IsGreaterThan(Senha, 5, "senha", "Nome não pode ser nulo")
              );

        }
    }
}
