using CodeTur.Comum;
using CodeTur.Comum.Enum;
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
    //Criando a classe Pacote, herdando da base
    public class Pacote : Base
    {
        //Método construtor
        public Pacote(string titulo, string imagem, string descricao, EnStatusPacote status)
        {

            //Verificação de cumprimento de "contrato"
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotEmpty(titulo, "Titulo", "Titulo não pode ser nulo")
                .IsNotEmpty(imagem, "Imagem", "A imagem é obrigatória!")
                .IsNotEmpty(descricao, "Descricao", "É obrigatório ter uma descrição")
                .IsNotNull(status, "Status", "O status é obrigatório")
                );

            if (true)
            {
                //Atributos
                Titulo = titulo;
                Imagem = imagem;
                Descricao = descricao;
                Status = status;
            }
           
        }

        //Passando os atributos
        public string Titulo { get; private set; }
        public string Imagem { get; private set; }
        public string  Descricao { get; private set; }

        //Enumerador de status
        public EnStatusPacote Status { get; private set; }
    
        //Listagem dos comentários
        //_comentarios foi adicionado para fazer a listagem, já que o outro método é privado
        public List<Comentario> Comentarios { get { return _comentarios; } }    

        //Alteração de comentários
        private List<Comentario> _comentarios { get; set; }
    
    
        //Regras de usuário
        //Define que o usuário só pode ter um comentário a cada pacote 
        public void AdicionarComentario(Comentario comentario)
        {
            //Se nos comentários tiver o id de um usuário específico
            if (_comentarios.Any(x => x.IdUsuario == comentario.IdUsuario))
                //Adiciona uma notificação de que o usuário já possui comentários ali
                AddNotification("Comentario", "Este usuário já possui comentário neste pacote");

            //Se for válido
            if (IsValid)
            {
                //Adiciona um comentário
                _comentarios.Add(comentario);
            }
        }
    
    
    
    
    
    
    
    
    
    
    
    
    
    }
}
