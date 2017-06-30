using System;
using DataAccess.Implementations.Users;
using DataTransfer.Users;
using NUnit.Framework;

namespace DataAccess.Test
{
    [TestFixture]
    public class UserDaoTests
    {
        private readonly Random _random = new Random();

        private UserDto GetNewUser()
        {
            return new UserDto
            {
                Username = $"jdoe_{_random.Next()}",
                FirstName = "John",
                MiddleName = "Frank",
                LastName = "Doe",
                Email = $"jdoe@gmail.com_{_random.Next()}",
            };
        }

        [Test]
        public void CreateUser_GetUserById()
        {
            var dao = new UserDao();
            var userDto = GetNewUser();

            dao.WrapInSession(() =>
            {
                Assert.IsTrue(userDto.Id == 0);

                dao.CreateUser(userDto);

                Assert.IsTrue(userDto.Id > 0);

                var dbUserDto = dao.GetUserById(userDto.Id);
                Assert.IsNotNull(dbUserDto);
                Assert.AreEqual(userDto.Id, dbUserDto.Id);
            }, false);

            var dbUserDto2 = dao.GetUserById(userDto.Id);
            Assert.IsNull(dbUserDto2);
        }

        [Test]
        public void CreateUsers_GetAllUsers()
        {
            var dao = new UserDao();
            var userDto1 = GetNewUser();
            var userDto2 = GetNewUser();

            dao.WrapInSession(() =>
            {
                Assert.IsTrue(userDto1.Id == 0);
                dao.CreateUser(userDto1);
                Assert.IsTrue(userDto1.Id > 0);

                Assert.IsTrue(userDto2.Id == 0);
                dao.CreateUser(userDto2);
                Assert.IsTrue(userDto2.Id > 0);

                var dbUserDto1 = dao.GetUserById(userDto1.Id);
                Assert.IsNotNull(dbUserDto1);
                Assert.AreEqual(userDto1.Id, dbUserDto1.Id);

                var dbUserDto2 = dao.GetUserById(userDto2.Id);
                Assert.IsNotNull(dbUserDto2);
                Assert.AreEqual(userDto2.Id, dbUserDto2.Id);

                var users = dao.GetAllUsers();
                Assert.IsTrue(users.Count >= 2);
                Assert.IsNotNull(users.Find(u => u.Id == userDto1.Id));
                Assert.IsNotNull(users.Find(u => u.Id == userDto2.Id));
            }, false);

            var dbUserDto3 = dao.GetUserById(userDto1.Id);
            Assert.IsNull(dbUserDto3);

            var dbUserDto4 = dao.GetUserById(userDto2.Id);
            Assert.IsNull(dbUserDto4);
        }

        #region Populate User In Db
        [Test, Ignore("Populate DB")]
        public void CreateUser()
        {
            var dao = new UserDao();
            var userDto = new UserDto
            {
                Username = $"jdoe_{_random.Next()}",
                FirstName = "John",
                MiddleName = "Frank",
                LastName = "Doe",
                Email = $"jdoe@gmail.com_{_random.Next()}",
            };

            dao.WrapInSession(() =>
            {
                dao.CreateUser(userDto);
                Assert.IsTrue(userDto.Id > 0);

                var dbUserDto = dao.GetUserById(userDto.Id);
                Assert.IsNotNull(dbUserDto);
                Assert.AreEqual(userDto.Id, dbUserDto.Id);
            });
            var dbUserDto2 = dao.GetUserById(userDto.Id);
            Assert.IsNotNull(dbUserDto2);
        }
        #endregion
    }
}
