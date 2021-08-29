using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Comum
{
    //Criação da classe Base, herdando de flunt
    public abstract class Base : Notifiable<Notification>
    {
        //Método construtor
        public Base()
        {
            //Passa a referência do id
            Id = Guid.NewGuid();

            Date = DateTime.Now;
        }


        //Gerador de identificadores(id)
        public Guid Id { get; set; }

        public DateTime Date { get; set; }
    }
}
