using System;
using System.Data.SqlClient;
using DataAccess.Implementations;
using DataAccess.Implementations.Users;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Exceptions;
using NUnit.Framework;

namespace DataAccess.Test
{
    [TestFixture]
    public class BaseDaoTest
    {
        private void AssertSessionTransactionStart(IBaseDao dao)
        {
            Assert.IsNotNull(dao.Session);
            Assert.IsTrue(dao.Session.IsTransactionStart);
        }

        private void AssertSessionTransactionClosed(IBaseDao dao)
        {
            Assert.IsNotNull(dao.Session);
            Assert.IsFalse(dao.Session.IsTransactionStart);
        }

        [Test]
        public void Session()
        {
            var dao = new UserDao();
            Assert.IsNull(dao.Session);

            using (ISqlMapSession session = dao.StartSession())
            {
                AssertSessionTransactionStart(dao);
            }
        }

        [Test]
        public void TransactionStart_TransactionStartInTransaction()
        {
            Assert.Throws<DataMapperException>(() =>
            {
                var dao = new UserDao();
                Assert.IsNull(dao.Session);

                using (ISqlMapSession session = dao.StartSession())
                {
                    AssertSessionTransactionStart(dao);

                    using (ISqlMapSession session2 = dao.StartSession())
                    {
                        AssertSessionTransactionStart(dao);
                    }
                }
            });
        }

        [Test]
        public void Rollback()
        {
            var dao = new UserDao();
            Assert.IsNull(dao.Session);

            using (ISqlMapSession session = dao.StartSession())
            {
                AssertSessionTransactionStart(dao);

                dao.Rollback();

                AssertSessionTransactionClosed(dao);
            }
        }

        [Test]
        public void Commit()
        {
            var dao = new UserDao();
            Assert.IsNull(dao.Session);

            using (ISqlMapSession session = dao.StartSession())
            {
                AssertSessionTransactionStart(dao);

                dao.Commit();

                AssertSessionTransactionClosed(dao);
            }
        }

        [Test]
        public void FuncWrapInSession()
        {
            var dao = new UserDao();
            Assert.IsNull(dao.Session);

            var test = dao.WrapInSession(() =>
            {
                AssertSessionTransactionStart(dao);
                return 1;
            });
            Assert.IsNull(dao.Session);
        }

        [Test]
        public void FuncWrapInSession_NLayer()
        {
            var dao = new UserDao();
            Assert.IsNull(dao.Session);

            Guid outerId = new Guid(), innerId = new Guid();

            var testOuter = dao.WrapInSession(() =>
            {
                var connectionOuter = (SqlConnection)dao.Session.Connection;
                outerId = connectionOuter.ClientConnectionId;

                var testInner = dao.WrapInSession(() =>
                {
                    AssertSessionTransactionStart(dao);

                    var connectionInner = (SqlConnection)dao.Session.Connection;
                    innerId = connectionInner.ClientConnectionId;

                    return 1;
                });

                AssertSessionTransactionStart(dao);
                return 1;
            });

            Assert.IsFalse(outerId == new Guid());
            Assert.IsFalse(innerId == new Guid());
            Assert.IsTrue(outerId == innerId);
            Assert.IsNull(dao.Session);
        }

        [Test]
        public void ActionWrapInSession()
        {
            var dao = new UserDao();
            Assert.IsNull(dao.Session);

            dao.WrapInSession(() =>
            {
                AssertSessionTransactionStart(dao);
            });

            Assert.IsNull(dao.Session);
        }

        [Test]
        public void ActionWrapInSession_NLayer()
        {
            var dao = new UserDao();
            Assert.IsNull(dao.Session);

            Guid outerId = new Guid(), innerId = new Guid();

            dao.WrapInSession(() =>
            {
                var connectionOuter = (SqlConnection)dao.Session.Connection;
                outerId = connectionOuter.ClientConnectionId;

                dao.WrapInSession(() =>
                {
                    AssertSessionTransactionStart(dao);

                    var connectionInner = (SqlConnection)dao.Session.Connection;
                    innerId = connectionInner.ClientConnectionId;
                });

                AssertSessionTransactionStart(dao);
            });

            Assert.IsFalse(outerId == new Guid());
            Assert.IsFalse(innerId == new Guid());
            Assert.IsTrue(outerId == innerId);
            Assert.IsNull(dao.Session);
        }
    }
}
