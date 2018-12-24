using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeItAirLine
{
    class Pessoa : Profissao
    {
        private int codigoPessoa;
        private string nome;

        public int CodigoPessoa
        {
            get { return codigoPessoa; }
            set { codigoPessoa = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

    }
}