using System;
using System.Collections.Generic;
using System.Text;

namespace EasyFreteApp.Domain
{
    public class BuscaPrecosDomain
    {
        public decimal Distancia { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public int IdCentroDistribuicao { get; set; }
    }
}
