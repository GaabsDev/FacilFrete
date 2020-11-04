using System.Data;

namespace EasyFreteApp.Infra.Data.Interface
{
    public interface IUnitOfWork
    {
        IContext Context { get; }

        bool ExistsTransaction();

        void StartTransaction();

        void StartTransaction(IsolationLevel level);

        void Commit();

        void Rollbak();

        void Clear();
    }
}
