using DataAccess.Implementations.CheckLists;
using IBatisNet.DataMapper;
using NUnit.Framework;

namespace DataAccess.Test
{
    [TestFixture]
    public class DataAccessTest
    {
        [Test]
        public void SqlMapSetup()
        {
            var test = DbSqlMapper.SqlMapper;
            Assert.IsNotNull(test);
        }

        [Test]
        public void GetAllUsers()
        {
            var dao = new CheckListDao();
            var result = dao.GetAllUsers();
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetAllCheckListsForUser()
        {
            var dao = new CheckListDao();
            var result = dao.GetAllCheckListsForUser(1);
            Assert.IsNotNull(result);
        }
    }
}
