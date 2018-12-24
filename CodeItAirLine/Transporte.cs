using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeItAirLine
{
    class Transporte : Pessoa
    {
        public void TransportarPassageiros(Pessoa pessoa1, Pessoa pessoa2)
        {

            try
            {
                if ((pessoa1.CodigoProfissao == C_PROF_PRISIONEIRO) && (pessoa2.CodigoProfissao != C_PROF_POLICIAL))
                {
                    throw new ArgumentException("Não está autorizado acompanhar o Prisioneiro além do Policial");
                }

                if (((pessoa1.CodigoProfissao == C_PROF_POLICIAL) && 
                    ((pessoa2.CodigoProfissao != C_PROF_PRISIONEIRO) &&
                    (pessoa2.CodigoProfissao != C_PROF_PILOTO) && 
                    (pessoa2.CodigoProfissao != C_PROF_CHEFE_SERVICO)))||
                    (pessoa1.CodigoProfissao == C_PROF_OFICIAL && pessoa2.CodigoProfissao == C_PROF_OFICIAL)||
                    (pessoa1.CodigoProfissao == C_PROF_COMISSARIA && pessoa2.CodigoProfissao == C_PROF_COMISSARIA))
                {
                    throw new ArgumentException(pessoa2.Descricao + " não tem permissão para dirigir o Smart Fortwo");
                }

                if ((pessoa1.CodigoProfissao == C_PROF_COMISSARIA && pessoa2.CodigoProfissao == C_PROF_OFICIAL) || (pessoa1.CodigoProfissao == C_PROF_OFICIAL && pessoa2.CodigoProfissao == C_PROF_COMISSARIA))
                {
                    throw new ArgumentException(pessoa1.Descricao + " e " + pessoa2.Descricao + " não tem permissão para dirigir o Smart Fortwo");
                }

                if (
                    (pessoa1.CodigoProfissao == C_PROF_PILOTO) &&
                    ((pessoa2.CodigoProfissao != C_PROF_OFICIAL) &&
                     (pessoa2.CodigoProfissao != C_PROF_CHEFE_SERVICO) &&
                     (pessoa2.CodigoProfissao != C_PROF_POLICIAL))
                    )
                {
                    throw new ArgumentException("Pela política da empresa, não é permitido utilizar Smart Fortwo entre " + pessoa1.Descricao + " e " + pessoa2.Descricao);
                }

                if (
                  (pessoa1.CodigoProfissao == C_PROF_CHEFE_SERVICO) &&
                  ((pessoa2.CodigoProfissao != C_PROF_COMISSARIA) &&
                   (pessoa2.CodigoProfissao != C_PROF_PILOTO) &&
                   (pessoa2.CodigoProfissao != C_PROF_POLICIAL))
                  )
                {
                    throw new ArgumentException("Pela política da empresa, não é permitido utilizar Smart Fortwo entre " + pessoa1.Descricao + " e " + pessoa2.Descricao);
                }

                if ((pessoa1.CodigoProfissao == C_PROF_OFICIAL) && (pessoa2.CodigoProfissao != C_PROF_PILOTO))
                {
                    throw new ArgumentException("Pela política da empresa, somente é permitido um Oficial acompanhar o Piloto de Cabine");
                }

                if ((pessoa1.CodigoProfissao == C_PROF_COMISSARIA) && (pessoa2.CodigoProfissao != C_PROF_CHEFE_SERVICO))
                {
                    throw new ArgumentException("Pela política da empresa, somente é permitido uma Comissária acompanhar o Chefe de Serviço");
                }
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }

            pessoa1.Passe--;
            pessoa2.Passe-- ;
        }

        public void VerificarOrdemChegadaAviao(Pessoa pessoa1, Pessoa pessoa2)
        {
            List<Pessoa> listaPessoas1 = new List<Pessoa>() { pessoa1 };
            List<Pessoa> listaPessoas2 = new List<Pessoa>() { pessoa2 };
            VerificarOrdemChegadaAviaoBase(listaPessoas1, listaPessoas2);
        }

        public void VerificarOrdemChegadaAviao(List<Pessoa> listaTotalPessoas)
        {
            List<Pessoa> listaPessoas1 = new List<Pessoa>()
            {
                listaTotalPessoas[0],listaTotalPessoas[1],listaTotalPessoas[2],listaTotalPessoas[3]
            };
            List<Pessoa> listaPessoas2 = new List<Pessoa>()
            {
                listaTotalPessoas[4],listaTotalPessoas[5],listaTotalPessoas[6],listaTotalPessoas[7]
            };
            VerificarOrdemChegadaAviaoBase(listaPessoas1, listaPessoas2);

        }

        private void VerificarOrdemChegadaAviaoBase(List<Pessoa> listaPessoas1, List<Pessoa> listaPessoas2)
        { 
            try
            {
                List<Pessoa> listaPessoasEntregues = new List<Pessoa>();
                List<Pessoa> listaPessoasTransportou = new List<Pessoa>();
                
                bool novoCiclo = true;
                for (int i = 0; i < listaPessoas1.Count; i++)
                {
                    novoCiclo = false;
                    for (int j = 0; j < listaPessoas2.Count; j++)
                    {
                        if (novoCiclo) continue;
                        TransportarPassageiros(listaPessoas1[i], listaPessoas2[j]);

                        if (listaPessoas1[i].Passe.Equals(0))
                        {
                            if (listaPessoas1.Count != 1)
                            {
                                listaPessoasEntregues.Add(listaPessoas1[i]);
                                listaPessoasTransportou.Add(listaPessoas2[j]);
                                listaPessoas1.RemoveAt(i);
                                novoCiclo = true;
                                i--;
                            }
                        }
                        else
                            if (i > 0) i--;

                        if (listaPessoas2[j].Passe.Equals(0))
                        {
                            listaPessoasEntregues.Add(listaPessoas2[j]);
                            if (listaPessoas1.Count > 0)
                            {
                                listaPessoasTransportou.Add(listaPessoas1[i]);
                            }
                            listaPessoas2.RemoveAt(j);
                            if (j == 0) j--;
                        }
                        else
                            if (j > 0) j--;
                    }
                }


                for (int i = 0; i < listaPessoasEntregues.Count; i++)
                {
                    Console.WriteLine(listaPessoasEntregues[i].Nome + "(" + listaPessoasEntregues[i].Descricao +
                        ")  foi levado por " + listaPessoasTransportou[i].Nome + "(" + listaPessoasTransportou[i].Descricao + ")");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
