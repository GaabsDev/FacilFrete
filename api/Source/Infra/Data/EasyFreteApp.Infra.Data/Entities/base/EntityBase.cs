using System.ComponentModel.DataAnnotations;

namespace EasyFreteApp.Infra.Data.Entities
{
    public class EntityBase
    {
       [Key]
       public int Id { get; set; }
       public bool Ativo { get; set; }
    }
}
