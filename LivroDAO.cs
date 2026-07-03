using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Final
{
    public class LivroDAO
    {
        public static void listarLivros()
        {
            MySqlConnection cn = Conexao.fazerConexao();
            cn.Open();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader resultado;
            cmd.CommandText = "SELECT * FROM livros";
            cmd.Connection = cn;
            resultado = cmd.ExecuteReader();
            Console.WriteLine("Id\tTitulo\tAutor\tAno\tDisponivel");
            while (resultado.Read())
            {
                Livro livro = new Livro();
                livro.preencheLivro(resultado);
                livro.mostrar();
            }
            resultado.Close();
            cn.Close();
        }

        public static void cadastrarLivro(Livro novo)
        {
            MySqlConnection cn = Conexao.fazerConexao();
            cn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = $"INSERT INTO livros (Titulo, Autor, Ano, Disponivel) VALUES ('{novo.Titulo}', '{novo.Autor}', {novo.Ano}, {novo.Disponivel})";
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}
