using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Final
{
    public class Aluno : Pessoa
    {

        public Aluno(int id, string nome, string email, string telefone, string endereco) : base(id, nome, email, telefone, endereco)
        {
        }

 
        public override int CalcularPrazoDevolucao()
        {
            return 7; 
        }

        public override string ToString()
        {
            return base.ToString() + " | Tipo: Aluno";
        }
    }
}
