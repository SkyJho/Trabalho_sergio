using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Final
{
    public class Professor : Pessoa
    {
        public Professor(int id, string nome, string email, string telefone, string endereco) : base(id, nome, email, telefone, endereco)
        {
        }

        public override int CalcularPrazoDevolucao()
        {
            return 15;
        }

        public override string ToString()
        {
            return base.ToString() + " | Tipo: Professor";
        }
    }
}
