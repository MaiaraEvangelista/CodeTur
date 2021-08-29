using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Dominio.Repositories
{
    //Feita a classe interface
    public interface IUsuarioRepositorio
    {
        //Atributos para o cadastro de um novo usuário
        void Adicionar(Usuario usuario);
        void Alterar(Usuario usuario);
        //void AlterarSenha(Usuario usuario);
        Usuario BuscarPorEmail(string email);
        Usuario BuscarPorId(Guid id);
        //Usuario BuscarPorSenha(string senha);
        ICollection<Usuario> Listar(bool? ativo = null);

    }
}
