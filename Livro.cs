using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Final
{
    public class Livro
    {
        private int id;
        private string titulo;
        private string autor;
        private int ano;
        private bool disponivel;

        public Livro()
        {
            
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }

        public int Ano
        {
            get { return ano; }
            set { ano = value; }
        }

        public bool Disponivel
        {
            get { return disponivel; }
            set { disponivel = value; }
        }


        public Livro(int id, string titulo, string autor, int ano, bool disponivel)
        {
            this.id = id;
            this.titulo = titulo;
            this.autor = autor;
            this.ano = ano;
            this.disponivel = disponivel;
        }

        public override string ToString()
        {
            string status = disponivel ? "Disponível" : "Emprestado";
            return $"Id: {id} | Título: {titulo} | Autor: {autor} | Ano: {ano} | Status: {status}";
        }

        public void preencheLivro(MySqlDataReader resultado)
        {
            this.Id = Convert.ToInt32(resultado[0]);
            this.Titulo = resultado[1].ToString();
            this.Autor = resultado[2].ToString();
            this.Ano = Convert.ToInt32(resultado[3]);
            this.Disponivel = Convert.ToBoolean(resultado[4]);
        }

        public void mostrar()
        {
            Console.WriteLine($"{this.Id}\t{this.Titulo}\t{this.Autor}\t{this.Ano}\t{this.Disponivel}");
        }
    }
}
