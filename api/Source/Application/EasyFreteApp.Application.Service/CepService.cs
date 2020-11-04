using AutoMapper;
using EasyFreteApp.Application.Service.Client;
using EasyFreteApp.Application.Service.Validators;
using EasyFreteApp.Domain;
using EasyFreteApp.Domain.Domain.Json;
using EasyFreteApp.Domain.Repository;
using EasyFreteApp.Domain.Service;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace EasyFreteApp.Application.Service
{
    public class CepService : ICepService
    {
        private static readonly string SERVICE_CEP = Environment.GetEnvironmentVariable("SERVICE_CEP");
        private readonly ICepRepository _repository;
        private IMapper _mapper;

        public CepService
        (ICepRepository repository,
         IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CepDomain> GetAsync(string cep)
        {
            decimal cepValido = cep.CepValid();

            var cepRetorno = await _repository.GetAsync(cepValido);

            if (cepRetorno != null) return cepRetorno;

            cepRetorno = await GetCepBuscaCep(cepValido);

            if (cepRetorno == null)
               throw new Exception("Cep não encontrado");

            await _repository.InsertAsync(cepRetorno);

            return cepRetorno;
        }

        private async Task<CepDomain> GetCepBuscaCep(decimal cep)
        {
            string jsonRetorno = await Http.Get(string.Format(SERVICE_CEP, cep));

            var cepJson = JsonConvert.DeserializeObject<CepJsonDomain>(jsonRetorno);

            return _mapper.Map<CepDomain>(cepJson);
        }
    }
}
