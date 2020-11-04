namespace EasyFreteApp.Domain.Domain.Json
{
    public class CepJsonDomain
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
        public bool Erro { get; set; }
    }
}
