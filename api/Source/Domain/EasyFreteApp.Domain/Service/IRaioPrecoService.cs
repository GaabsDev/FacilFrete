using EasyFreteApp.Domain.Seletores;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyFreteApp.Domain.Service
{
    public interface IRaioPrecoService : IService<RaioPrecoDomain, RaioPrecoSeletor>
    {
        Task<IEnumerable<BuscaPrecosDomain>> BuscarPrecos(string address_text);
    }
}
