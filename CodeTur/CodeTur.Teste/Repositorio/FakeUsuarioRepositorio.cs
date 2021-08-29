using CodeTur.Dominio;
using CodeTur.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Teste.Repositorio
{
    //Cria a classe/implementa a interface
    class FakeUsuarioRepositorio : IUsuarioRepositorio
    {
        public void Adicionar(Usuario usuario)
        {
            
        }

        public void Alterar(Usuario usuario)
        {
            
        }

        public void AlterarSenha(Usuario usuario)
        {
            
        }

        public Usuario BuscarPorEmail(string email)
        {
            ////Verifica se esse email já existe
            //if (email != "email@email.com")
            //{
            //    //caso exista, retorna as informações
            //    return new Usuario("Maiara", "Maiara@email.com", "12345678", CodeTur.Comum.EnTipoUsuario.Adm);
            //}
            ////caso não
            //else
            //{
                //retorna nulo
                return null;
            
        }

        public Usuario BuscarPorId(Guid id)
        {
            //Faz a busca, e devolve a resposta
          return new Usuario("Maiara", "Maiara@email.com", "12345678", CodeTur.Comum.EnTipoUsuario.Adm);
        
        }

        public ICollection<Usuario> Listar(bool? ativo = null)
        {
            //Faz o retorno da lista de usuários
            return new List<Usuario>
            {
               new Usuario("Maiara", "Maiara@email.com", "12345678", CodeTur.Comum.EnTipoUsuario.Adm),
               new Usuario("Larissa", "Larissa@email.com", "98765432", CodeTur.Comum.EnTipoUsuario.Adm)
            };
            
        }
    }
}
