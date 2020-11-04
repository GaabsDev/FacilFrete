using EasyFreteApp.Domain.Repository.Abstract;
using EasyFreteApp.Domain.Seletores;
using System.Threading.Tasks;

namespace EasyFreteApp.Domain.Repository
{
    public interface ICepRepository : IRepositorySeletorBase<CepDomain, CepSeletor>
    {
        Task<CepDomain> GetAsync(decimal cep);
        Task InsertAsync(CepDomain cep);
    }
}
