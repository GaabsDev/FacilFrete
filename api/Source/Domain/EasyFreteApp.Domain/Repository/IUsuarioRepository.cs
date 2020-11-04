using EasyFreteApp.Domain.Repository.Abstract;
using EasyFreteApp.Domain.Seletores;

namespace EasyFreteApp.Domain.Repository
{
    public interface IUsuarioRepository : IRepositorySeletorBase<UsuarioDomain, UsuarioSeletor>
    {
    }
}
