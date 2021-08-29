using CodeTur.Comum;
using CodeTur.Comum.Enum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Dominio.Entidades
{
    //Criação da classe de comentário, herdando da base
    public class Comentario : Base
    {
        //Método construtor
        public Comentario(string texto, string sentimento, EnStatusComentario status, Guid idUsuario, Usuario usuario, Guid idPacote, Pacote pacote)
        {

            //Verificaçaõ de cumprimento de "contrato"
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotEmpty(texto, "Texto", "Texto não pode ser nulo")
                .IsNotEmpty(sentimento, "Sentimento", "Sentimento não pode ser nulo")
                .IsNotNull(status, "Status", "Status não pode ser nulo")
                .IsNotNull(idUsuario, "IdUsuario", "O id do usuário não pose ser vazio")
                .IsNotNull(idPacote, "IdPacote", "O id do pacote não pode ser nulo")
                //.IsNotNull()
                );

            if (IsValid)
            {
                //Valores
                Texto = texto;
                Sentimento = sentimento;
                Status = status;
                IdUsuario = idUsuario;
                Usuario = usuario;
                IdPacote = idPacote;
                Pacote = pacote;
            }
            
        }

        //"Atributos"
        public string Texto { get; private set; }

        public string Sentimento { get; private set; }

        public EnStatusComentario Status { get; private set; }

        //Gerador de id para usuário
        public Guid IdUsuario { get; private set; }
        public Usuario Usuario { get; private set; }

        //Gerador de id para Pacote
        public Guid  IdPacote { get; private set; }
        public Pacote Pacote { get; private set; }







    }
}
