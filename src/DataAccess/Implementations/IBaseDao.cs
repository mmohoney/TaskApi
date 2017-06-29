using System;
using IBatisNet.DataMapper;

namespace DataAccess.Implementations
{
    public interface IBaseDao
    {
        ISqlMapSession Session { get; }

        ISqlMapSession StartSession();
        void Rollback(bool closeConnection = false);
        void Commit(bool closeConnection = false);
        void WrapInSession(Action action, bool commit = true);
        T WrapInSession<T>(Func<T> func, bool commit = true);
    }
}