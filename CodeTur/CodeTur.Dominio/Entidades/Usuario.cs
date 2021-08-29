using CodeTur.Comum;
using CodeTur.Dominio.Entidades;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Dominio
{
    //Cria  a classe usuário e herda da classe Base
    public class Usuario : Base
    {
        //Método construtor
        public Usuario(string nome, string email, string senha, EnTipoUsuario tipoUsuario)
        {
            //Verificação de cumprimento de "contrato"
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotEmpty(nome, "Nome", "Nome não pode ser nulo" )
                .IsEmail(email, "Email", "Verifique novamente o endereço de email")
                .IsGreaterThan(senha, 5, "Senha", "A senha deve conter no mínimo 8 caracteres")
                );

            if (IsValid)
            {
                //Passando os atributos e referenciando
                Nome = nome;
                Email = email;
                Senha = senha;
                TipoUsuario = tipoUsuario;
            }
       
        }

        //Atributos da classe usuário
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        //Enumerador de identificação de usuário
        public EnTipoUsuario TipoUsuario { get; private set; }

        //Listagem dos comentários
        public List<Comentario> Comentarios { get; set; }

        //Criando método de atualização de senha
        public void AtualizarSenha(string senha)
        {
            //Adiciona o parâmetro padrão
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsGreaterThan(senha, 5, "Senha", "A senha deve conter no mínimo 8 caracteres")
                );

            //Verificação de validez
            if (IsValid)
            {
                Senha = senha;
            }
        }

        //Método de atualização de usuário
        public void AtualizaUsuario(string nome, string email)
        {
            //Adiciona o parâmetro padrão
            AddNotifications(
               new Contract<Notification>()
               .Requires()
               .IsNotEmpty(nome, "Nome", "Nome não pode ser nulo")
               .IsEmail(email, "Email", "Verifique novamente o endereço de email")
               );

            //Verificação de validez
            if (IsValid)
            {
                Nome = nome;
                Email = email;
            }
        }
    }
}
