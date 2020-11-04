using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyFreteApp.Infra.Data.Entities
{
    [Table("Empresa", Schema = "EasyFrete")]
    public class EmpresaEntity : EntityBase
    {
        public string Nome { get; set; }
        public string Email { get; set; } 
        public string NomeResponsavel { get; set; }
        public string TelefoneResponsavel { get; set; }
        public virtual ICollection<UsuarioEntity> Usuarios { get; set; }
        public virtual ICollection<CentroDistribuicaoEntity> CentrosDistribuicao { get; set; }
    }
}
