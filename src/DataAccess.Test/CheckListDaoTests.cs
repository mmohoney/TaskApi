using System;
using DataAccess.Implementations.CheckLists;
using DataAccess.Implementations.Users;
using DataTransfer.CheckLists;
using DataTransfer.Users;
using IBatisNet.DataMapper;
using NUnit.Framework;

namespace DataAccess.Test
{
    [TestFixture]
    public class CheckListDaoTests
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

        private CheckListDto GetNewCheckList(int userId)
        {
            return new CheckListDto
            {
                UserId = userId,
                Description = "My List",
                Active = true,
            };
        }

        [Test]
        public void CreateCheckList_GetAllCheckListsByUserId()
        {
            var userDao = new UserDao();
            var checkListDao = new CheckListDao();
            var userDto = GetNewUser();

            CheckListDto checkListDto = null;
            userDao.WrapInSession(() =>
            {
                Assert.IsTrue(userDto.Id == 0);
                userDao.CreateUser(userDto);
                Assert.IsTrue(userDto.Id > 0);

                checkListDto = GetNewCheckList(userDto.Id);
                Assert.IsTrue(checkListDto.Id == 0);
                checkListDao.CreateCheckList(checkListDto);
                Assert.IsTrue(checkListDto.Id > 0);

                var dbCheckListDtos = checkListDao.GetAllCheckListsForUserId(checkListDto.UserId);
                Assert.IsNotEmpty(dbCheckListDtos);
                Assert.IsNotNull(dbCheckListDtos.Find(d => d.Id == checkListDto.Id));
            }, false);
        }

        [Test]
        public void CreateCheckList_GetCheckListById()
        {
            var userDao = new UserDao();
            var checkListDao = new CheckListDao();
            var userDto = GetNewUser();

            CheckListDto checkListDto = null;
            userDao.WrapInSession(() =>
            {
                Assert.IsTrue(userDto.Id == 0);
                userDao.CreateUser(userDto);
                Assert.IsTrue(userDto.Id > 0);

                checkListDto = GetNewCheckList(userDto.Id);
                Assert.IsTrue(checkListDto.Id == 0);
                checkListDao.CreateCheckList(checkListDto);
                Assert.IsTrue(checkListDto.Id > 0);

                var dbCheckListDto = checkListDao.GetCheckListById(checkListDto.Id);
                Assert.IsNotNull(dbCheckListDto);
                Assert.AreEqual(checkListDto.Id, dbCheckListDto.Id);
            }, false);

            var dbCheckListDto2 = checkListDao.GetCheckListById(checkListDto.Id);
            Assert.IsNull(dbCheckListDto2);
        }


        [Test]
        public void CreateCheckList_GetCheckListById_UpdateCheckList()
        {
            var userDao = new UserDao();
            var checkListDao = new CheckListDao();
            var userDto = GetNewUser();

            CheckListDto checkListDto = null;
            userDao.WrapInSession(() =>
            {
                Assert.IsTrue(userDto.Id == 0);
                userDao.CreateUser(userDto);
                Assert.IsTrue(userDto.Id > 0);

                checkListDto = GetNewCheckList(userDto.Id);
                Assert.IsTrue(checkListDto.Id == 0);
                checkListDao.CreateCheckList(checkListDto);
                Assert.IsTrue(checkListDto.Id > 0);

                var dbCheckListDto = checkListDao.GetCheckListById(checkListDto.Id);
                Assert.IsNotNull(dbCheckListDto);
                Assert.AreEqual(checkListDto.Id, dbCheckListDto.Id);
                Assert.IsTrue(dbCheckListDto.Active);

                dbCheckListDto.Active = false;
                checkListDao.UpdateCheckList(dbCheckListDto);

                dbCheckListDto = checkListDao.GetCheckListById(checkListDto.Id);
                Assert.IsNotNull(dbCheckListDto);
                Assert.AreEqual(checkListDto.Id, dbCheckListDto.Id);
                Assert.IsFalse(dbCheckListDto.Active);

            }, false);

            var dbCheckListDto2 = checkListDao.GetCheckListById(checkListDto.Id);
            Assert.IsNull(dbCheckListDto2);
        }

        [Test]
        public void CreateCheckList_GetCheckListById_DeleteCheckListById()
        {
            var userDao = new UserDao();
            var checkListDao = new CheckListDao();
            var userDto = GetNewUser();

            CheckListDto checkListDto = null;
            userDao.WrapInSession(() =>
            {
                Assert.IsTrue(userDto.Id == 0);
                userDao.CreateUser(userDto);
                Assert.IsTrue(userDto.Id > 0);

                checkListDto = GetNewCheckList(userDto.Id);
                Assert.IsTrue(checkListDto.Id == 0);
                checkListDao.CreateCheckList(checkListDto);
                Assert.IsTrue(checkListDto.Id > 0);

                var dbCheckListDto = checkListDao.GetCheckListById(checkListDto.Id);
                Assert.IsNotNull(dbCheckListDto);
                Assert.AreEqual(checkListDto.Id, dbCheckListDto.Id);
                Assert.IsTrue(dbCheckListDto.Active);

                checkListDao.DeleteCheckListById(dbCheckListDto.Id);

                dbCheckListDto = checkListDao.GetCheckListById(checkListDto.Id);
                Assert.IsNotNull(dbCheckListDto);
                Assert.AreEqual(checkListDto.Id, dbCheckListDto.Id);
                Assert.IsFalse(dbCheckListDto.Active);

            }, false);

            var dbCheckListDto2 = checkListDao.GetCheckListById(checkListDto.Id);
            Assert.IsNull(dbCheckListDto2);
        }
    }
}
