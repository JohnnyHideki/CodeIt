using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeItAirLine
{
    
    class TransporteTest
    {
        private List<Pessoa> listaTotalPessoas; 
        private Transporte transporte;

        public TransporteTest()
        {
            Pessoa piloto = new Pessoa()
            {
                CodigoPessoa = 1,
                Nome = "João",
                CodigoProfissao = (int)ProfissaoEnum.Piloto
            };

            Pessoa prisioneiro = new Pessoa()
            {
                CodigoPessoa = 2,
                Nome = "Waldisney",
                CodigoProfissao = (int)ProfissaoEnum.Prisioneiro
            };

            Pessoa oficial1 = new Pessoa()
            {
                CodigoPessoa = 3,
                Nome = "Carlos",
                CodigoProfissao = (int)ProfissaoEnum.Oficial
            };

            Pessoa oficial2 = new Pessoa()
            {
                CodigoPessoa = 4,
                Nome = "Jean",
                CodigoProfissao = (int)ProfissaoEnum.Oficial
            };


            Pessoa policial = new Pessoa()
            {
                CodigoPessoa = 5,
                Nome = "Mario",
                CodigoProfissao = (int)ProfissaoEnum.Policial
            };

            Pessoa commissaria1 = new Pessoa()
            {
                CodigoPessoa = 6,
                Nome = "Ana",
                CodigoProfissao = (int)ProfissaoEnum.Comissaria
            };

            Pessoa commissaria2 = new Pessoa()
            {
                CodigoPessoa = 7,
                Nome = "Maria",
                CodigoProfissao = (int)ProfissaoEnum.Comissaria
            };

            Pessoa chefe = new Pessoa()
            {
                CodigoPessoa = 8,
                Nome = "Bernardo",
                CodigoProfissao = (int)ProfissaoEnum.ChefeServico
            };

            listaTotalPessoas = new List<Pessoa>()
            {
                 policial, oficial1, oficial2, chefe,
                 prisioneiro, piloto, commissaria1,commissaria2
            };

            transporte = new Transporte(); 
        }

        private void GerarMensagemExcecao(Pessoa pessoa1, Pessoa pessoa2)
        {
            try
            {
                transporte.TransportarPassageiros(pessoa1, pessoa2);
                //Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

        }

        //[TestMethod]
        //[ExpectedException(typeof(Exception, ""))]
        public void Nao_Deve_Permitir_Prisioneiro_Acompanhar_Outro_Tripulante_Alem_De_Policial()
        {
            Pessoa prisioneiro = listaTotalPessoas.Where(x => x.CodigoProfissao == (int)ProfissaoEnum.Prisioneiro).FirstOrDefault();
            Pessoa commissaria = listaTotalPessoas.Where(x => x.CodigoProfissao == (int)ProfissaoEnum.Comissaria).FirstOrDefault();
            GerarMensagemExcecao(prisioneiro, commissaria);
        }

        public void Nao_Deve_Permitir_Comissaria_Acompanhar_Outro_Tripulante_Alem_De_Chefe_De_Servico()
        {
            Pessoa piloto = listaTotalPessoas.Where(x => x.CodigoProfissao == (int)ProfissaoEnum.Piloto).FirstOrDefault();
            Pessoa commissaria = listaTotalPessoas.Where(x => x.CodigoProfissao == (int)ProfissaoEnum.Comissaria).FirstOrDefault();
            GerarMensagemExcecao(piloto, commissaria);
        }

        public void Nao_Deve_Permitir_Oficial_Acompanhar_Outro_Tripulante_Alem_De_Piloto_De_Cabine()
        {
            Pessoa oficial = listaTotalPessoas.Where(x => x.CodigoProfissao == (int)ProfissaoEnum.Oficial).FirstOrDefault();
            Pessoa chefe = listaTotalPessoas.Where(x => x.CodigoProfissao == (int)ProfissaoEnum.ChefeServico).FirstOrDefault();
            GerarMensagemExcecao(oficial, chefe);
        }

        public void Nao_Deve_Permitir_Oficial_Dirigir_Smart_Fortwo() 
        {
            Pessoa oficial1 = listaTotalPessoas.Where(x => x.CodigoProfissao == (int)ProfissaoEnum.Oficial).FirstOrDefault();
            Pessoa oficial2 = listaTotalPessoas.Where(x => x.CodigoProfissao == (int)ProfissaoEnum.Oficial).FirstOrDefault();
            GerarMensagemExcecao(oficial1, oficial2);
        }

        public void Nao_Deve_Permitir_Comissaria_Dirigir_Smart_Fortwo()
        {
            Pessoa comissaria1 = listaTotalPessoas.Where(x => x.CodigoProfissao == (int)ProfissaoEnum.Comissaria).FirstOrDefault();
            Pessoa comissaria2 = listaTotalPessoas.Where(x => x.CodigoProfissao == (int)ProfissaoEnum.Comissaria).FirstOrDefault();
            GerarMensagemExcecao(comissaria1, comissaria2);
        }

        public void Nao_Deve_Permitir_Oficial_E_Comissaria_Dirigir_Smart_Fortwo()
        {
            Pessoa oficial = listaTotalPessoas.Where(x => x.CodigoProfissao == (int)ProfissaoEnum.Oficial).FirstOrDefault();
            Pessoa comissaria = listaTotalPessoas.Where(x => x.CodigoProfissao == (int)ProfissaoEnum.Comissaria).FirstOrDefault();
            GerarMensagemExcecao(oficial, comissaria);
        }

        public void Deve_Permitir_Piloto_Levar_Oficial_Para_Aviao()
        {
            Pessoa piloto = listaTotalPessoas.Where(x => x.CodigoProfissao == (int)ProfissaoEnum.Piloto).FirstOrDefault();
            Pessoa oficial = listaTotalPessoas.Where(x => x.CodigoProfissao == (int)ProfissaoEnum.Oficial).FirstOrDefault();
            transporte.VerificarOrdemChegadaAviao(piloto, oficial);
        }

        public void Deve_Permitir_Chefe_Levar_Comissaria_Para_Aviao()
        {
            Pessoa chefe = listaTotalPessoas.Where(x => x.CodigoProfissao == (int)ProfissaoEnum.ChefeServico).FirstOrDefault();
            Pessoa comissaria = listaTotalPessoas.Where(x => x.CodigoProfissao == (int)ProfissaoEnum.Comissaria).FirstOrDefault();
            transporte.VerificarOrdemChegadaAviao(chefe, comissaria);
        }

        public void Deve_Permitir_Policial_Dirigir_Smart_Fortwo_E_Levar_Prisioneiro_Para_Aviao()
        {
            Pessoa policial = listaTotalPessoas.Where(x => x.CodigoProfissao == (int)ProfissaoEnum.Policial).FirstOrDefault();
            Pessoa prisioneiro = listaTotalPessoas.Where(x => x.CodigoProfissao == (int)ProfissaoEnum.Prisioneiro).FirstOrDefault();
            transporte.VerificarOrdemChegadaAviao(policial, prisioneiro);
        }

        public void Deve_Permitir_Todos_Os_Tripulantes_Utilizar_Smart_Fortwo_De_Acordo_Com_A_Regra()
        {
            listaTotalPessoas.Where(x => x.CodigoProfissao == (int)ProfissaoEnum.Policial).Select(x => x.Passe = 2).First();
            listaTotalPessoas.Where(x => x.CodigoProfissao == (int)ProfissaoEnum.ChefeServico).Select(x => x.Passe = 3).First();
            listaTotalPessoas.Where(x => x.CodigoProfissao == (int)ProfissaoEnum.Piloto).Select(x => x.Passe = 4).First();
            listaTotalPessoas.Where(x => x.CodigoProfissao == (int)ProfissaoEnum.Prisioneiro).Select(x => x.Passe = 1).First();
            listaTotalPessoas.Where(x => x.CodigoProfissao == (int)ProfissaoEnum.Comissaria).Select(x => x.Passe = 1).First();
            listaTotalPessoas.Where(x => x.CodigoProfissao == (int)ProfissaoEnum.Oficial).Select(x => x.Passe = 1).First();

            transporte.VerificarOrdemChegadaAviao(listaTotalPessoas);
        }
    }
}
