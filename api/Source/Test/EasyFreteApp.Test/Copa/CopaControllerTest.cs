using EasyFreteApp.Application.Service;
using EasyFreteApp.Domain.Repository;
using EasyFreteApp.Domain.Seletores;
using EasyFreteApp.Domain.Service;
using EasyFreteApp.Presentation.UI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Xunit;

namespace EasyFreteApp.Test.EasyFrete
{
    public class EasyFreteControllerTest
    {
        //private readonly EasyFreteController _controller;
        //private readonly IEasyFreteService _easyFreteService;
        //private readonly IUsuarioService _equipeService;
        //private readonly IUsuarioRepository _equipeRepository;

        //public EasyFreteControllerTest()
        //{
        //    _equipeRepository = new EquipeRepositotyFake();
        //    _equipeService = new UsuarioService(_equipeRepository);
        //    _easyFreteService = new EasyFreteService(_equipeService);
        //    _controller = new EasyFreteController(_easyFreteService);
        //}

        //[Fact]
        //public void Post_processar()
        //{
        //    var list = _equipeRepository.GetList(new UsuarioSeletor()).Take(8);
        //    var okResult = _controller.Processar(list);
           
        //    Assert.IsType<OkObjectResult>(okResult);
        //}
    }
}
