using MySql.Data.MySqlClient;
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
        private string telefone;
        private string endereco;
        
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nome
        {
            get { return nome;  }
            set { nome = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }
        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        public Pessoa(int id, string nome, string email, string telefone, string endereco)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.telefone = telefone;
            this.endereco = endereco;
        }

        public abstract int CalcularPrazoDevolucao();

        public override string ToString()
        {
            return $"Id: {id} | Nome: {nome} | Email: {email} | telefone: {telefone} | Endereco: {endereco}";
        }


        
       




    }
}
