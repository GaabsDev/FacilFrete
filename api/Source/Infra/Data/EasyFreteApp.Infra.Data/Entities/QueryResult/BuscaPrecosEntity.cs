namespace EasyFreteApp.Infra.Data.Entities.QueryResult
{
    public class BuscaPrecosEntity
    {
        public decimal Distancia { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public int IdCentroDistribuicao { get; set; }
    }
}
