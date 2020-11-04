using EasyFreteApp.Infra.Data.Entities;
using EasyFreteApp.Infra.Data.Entities.QueryResult;
using EasyFreteApp.Infra.Data.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EasyFreteApp.Infra.Data
{
    public class Context : DbContext, IContext
    {
        public Context(DbContextOptions<Context> options)
        : base(options)
        {

        }

        public virtual DbSet<CepEntity> Cep { get; set; }
        public virtual DbSet<EmpresaEntity> Empresa { get; set; }
        public virtual DbSet<UsuarioEntity> Usuario { get; set; }
        public virtual DbSet<CentroDistribuicaoEntity> CentroDistribuicao { get; set; }
        public virtual DbSet<RaioPrecoEntity> RaioPreco { get; set; }
        public virtual DbSet<BuscaPrecosEntity> BuscaPrecos { get; set; }
        
        public virtual DbContext DbContext => this;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BuscaPrecosEntity>().HasKey(c => c.Codigo);

            modelBuilder.Entity<CepEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Cep).IsUnique();
            });

            modelBuilder.Entity<EmpresaEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Nome).IsUnique();
            });

            modelBuilder.Entity<UsuarioEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.UserName).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
            });

            modelBuilder.Entity<CepEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Cep).IsUnique();
            });

            modelBuilder.Entity<CentroDistribuicaoEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

        }

        public void Clear()
        {
            var changedEntries = ChangeTracker.Entries()
                .Where(e => e.State != EntityState.Detached)
                .ToList();

            foreach (var entry in changedEntries)
                Entry(entry.Entity).State = EntityState.Detached;
        }
    }
}
