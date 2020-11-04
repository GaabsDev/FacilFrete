using EasyFreteApp.Domain.Seletores;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyFreteApp.Domain.Repository.Abstract
{
    public interface IRepositorySeletorBase<TDomain, TSeletor> : IRepositoryBase<TDomain>
        where TSeletor : SeletorBase
        where TDomain : DomainBase
    {
        IEnumerable<TDomain> GetList(TSeletor seletor);
        int Count(TSeletor seletor);
    }
}
