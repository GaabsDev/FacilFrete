using System.ComponentModel.DataAnnotations.Schema;

namespace EasyFreteApp.Infra.Data.Entities
{
    [Table("CentroDistribuicao", Schema = "EasyFrete")]
    public class CentroDistribuicaoEntity : EntityBase
    {
        public int IdEmpresa { get; set; }
        public string Descricao { get; set; }
	    public string Codigo { get; set; }
	    public decimal Latitude { get; set; }
	    public decimal Longitude { get; set; }

        [ForeignKey("IdEmpresa")]
        public virtual EmpresaEntity Empresa { get; set; }
    }
}
