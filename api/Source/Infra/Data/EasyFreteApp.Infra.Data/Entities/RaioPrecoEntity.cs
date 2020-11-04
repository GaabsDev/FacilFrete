using System.ComponentModel.DataAnnotations.Schema;

namespace EasyFreteApp.Infra.Data.Entities
{
    [Table("RaioPreco", Schema = "EasyFrete")]
    public class RaioPrecoEntity : EntityBase
    {
        public int IdCentroDistribuicao { get; set; }
	    public decimal Latitude { get; set; }
	    public decimal Longitude { get; set; }
        public decimal Raio { get; set; }
        public decimal Preco { get; set; }

        [ForeignKey("IdCentroDistribuicao")]
        public virtual CentroDistribuicaoEntity CentroDistribuicao { get; set; }
    }
}
