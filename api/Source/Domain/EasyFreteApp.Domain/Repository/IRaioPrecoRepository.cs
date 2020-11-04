using EasyFreteApp.Domain.Repository.Abstract;
using EasyFreteApp.Domain.Seletores;
using System.Collections.Generic;

namespace EasyFreteApp.Domain.Repository
{
    public interface IRaioPrecoRepository : IRepositorySeletorBase<RaioPrecoDomain, RaioPrecoSeletor>
    {
        IEnumerable<BuscaPrecosDomain> BuscarPrecos(float latitude, float longitude);
    }
}
