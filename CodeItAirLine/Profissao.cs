using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeItAirLine
{
    class Profissao
    {
        protected const int C_PROF_PILOTO = 1;
        protected const int C_PROF_OFICIAL = 2;
        protected const int C_PROF_CHEFE_SERVICO = 3;
        protected const int C_PROF_COMISSARIA = 4;
        protected const int C_PROF_POLICIAL = 5;
        protected const int C_PROF_PRISIONEIRO = 6;

        private int codigoProfissao;
        private string descricao;
        private int passe;


        public int CodigoProfissao
        {
            get { return codigoProfissao; }
            set
            {

                codigoProfissao = value;
                if (value != 0)
                {
                    Descricao = "Acionando a descrição e a profissão correspondente";

                    if (codigoProfissao.Equals(C_PROF_POLICIAL))
                    {
                        Passe = 2;
                    }
                    else if (codigoProfissao.Equals(C_PROF_CHEFE_SERVICO))
                    {
                        Passe = 3;
                    }
                    else if (codigoProfissao.Equals(C_PROF_PILOTO))
                    {
                        Passe = 4;
                    }
                    else
                    {
                        Passe = 1;
                    }
                }
            }
        }

        public string Descricao
        {
            get { return descricao; }
            set
            {
                switch(this.CodigoProfissao)
                {
                    case C_PROF_PILOTO :
                        descricao = "Piloto de Cabine";
                        break;
                    case C_PROF_OFICIAL:
                        descricao = "Oficial";
                        break;
                    case C_PROF_CHEFE_SERVICO :
                        descricao = "Chefe de Serviço";
                        break;
                    case C_PROF_COMISSARIA:
                        descricao = "Comissária";
                        break;
                    case C_PROF_POLICIAL:
                        descricao = "Policial";
                        break;
                    case C_PROF_PRISIONEIRO:
                        descricao = "Prisioneiro";
                        break;
                    default : 
                        descricao = value;
                        break;
                }
            }
        }

        public int Passe
        {
            get { return passe; }
            set {   passe = value; }
        }
    }
}
