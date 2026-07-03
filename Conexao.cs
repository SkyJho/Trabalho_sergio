using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Final
{
    public static class Conexao
    {

        public static MySqlConnection fazerConexao()
        {
            MySqlConnection conexao = new MySqlConnection("server=127.0.0.1; database=biblioteca; uid=root; pwd=;");
            return conexao;
        }

        
    }
}
