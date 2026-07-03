using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Final
{
    public class Professor : Pessoa
    {
        public Professor(int id, string nome, string email) : base(id, nome, email)
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
