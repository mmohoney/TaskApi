using System;
using IBatisNet.DataMapper;

namespace DataAccess.Implementations
{
    public abstract class BaseDao : IBaseDao
    {
        public ISqlMapSession Session => DbSqlMapper.SqlMapper.LocalSession;

        public ISqlMapSession StartSession()
        {
            ISqlMapSession session = DbSqlMapper.SqlMapper.OpenConnection();
            session.BeginTransaction();
            return session;
        }

        public void Rollback(bool closeConnection = false)
        {
            if (Session != null && Session.IsTransactionStart)
                Session.RollBackTransaction(closeConnection);
        }

        public void Commit(bool closeConnection = false)
        {
            if (Session != null && Session.IsTransactionStart)
                Session.CommitTransaction(closeConnection);
        }

        public T WrapInSession<T>(Func< T> func, bool commit = true)
        {
            T result;

            if (Session == null)
            {
                using (ISqlMapSession session = StartSession())
                {
                    try
                    {
                        result = func();
                        if (commit)
                            Commit();
                        else
                            Rollback();
                        return result;
                    }
                    catch (Exception e)
                    {
                        Rollback();
                        throw;
                    }
                }
            }

            result = func();
            return result;
        }

        public void WrapInSession(Action action, bool commit = true)
        {
            if (Session == null)
            {
                using (ISqlMapSession session = StartSession())
                {
                    try
                    {
                        action();
                        if (commit)
                            Commit();
                        else
                            Rollback();
                    }
                    catch (Exception e)
                    {
                        Rollback();
                        throw;
                    }
                }
            }
            else
            {
                action();
            }
        }
    }
}
