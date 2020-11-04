namespace EasyFreteApp.Domain.Seletores
{
    public class UsuarioSeletor : SeletorBase
    {
        public int IdEmpresa { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
