using EasyFreteApp.Infra.Data.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace EasyFreteApp.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IContext Context;

        private IDbContextTransaction Transaction;

        IContext IUnitOfWork.Context
                => Context;

        public UnitOfWork(IContext context)
            => Context = context;

        public bool ExistsTransaction()
            => this.Transaction != null;

        public void StartTransaction()
        {
            if (!ExistsTransaction())
                Transaction = Context.Database.BeginTransaction();
        }

        public void StartTransaction(IsolationLevel level)
        {
            if (!ExistsTransaction())
                Transaction = Context.Database.BeginTransaction(level);
        }

        public void Commit()
        {
            if (!ExistsTransaction())
                return;

            Transaction.Commit();
            Transaction.Dispose();
            Transaction = null;
        }

        public void Rollbak()
        {
            if (!ExistsTransaction())
                return;

            Transaction.Rollback();
            Transaction.Dispose();
            Transaction = null;
        }

        public void Clear()
            => Context.Clear();
    }
}
