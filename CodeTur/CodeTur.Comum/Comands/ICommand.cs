using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Comum.Comands
{
    //Criação da interface de ICommand
    public interface ICommand
    {
        //Validação
        void Validar();
    }
}
