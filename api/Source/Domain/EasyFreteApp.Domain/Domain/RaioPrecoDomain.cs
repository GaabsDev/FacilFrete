namespace EasyFreteApp.Domain
{
    public class RaioPrecoDomain : DomainBase
    {
        public int IdCentroDistribuicao { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal Raio { get; set; }
        public decimal Preco { get; set; }
        public CentroDistribuicaoDomain CentroDistribuicao { get; set; }
    }
}
