using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyFreteApp.Infra.Data.Entities
{
    [Table("Cep", Schema = "EasyFrete")]
    public class CepEntity : EntityBase
    {
        public decimal Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public DateTime DataInclusao { get; set; }
    }
}
