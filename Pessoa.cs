using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Final
{
    public abstract class Pessoa
    {
        private int id;
        private string nome; 
        private string email;
        
        public int Id
        {
            get { return id; }
            set { Id = value; }
        }

        public string Nome
        {
            get { return nome;  }
            set { Nome = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public Pessoa(int id, string nome, string email)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
        }

        public abstract int CalcularPrazoDevolucao();

        public override string ToString()
        {
            return $"Id: {id} | Nome: {nome} | Email: {email}";
        }







    }
}
