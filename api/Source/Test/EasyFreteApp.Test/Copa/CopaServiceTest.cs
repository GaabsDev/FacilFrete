using EasyFreteApp.Application.Service;
using EasyFreteApp.Domain;
using EasyFreteApp.Domain.Repository;
using EasyFreteApp.Domain.Seletores;
using EasyFreteApp.Domain.Service;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EasyFreteApp.Test.EasyFrete
{
    public class EasyFreteServiceTest
    {
    //    private readonly IEasyFreteService _easyFreteService;
    //    private readonly IUsuarioService _equipeService;
    //    private readonly IUsuarioRepository _equipeRepository;

    //    public EasyFreteServiceTest()
    //    {
    //        _equipeRepository = new EquipeRepositotyFake();
    //        _equipeService = new UsuarioService(_equipeRepository);
    //        _easyFreteService = new EasyFreteService(_equipeService);
    //    }

    //    [Fact]
    //    public void Post_processar()
    //    {
    //        var list = _equipeRepository.GetList(new UsuarioSeletor()).Take(8);
    //        var result = _easyFreteService.ProcessarEasyFrete(list);
    //        var resultOk = new List<string>() {"Equipe 2", "Equipe 13"};

    //        Assert.Equal(result.Select(x=> x.Nome), resultOk);
    //    }
  }
}
