using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyFreteApp.Infra.Data.Entities
{
    [Table("Usuario", Schema = "EasyFrete")]
    public class UsuarioEntity : EntityBase
    {
        public int IdEmpresa { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        [ForeignKey("IdEmpresa")]
        public virtual EmpresaEntity Empresa { get; set; }
    }
}
