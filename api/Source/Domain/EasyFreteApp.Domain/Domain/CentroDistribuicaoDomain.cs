namespace EasyFreteApp.Domain
{
    public class CentroDistribuicaoDomain : DomainBase
    {
        public int IdEmpresa { get; set; }
        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public virtual EmpresaDomain Empresa { get; set; }
    }
}
