using System;

namespace EasyFreteApp.Domain
{
    public class CepDomain : DomainBase
    {
        public decimal Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public DateTime DataInclusao { get; set; }
    }
}
