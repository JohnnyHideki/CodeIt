using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeItAirLine
{
    class Program
    {
        static void Main(string[] args)
        {
            TransporteTest teste = new TransporteTest();

            teste.Nao_Deve_Permitir_Prisioneiro_Acompanhar_Outro_Tripulante_Alem_De_Policial();
            teste.Nao_Deve_Permitir_Comissaria_Acompanhar_Outro_Tripulante_Alem_De_Chefe_De_Servico();
            teste.Nao_Deve_Permitir_Oficial_Acompanhar_Outro_Tripulante_Alem_De_Piloto_De_Cabine();
            teste.Nao_Deve_Permitir_Oficial_Dirigir_Smart_Fortwo();
            teste.Nao_Deve_Permitir_Comissaria_Dirigir_Smart_Fortwo();
            teste.Nao_Deve_Permitir_Oficial_E_Comissaria_Dirigir_Smart_Fortwo();
           
            teste.Deve_Permitir_Piloto_Levar_Oficial_Para_Aviao();
            teste.Deve_Permitir_Chefe_Levar_Comissaria_Para_Aviao();
            teste.Deve_Permitir_Policial_Dirigir_Smart_Fortwo_E_Levar_Prisioneiro_Para_Aviao();

            teste.Deve_Permitir_Todos_Os_Tripulantes_Utilizar_Smart_Fortwo_De_Acordo_Com_A_Regra();
        }
    }                  
}
