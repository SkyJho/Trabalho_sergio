using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Final
{
    public class UsuarioDAO
    {

        public static Pessoa preenchePessoa(MySqlDataReader resultado)
        {
            string tipo = resultado["tipo"].ToString().ToUpper();
            Pessoa pessoa;
            switch (tipo)
            {
                case "ALUNO":
                    pessoa = new Aluno(
                        Convert.ToInt32(resultado["id_usuario"]),
                        resultado["nome"].ToString(),
                        resultado["email"].ToString(),
                        resultado["telefone"].ToString(),
                        resultado["endereco"].ToString()
                    );
                    break;

                case "PROFESSOR":
                    pessoa = new Professor(
                        Convert.ToInt32(resultado["id_usuario"]),
                        resultado["nome"].ToString(),
                        resultado["email"].ToString(),
                        resultado["telefone"].ToString(),
                        resultado["endereco"].ToString()
                    );
                    break;
                default:
                    throw new Exception("Tipo de usuário desconhecido.");
            }
            return pessoa;
        }
            
        public static void listarUsuarios()
        {
            MySqlConnection cn = Conexao.fazerConexao();
            cn.Open();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader resultado;
            cmd.CommandText = "SELECT * FROM usuarios";
            cmd.Connection = cn;
            resultado = cmd.ExecuteReader();
            Console.WriteLine("Id\tNome\tTelefone\tEndereco\tEmail\tTipo\n");
            while (resultado.Read())
            {
                Pessoa pessoa = preenchePessoa(resultado);
                Console.WriteLine(pessoa.ToString());
            }
            resultado.Close();
            cn.Close();
        }

        public static void cadastrarUsuario(Pessoa novo)
        {
            string tipo = novo is Aluno ? "ALUNO" : "PROFESSOR";
            MySqlConnection cn = Conexao.fazerConexao();
            cn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = $"INSERT INTO usuarios (Nome, Telefone, Endereco, Email, Tipo) VALUES ('{novo.Nome}', '{novo.Telefone}', '{novo.Endereco}', '{novo.Email}', '{tipo}')";
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public static void buscarUsuario(string nomeProcurado, string emailProcurado)
        {
            MySqlConnection cn = Conexao.fazerConexao();
            cn.Open();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader resultado;
            cmd.CommandText = $"SELECT * FROM usuarios WHERE Nome LIKE '%{nomeProcurado}%' OR Email LIKE '%{emailProcurado}%'";
            cmd.Connection = cn;
            resultado = cmd.ExecuteReader();
            if (resultado.HasRows)
            {
                while (resultado.Read())
                {
                    Pessoa pessoa = preenchePessoa(resultado);
                    Console.WriteLine(pessoa.ToString());
                }
            }
            else
            {
                Console.WriteLine("Usuário não encontrado.");
            }
            resultado.Close();
            cn.Close();
        }

        public static void alterarUsuario(int id)
        {
            MySqlConnection cn = Conexao.fazerConexao();
            cn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = $"SELECT * FROM usuarios WHERE id_usuario={id}";
            MySqlDataReader resultado = cmd.ExecuteReader();
            if (resultado.HasRows)
            {
                resultado.Read();
                Pessoa pessoa = preenchePessoa(resultado);

                resultado.Close();

                Console.Write("Digite o novo nome do usuário: ");
                string nome = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nome)) pessoa.Nome = nome;

                Console.Write("Digite o novo telefone do usuário: ");
                string telefone = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(telefone)) pessoa.Telefone = telefone;

                Console.Write("Digite o novo endereço do usuário: ");
                string endereco = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(endereco)) pessoa.Endereco = endereco;

                Console.Write("Digite o novo email do usuário: ");
                string email = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(email)) pessoa.Email = email;

                MySqlCommand cmdUpdate = new MySqlCommand();
                cmdUpdate.Connection = cn;
                cmdUpdate.CommandText = $"UPDATE usuarios SET Nome = '{pessoa.Nome}', Telefone = '{pessoa.Telefone}', Endereco = '{pessoa.Endereco}', Email = '{pessoa.Email}' WHERE id_usuario = {id}";
                cmdUpdate.ExecuteNonQuery();
                Console.WriteLine("Usuário alterado!\n");
            }
            else
            {
                Console.WriteLine("Usuário não encontrado.");
                resultado.Close();
            }
            cn.Close();
        }

        public static void excluirUsuario(int id)
        {
            MySqlConnection cn = Conexao.fazerConexao();
            cn.Open();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader resultado;
            cmd.Connection = cn;
            cmd.CommandText = $"SELECT * FROM usuarios WHERE id_usuario={id}";
            resultado = cmd.ExecuteReader();
            if (resultado.HasRows)
            {
                resultado.Read();
                Pessoa pessoa = preenchePessoa(resultado);
                resultado.Close();
                Console.Write("Tem certeza que deseja excluir este usuário? (s/n): ");
                string confirmacao = Console.ReadLine();
                if (confirmacao.ToLower() == "s")
                {
                    MySqlCommand cmdDelete = new MySqlCommand();
                    cmdDelete.Connection = cn;
                    cmdDelete.CommandText = $"DELETE FROM usuarios WHERE id_usuario={id}";
                    cmdDelete.ExecuteNonQuery();
                    Console.WriteLine("Usuário excluído com sucesso!");
                }
                else
                {
                    Console.WriteLine("Exclusão cancelada.");
                }
            }
            else
            {
                Console.WriteLine("Usuário não encontrado.");
                resultado.Close();
            }
            cn.Close();
        }
    }
}
