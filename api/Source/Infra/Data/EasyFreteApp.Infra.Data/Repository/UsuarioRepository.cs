using AutoMapper;
using EasyFreteApp.Domain;
using EasyFreteApp.Domain.Repository;
using EasyFreteApp.Domain.Seletores;
using EasyFreteApp.Infra.Data.Entities;
using EasyFreteApp.Infra.Data.Interface;
using EasyFreteApp.Infra.Data.Repository.Abstract;
using System.Linq;

namespace EasyFreteApp.Infra.Data.Repository
{
    public class UsuarioRepository : RepositoryBase<UsuarioEntity, UsuarioDomain, UsuarioSeletor>, IUsuarioRepository
    {
        public UsuarioRepository(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public override IQueryable<UsuarioEntity> CreateParameters(UsuarioSeletor seletor, IQueryable<UsuarioEntity> query)
        {
            if (!string.IsNullOrEmpty(seletor.UserName))
                query = query.Where(x => x.UserName == seletor.UserName);

            return query;
        }
    }
}
