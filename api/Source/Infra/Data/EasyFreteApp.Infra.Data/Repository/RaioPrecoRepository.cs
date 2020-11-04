using AutoMapper;
using EasyFreteApp.Domain;
using EasyFreteApp.Domain.Repository;
using EasyFreteApp.Domain.Seletores;
using EasyFreteApp.Infra.Data.Entities;
using EasyFreteApp.Infra.Data.Entities.QueryResult;
using EasyFreteApp.Infra.Data.Interface;
using EasyFreteApp.Infra.Data.Repository.Abstract;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyFreteApp.Infra.Data.Repository
{
    public class RaioPrecoRepository : RepositoryBase<RaioPrecoEntity, RaioPrecoDomain, RaioPrecoSeletor>, IRaioPrecoRepository
    {
        public RaioPrecoRepository(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public override IQueryable<RaioPrecoEntity> CreateParameters(RaioPrecoSeletor seletor, IQueryable<RaioPrecoEntity> query)
        {
            if (seletor.IdCentroDistribuicao.HasValue)
                query = query.Where(x => x.IdCentroDistribuicao == seletor.IdCentroDistribuicao.Value);

            return query;
        }

        public IEnumerable<BuscaPrecosDomain> BuscarPrecos(float latitude, float longitude)
        {
            try
            {
                SqlParameter prLat = new SqlParameter
                {
                    ParameterName = "lat",
                    Value = latitude
                };
                SqlParameter prLon = new SqlParameter
                {
                    ParameterName = "lon",
                    Value = longitude
                };

                var query = this._uow.Context.Set<BuscaPrecosEntity>().FromSqlRaw("Exec EasyFrete.buscarPrecos @lat, @lon", prLat, prLon).AsNoTracking().ToList();
                return _mapper.Map<IEnumerable<BuscaPrecosDomain>>(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

