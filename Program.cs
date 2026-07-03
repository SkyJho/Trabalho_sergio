using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Final
{
    public class Program
    {
        // private static UsuarioController usuarioController = new UsuarioController();
        private static Livro livro = new Livro();
        // private static EmprestimoController emprestimoController = new EmprestimoController();
        // private static RelatorioController relatorioController = new RelatorioController();

        static void Main(string[] args)
        {


            bool x = true;
            while (x)
            {
                Console.WriteLine(@"===== SISTEMA DE BIBLIOTECA ===== 
1 - Cadastrar usuário 
2 - Listar usuários 
3 - Alterar usuário 
4 - Excluir usuário 
5 - Cadastrar livro 
6 - Listar livros 
7 - Buscar livro 
8 - Alterar livro 
9 - Excluir livro 
10 - Realizar empréstimo 
11 - Registrar devolução 
12 - Listar empréstimos em aberto 
13 - Listar histórico de empréstimos 
14 - Gerar relatório em arquivo texto 
0 - Sair 
Opção: ");
                int opcao = 0;
                bool valido = false;
                while (!valido)
                {
                    try
                    {
                        opcao = int.Parse(Console.ReadLine());
                        valido = true;
                    }
                    catch
                    {
                        Console.WriteLine("Opção inválida. Digite novamente: ");
                    }
                }
                if (opcao == 0)
                {
                    x = false;
                }
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Cadastrar usuário");
                        break;
                    case 2:
                        Console.WriteLine("Listar usuarios");
                        break;
                    case 3:
                        Console.WriteLine("Alterar usuário");
                        break;
                    case 4:
                        Console.WriteLine("Excluir usuário");
                        break;
                    case 5: cadastrarLivro();   break;

                    case 6: listarLivro();      break;

                    case 7: buscarLivro();      break;

                    case 8: alterarLivro();     break;

                    case 9: excluirLivro();     break;

                    case 10:
                        Console.WriteLine("Realizar empréstimo");
                        break;
                    case 11:
                        Console.WriteLine("Listar empréstimos em aberto");
                        break;
                    case 12:
                        Console.WriteLine("Listar histórico de empréstimos");
                        break;
                    case 13:
                        Console.WriteLine("Gerar relatório em arquivo texto");
                        break;
                    case 0:
                        Console.WriteLine("sair");
                        break;

                }

            }
        }
        public static void cadastrarLivro()
        {
            Livro novo = new Livro();
            Console.WriteLine("Digite o título do livro: ");
            novo.Titulo = Console.ReadLine();
            Console.WriteLine("Digite o autor do livro: ");
            novo.Autor = Console.ReadLine();
            Console.WriteLine("Digite o ano do livro: ");
            novo.Ano = 0;
            bool valido = false;

            while (!valido)
            {
                try
                {
                    novo.Ano = int.Parse(Console.ReadLine());
                    valido = true;
                }
                catch
                {
                    Console.WriteLine("Ano inválido. Digite novamente: ");
                }
            }

            novo.Disponivel = true;
            LivroDAO.cadastrarLivro(novo);
        }

        public static void listarLivro()
        {
            LivroDAO.listarLivros();
        }

        public static void buscarLivro()
        {
            Console.WriteLine("Digite o título ou autor do livro: ");
            string tituloOuAutor = Console.ReadLine();
            LivroDAO.buscarLivro(tituloOuAutor, tituloOuAutor);
        }

        public static void alterarLivro()
        {
            Console.WriteLine("Digite o ID do livro que deseja alterar: ");
            int Id = 0;
            bool valido = false;
            while (!valido)
            {
                try
                {
                    Id = int.Parse(Console.ReadLine());
                    valido = true;
                }
                catch
                {
                    Console.WriteLine("ID inválido. Digite novamente: ");
                }
            }
            LivroDAO.alterarLivro(Id);
        }

        public static void excluirLivro()
        {
            Console.WriteLine("Digite o ID do livro que deseja excluir: ");
            int id = 0;
            bool valido = false;
            while (!valido)
            {
                try
                {
                    id = int.Parse(Console.ReadLine());
                    valido = true;
                }
                catch
                {
                    Console.WriteLine("ID inválido. Digite novamente: ");
                }
            }
            LivroDAO.excluirLivro(id);
        }
    }
}
