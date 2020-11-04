using EasyFreteApp.Application.Service.Abstract;
using EasyFreteApp.Domain;
using EasyFreteApp.Domain.Repository;
using EasyFreteApp.Domain.Seletores;
using EasyFreteApp.Domain.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyFreteApp.Application.Service
{
    public class RaioPrecoService : ServiceBase<IRaioPrecoRepository, RaioPrecoDomain, RaioPrecoSeletor>, IRaioPrecoService
    {
        private readonly IGeospatialService _geospatialService;
        public RaioPrecoService(IRaioPrecoRepository repository, IGeospatialService geospatialService) : base(repository)
        {
            this._geospatialService = geospatialService;
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public override RaioPrecoDomain Update(RaioPrecoDomain domain)
        {
            throw new System.NotImplementedException();
        }

        public override RaioPrecoDomain Insert(RaioPrecoDomain domain)
        {
            //chamar validation
            return base.Insert(domain);
        }

        public async Task<IEnumerable<BuscaPrecosDomain>> BuscarPrecos(string address_text)
        {
            var coords = await this._geospatialService.Geocode(address_text);
            return this._repository.BuscarPrecos(coords.Latitude, coords.Longitude);
        }
    }
}
