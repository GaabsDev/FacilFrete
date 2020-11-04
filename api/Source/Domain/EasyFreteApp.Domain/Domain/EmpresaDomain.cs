using System;

namespace EasyFreteApp.Domain
{
    public class EmpresaDomain : DomainBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string NomeResponsavel { get; set; }
        public string TelefoneResponsavel { get; set; }
    }
}
