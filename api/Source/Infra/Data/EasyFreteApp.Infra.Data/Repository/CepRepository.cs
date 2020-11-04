using AutoMapper;
using EasyFreteApp.Domain;
using EasyFreteApp.Domain.Repository;
using EasyFreteApp.Domain.Seletores;
using EasyFreteApp.Infra.Data.Entities;
using EasyFreteApp.Infra.Data.Interface;
using EasyFreteApp.Infra.Data.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EasyFreteApp.Infra.Data.Repository
{
    public class CepRepository : RepositoryBase<CepEntity, CepDomain, CepSeletor>, ICepRepository
    {
        public CepRepository(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public override IQueryable<CepEntity> CreateParameters(CepSeletor seletor, IQueryable<CepEntity> query)
        {
            if (seletor.Cep.HasValue)
                query = query.Where(x => x.Cep == seletor.Cep.Value);

            return query;
        }

        public async Task<CepDomain> GetAsync(decimal cep)
        {
            _uow.StartTransaction(IsolationLevel.ReadUncommitted);
            var cepEntity = await _context.Cep.FirstOrDefaultAsync(x=> x.Cep == cep);

            if (cepEntity != null)
                 return _mapper.Map<CepDomain>(cepEntity);

            return null;
        }

        public async Task InsertAsync(CepDomain cep)
        {
            var entity = _mapper.Map<CepEntity>(cep);

            await _context.Cep.AddAsync(entity);

            _uow.StartTransaction();
            await _context.SaveChangesAsync();
        }
    }
}
