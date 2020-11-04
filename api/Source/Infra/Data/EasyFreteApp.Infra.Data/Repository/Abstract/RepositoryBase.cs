using AutoMapper;
using EasyFreteApp.Domain;
using EasyFreteApp.Domain.Repository.Abstract;
using EasyFreteApp.Domain.Seletores;
using EasyFreteApp.Infra.Data.Entities;
using EasyFreteApp.Infra.Data.Interface;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace EasyFreteApp.Infra.Data.Repository.Abstract
{
    public abstract class RepositoryBase<TEntity, TDomain, TSeletor> : IRepositoryBase<TDomain>
    where TEntity : EntityBase
    where TDomain : DomainBase
    where TSeletor : SeletorBase
    {
        /// <summary>
        /// A instance database
        /// </summary>
        protected IContext _context;
        protected IUnitOfWork _uow;
        protected IMapper _mapper;

        protected RepositoryBase(IUnitOfWork uow, IMapper mapper)
        {
            _context = uow.Context;
            this._uow = uow;
            _mapper = mapper;
        }

        /// <summary>
        /// Method for Insert
        /// </summary>
        /// <param name="obj"></param>
        public virtual void Insert(TDomain obj)
        {
            TEntity entity = MapperToEntity(obj);
            _context.Set<TEntity>().Add(entity);
            this.Save();
        }

        public virtual TDomain InsertWithReturningObject(TDomain obj)
        {
            TEntity entity = MapperToEntity(obj);
            _context.Set<TEntity>().Add(entity);
            this.Save();
            return MapperToDomain(entity);
        }

        public virtual int InsertWithReturningId(TDomain obj)
        {
            TEntity entity = MapperToEntity(obj);
            _context.Set<TEntity>().Add(entity);
            this.Save();
            return entity.Id;
        }


        public virtual IEnumerable<int> InsertMany(IEnumerable<TDomain> items)
        {
            var insertedList = new List<TEntity>();
            foreach (var item in items)
            {
                var entity = MapperToEntity(item);
                insertedList.Add(entity);
                _context.Set<TEntity>().Add(entity);
            }
            Save();
            return insertedList.Select(x => x.Id);
        }

        public virtual IEnumerable<TDomain> InsertManyReturningObject(IEnumerable<TDomain> items)
        {
            var insertedList = new List<TEntity>();
            foreach (var item in items)
            {
                var entity = MapperToEntity(item);
                insertedList.Add(entity);
                _context.Set<TEntity>().Add(entity);
            }
            Save();

            return insertedList.Select(x => MapperToDomain(x));
        }

        /// <summary>
        /// Method for update
        /// </summary>
        /// <param name="obj"></param>
        public virtual void Update(TDomain obj)
        {
            _uow.StartTransaction();
            TEntity entity = MapperToEntity(obj);

            DetachLocal(obj);

            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public virtual void UpdateMany(IEnumerable<TDomain> itens)
        {
            _uow.StartTransaction();
            foreach (var obj in itens)
            {
                TEntity entity = MapperToEntity(obj);

                var local = _context.Set<TEntity>()
                    .Local
                    .FirstOrDefault(entry => entry.Id.Equals(entity.Id));

                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }

                _context.Entry(entity).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }

        public virtual TEntity UpdateWithReturningObject(TEntity obj)
        {
            var entry = _context.Entry(obj);
            _context.Set<TEntity>().Attach(obj);
            entry.State = EntityState.Modified;

            return obj;
        }

        /// <summary>
        /// Method for delete
        /// </summary>
        /// <param name="obj"></param>
        public virtual void Delete(TDomain obj)
        {
            TEntity entity = MapperToEntity(obj);
            _context.Entry(entity).State = EntityState.Deleted;
            this.Save();
        }

        public virtual void DeleteMany(IEnumerable<TDomain> items)
        {
            foreach (var item in items)
            {
                var entity = MapperToEntity(item);
                _context.Entry(entity).State = EntityState.Deleted;
            }
            this.Save();
        }

        /// <summary>
        /// Return a list of entity
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<TDomain> Get()
        {
            var query = _context.Set<TEntity>()
                .Select(x => MapperToDomain(x))
                .AsQueryable();

            return query;
        }

        /// <summary>
        /// Return a entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TDomain GetById(long id)
        {
            var query = CreateQuery().FirstOrDefault(x => x.Id == id);

            return MapperToDomain(query);
        }

        /// <summary>
        /// Return a lits of entity by Ids
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual IEnumerable<TDomain> GetByIds(params long[] ids)
        {
            var query = CreateQuery().Where(x => ids.Contains(x.Id));

            return MapperToDomain(query);
        }

        /// <summary>
        /// Verify if exist objects
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        protected virtual bool Exist(Expression<Func<TEntity, bool>> expression)
        {
            var query = _context.Set<TEntity>()
                .Where(expression)
                .Count();

            if (query > 0)
                return true;

            return false;
        }

        public void InsertOrUpdateBulk(List<TEntity> insertedList, BulkConfig bulkConfig)
        {
            _context.DbContext.BulkInsertOrUpdate(insertedList, bulkConfig);
        }

        /// <summary>
        /// Save actions
        /// </summary>
        public void Save()
        {
            _uow.StartTransaction();
            _context.SaveChanges();
        }

        protected virtual TEntity MapperToEntity(object dto)
            => MapperToEntity<TEntity>(dto);

        protected virtual T MapperToEntity<T>(object dto) where T : EntityBase
        {
            T entity = (T)Activator.CreateInstance(typeof(T));
            Type entityTypes = entity.GetType();

            PropertyInfo[] propertyInfo = dto.GetType().GetProperties();
            foreach (PropertyInfo property in propertyInfo)
            {
                var value = property.GetValue(dto, null);
                var objectProperty = entityTypes.GetProperty(property.Name);

                if (objectProperty != null && objectProperty.PropertyType == property.PropertyType)
                {
                    objectProperty.SetValue(entity, value);
                }
            }

            return entity;
        }

        protected virtual TDomain MapperToDomain(TEntity entity)
        {
            return this._mapper.Map<TDomain>(entity);
        }

        protected virtual IEnumerable<TDomain> MapperToDomain(IEnumerable<TEntity> entity)
        {
            return _mapper.Map<IEnumerable<TDomain>>(entity);
        }

        public IQueryable<TEntity> CreateGrouped(IQueryable<TEntity> query, Expression<Func<TEntity, object>> expression)
        {
            return query.GroupBy(expression).Select(x => x.FirstOrDefault());
        }

        public IQueryable<TEntity> CreateLimit(SeletorBase seletor, IQueryable<TEntity> query)
        {
            if (seletor.IsSelectedAll)
                return query;

            if (seletor.Pagina < 0)
                seletor.Pagina = 1;

            int skip = ((seletor.Pagina - 1) * seletor.RegistroPorPagina);
            int take = seletor.RegistroPorPagina;

            return query.Skip(skip).Take(take).AsQueryable();
        }

        public virtual IEnumerable<TDomain> GetList(TSeletor seletor)
        {
            IQueryable<TEntity> query = this.CreateQuery();

            query = this.CreateParameters(seletor, query);
            query = this.CreateLimit(seletor, query);

            var list = query.ToList();
            return _mapper.Map<IEnumerable<TDomain>>(list);
        }

        public virtual IEnumerable<TDomain> GetListWithInclude(TSeletor seletor, params string[] includes)
        {
            IQueryable<TEntity> query = this._context.Set<TEntity>().AsNoTracking();

            query = CreateIncludes(query, includes);

            query = this.CreateParameters(seletor, query);
            query = this.CreateLimit(seletor, query);

            var list = query.ToList();
            return _mapper.Map<IEnumerable<TDomain>>(list);
        }

        public virtual decimal? SumList(TSeletor seletor, Expression<Func<TDomain, decimal?>> filter)
        {
            IQueryable<TEntity> query = this._context.Set<TEntity>().AsNoTracking();

            query = this.CreateParameters(seletor, query);

            Expression<Func<TEntity, decimal?>> funcEntity = MapExpression(filter);

            return query.Sum(funcEntity);
        }

        static Expression<Func<TEntity, decimal?>> MapExpression(Expression<Func<TDomain, decimal?>> domain)
        {
            ParameterExpression objectParam = Expression.Parameter(typeof(TEntity), "x");

            Expression memberAccess = Expression.PropertyOrField(objectParam, ((MemberExpression)domain.Body).Member.Name);

            return Expression.Lambda<Func<TEntity, decimal?>>(memberAccess, objectParam);
        }

        private IQueryable<TEntity> CreateIncludes(IQueryable<TEntity> query, string[] includes)
        {
            if (includes != null && includes.Length > 0)
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }

        public IQueryable<TEntity> CreateIncludes(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includes)
        {
            if (includes != null && includes.Length > 0)
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }

        public abstract IQueryable<TEntity> CreateParameters(TSeletor seletor, IQueryable<TEntity> query);

        public virtual IQueryable<TEntity> CreateQuery()
        {
            return this._context.Set<TEntity>().AsNoTracking();
        }

        public int Count(TSeletor seletor)
        {
            var query = CreateQuery();
            query = CreateParameters(seletor, query);

            return query.Count();
        }

        protected void DetachLocal(TDomain obj)
        {
            var exists = _context.Set<TEntity>().Local.Any(x => x.Id == obj.Id);
            if (exists)
                _context.Set<TEntity>().Local.Where(x => x.Id == obj.Id).ToList().ForEach(p => _context.Entry(p).State = EntityState.Detached);
        }

    }
}
