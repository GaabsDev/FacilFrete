using EasyFreteApp.Application.Service.Abstract;
using EasyFreteApp.Application.Service.Validators;
using EasyFreteApp.Domain;
using EasyFreteApp.Domain.Repository;
using EasyFreteApp.Domain.Seletores;
using EasyFreteApp.Domain.Service;
using System;
using System.Linq;

namespace EasyFreteApp.Application.Service
{
    public class UsuarioService : ServiceBase<IUsuarioRepository, UsuarioDomain, UsuarioSeletor>, IUsuarioService
    {
        public UsuarioService(IUsuarioRepository repository) : base(repository) { }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public override UsuarioDomain Update(UsuarioDomain domain)
        {
            throw new System.NotImplementedException();
        }

        public override UsuarioDomain Insert(UsuarioDomain domain)
        {
           UsuarioValidator.UsuarioIsValid(domain);
           return base.Insert(domain);
        }
    }
}
