using System.Collections.Generic;
using System.Linq;

namespace EasyFreteApp.Domain.Repository.Abstract
{
    public interface IRepositoryBase<TDomain>
       where TDomain : DomainBase
    {
        int InsertWithReturningId(TDomain obj);

        TDomain InsertWithReturningObject(TDomain obj);

        void Insert(TDomain obj);

        IEnumerable<int> InsertMany(IEnumerable<TDomain> itens);

        IEnumerable<TDomain> InsertManyReturningObject(IEnumerable<TDomain> itens);

        void Update(TDomain obj);

        void UpdateMany(IEnumerable<TDomain> itens);

        void Delete(TDomain obj);

        void DeleteMany(IEnumerable<TDomain> items);

        IQueryable<TDomain> Get();

        TDomain GetById(long id);

        IEnumerable<TDomain> GetByIds(params long[] id);

        void Save();
    }
}
