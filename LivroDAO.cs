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
            Console.WriteLine("Id\tTitulo\tAutor\tAno\tDisponivel\n");
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

        public static void buscarLivro(string tituloProcurado)
        {
            MySqlConnection cn = Conexao.fazerConexao();
            cn.Open();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader resultado;
            cmd.CommandText = $"SELECT * FROM livros WHERE Titulo LIKE '%{tituloProcurado}%'";
            cmd.Connection = cn;
            resultado = cmd.ExecuteReader();
            if (resultado.HasRows)
            {
                resultado.Read();
                Livro livro = new Livro();
                livro.preencheLivro(resultado);
                livro.mostrar();
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
            resultado.Close();
            cn.Close();
        }

        public static void alterarLivro(int id)
        {
            MySqlConnection cn = Conexao.fazerConexao();
            cn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = $"SELECT * FROM livros WHERE Id = {id}";
            MySqlDataReader resultado = cmd.ExecuteReader();
            if (resultado.HasRows)
            {
                resultado.Read();
                Livro livro = new Livro();
                livro.preencheLivro(resultado);
                livro.mostrar();

                resultado.Close();

                Console.Write("Digite o novo título do livro: ");
                string titulo = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(titulo)) livro.Titulo = titulo;

                Console.Write("Digite o novo autor do livro: ");
                string autor = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(autor)) livro.Autor = autor;

                Console.WriteLine("Digite o ano correto do livro: ");
                int ano = int.Parse(Console.ReadLine());
                if (!int.TryParse(Console.ReadLine(), out ano)) livro.Ano = ano;

                MySqlCommand cmdUpdate = new MySqlCommand();
                cmdUpdate.Connection = cn;
                cmdUpdate.CommandText = $"UPDATE livros SET Titulo = '{livro.Titulo}', Autor = '{livro.Autor}', Ano = {livro.Ano} WHERE Id = {id}";
                cmdUpdate.ExecuteNonQuery();
                Console.WriteLine("Livro alterado!\n");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
                resultado.Close();
            }
            cn.Close();
        }

        public static void excluirLivro(int id)
        {
            MySqlConnection cn = Conexao.fazerConexao();
            cn.Open();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader resultado;
            cmd.Connection = cn;
            cmd.CommandText = $"SELECT * FROM livros WHERE id={id}";
            resultado = cmd.ExecuteReader();
            if (resultado.HasRows)
            {
                resultado.Read();
                Livro livro = new Livro();
                livro.preencheLivro(resultado);
                livro.mostrar();
                resultado.Close();
                Console.Write("Tem certeza que deseja excluir este livro? (s/n): ");
                string confirmacao = Console.ReadLine();
                if (confirmacao.ToLower() == "s")
                {
                    MySqlCommand cmdDelete = new MySqlCommand();
                    cmdDelete.Connection = cn;
                    cmdDelete.CommandText = $"DELETE FROM livros WHERE id={id}";
                    cmdDelete.ExecuteNonQuery();
                    Console.WriteLine("Livro excluído com sucesso!");
                }
                else
                {
                    Console.WriteLine("Exclusão cancelada.");
                }

            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
                resultado.Close();
            }
            cn.Close();
        }
    }
}
