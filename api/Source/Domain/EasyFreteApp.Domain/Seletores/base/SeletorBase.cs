namespace EasyFreteApp.Domain.Seletores
{
    public abstract class SeletorBase : ISeletor
    {
        public SeletorBase()
        {
            this.Id = -1;
            this.OrderBy = "Id";
            this.Pagina = 1;
            this.RegistroPorPagina = 10;
        }

        public int Id { get; set; }

        public int Pagina { get; set; }

        public int RegistroPorPagina { get; set; }

        public string OrderBy { get; set; }

        public string Coringa { get; set; }

        public bool IsSelectedAll { get; set; }
    }
}
