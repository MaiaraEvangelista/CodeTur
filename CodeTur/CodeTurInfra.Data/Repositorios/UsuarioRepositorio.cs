using CodeTur.Dominio;
using CodeTur.Dominio.Repositories;
using CodeTurInfra.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTurInfra.Data.Repositorios
{
    //Criação da classe de usuarioRepositorio, herdando de IUsuarioRepositorio
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        //Injeção de dependência
        private readonly CodeTurContexto _contexto;

        //Método construtor
        public UsuarioRepositorio(CodeTurContexto contexto)
        {
            //Fazendo referência
            _contexto = contexto;
        }

        /// <summary>
        /// Método para adicionar um usuário
        /// </summary>
        /// <param name="usuario">Objeto referenciando pessoa adicionada</param>
        public void Adicionar(Usuario usuario)
        {
            //Inicia o método de adicionar
            _contexto.Usuarios.Add(usuario);

            //Salva as alterações
            _contexto.SaveChanges();
        }

        /// <summary>
        /// Método que faz alteração de um usuário
        /// </summary>
        /// <param name="usuario">Parte que será alterado</param>
        public void Alterar(Usuario usuario)
        {
            //contexto instanciado/usuario referenciado/biblioteca (Entity é enumerador da biblioteca FC)/enumerador/modo de modificação
            _contexto.Entry(usuario).State = EntityState.Modified;
            //Salva as alterações
            _contexto.SaveChanges();
        }

        /// <summary>
        /// Método de buscar pelo email
        /// </summary>
        /// <param name="email">Endereço procurado</param>
        /// <returns>O  email referente a busca</returns>
        public Usuario BuscarPorEmail(string email)
        {
            //ToLower() = deixar tudo em letra minúscula 
            //Referenciando o _contexto
            //"Interligando" o email
            return _contexto.Usuarios.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
        }

        /// <summary>
        /// Método que faz a busca pelo identificador
        /// </summary>
        /// <param name="id">identificador</param>
        /// <returns>Usuário encontrado referenciado ao id</returns>
        public Usuario BuscarPorId(Guid id)
        {
            return _contexto.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Método de listagem
        /// </summary>
        /// <param name="ativo">Objeto que mostra se um usuário está ativo</param>
        /// <returns></returns>
        public ICollection<Usuario> Listar(bool? ativo = null)
        {
            return _contexto.Usuarios
                //Não permite pegar os dados armazenados em cash/somente leitura
                .AsNoTracking()
                .Include(x => x.Comentarios)//Incluindo os comentários
                .OrderBy(X => X.Date)
                .ToList();
        }
    }
}
