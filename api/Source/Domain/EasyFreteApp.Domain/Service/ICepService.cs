using System.Threading.Tasks;

namespace EasyFreteApp.Domain.Service
{
    public interface ICepService
    {
       Task<CepDomain> GetAsync(string cep);
    }
}
