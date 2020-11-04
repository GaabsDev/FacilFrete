namespace EasyFreteApp.Domain
{
    public class UsuarioDomain : DomainBase
    {
        public int IdEmpresa { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public EmpresaDomain Empresa { get; set; }
    }
}
