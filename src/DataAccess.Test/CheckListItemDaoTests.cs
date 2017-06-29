using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Implementations.CheckLists;
using DataAccess.Implementations.Users;
using DataTransfer.CheckLists;
using DataTransfer.Users;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace DataAccess.Test
{
    [TestFixture]
    public class CheckListItemDaoTests
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

        private CheckListItemDto GetNewCheckListItem(int checkListId)
        {
            return new CheckListItemDto
            {
                CheckListId = checkListId,
                IsComplete = false,
                Description = "Description",
                DueDate = DateTime.Now.AddDays(7),
                Active = true
            };
        }

        [Test]
        public void CreateCheckList_GetAllCheckListsByUserId()
        {
            var userDao = new UserDao();
            var checkListDao = new CheckListDao();
            var checkListItemDao = new CheckListItemDao();
            var userDto = GetNewUser();

            CheckListDto checkListDto = null;
            CheckListItemDto checkListItemDto = null;
            userDao.WrapInSession(() =>
            {
                Assert.IsTrue(userDto.Id == 0);
                userDao.CreateUser(userDto);
                Assert.IsTrue(userDto.Id > 0);

                checkListDto = GetNewCheckList(userDto.Id);
                Assert.IsTrue(checkListDto.Id == 0);
                checkListDao.CreateCheckList(checkListDto);
                Assert.IsTrue(checkListDto.Id > 0);

                checkListItemDto = GetNewCheckListItem(checkListDto.Id);
                Assert.IsTrue(checkListItemDto.Id == 0);
                checkListItemDao.CreateCheckListItem(checkListItemDto);
                Assert.IsTrue(checkListItemDto.Id > 0);

                var dbCheckListItemDtos = checkListItemDao.GetAllCheckListItemsByCheckListId(checkListDto.Id);
                Assert.IsNotEmpty(dbCheckListItemDtos);
                Assert.IsNotNull(dbCheckListItemDtos.Find(d => d.Id == checkListItemDto.Id));
            }, false);
        }

        [Test]
        public void CreateCheckListItem_GetCheckListItemById()
        {
            var userDao = new UserDao();
            var checkListDao = new CheckListDao();
            var checkListItemDao = new CheckListItemDao();
            var userDto = GetNewUser();

            CheckListDto checkListDto = null;
            CheckListItemDto checkListItemDto = null;
            userDao.WrapInSession(() =>
            {
                Assert.IsTrue(userDto.Id == 0);
                userDao.CreateUser(userDto);
                Assert.IsTrue(userDto.Id > 0);

                checkListDto = GetNewCheckList(userDto.Id);
                Assert.IsTrue(checkListDto.Id == 0);
                checkListDao.CreateCheckList(checkListDto);
                Assert.IsTrue(checkListDto.Id > 0);

                checkListItemDto = GetNewCheckListItem(checkListDto.Id);
                Assert.IsTrue(checkListItemDto.Id == 0);
                checkListItemDao.CreateCheckListItem(checkListItemDto);
                Assert.IsTrue(checkListItemDto.Id > 0);

                var dbCheckListItemDto = checkListItemDao.GetCheckListItemById(checkListItemDto.Id);
                Assert.IsNotNull(dbCheckListItemDto);
                Assert.AreEqual(checkListItemDto.Id, dbCheckListItemDto.Id);
            }, false);
        }

        [Test]
        public void UpdateCheckListItem()
        {
            var userDao = new UserDao();
            var checkListDao = new CheckListDao();
            var checkListItemDao = new CheckListItemDao();
            var userDto = GetNewUser();

            CheckListDto checkListDto = null;
            CheckListItemDto checkListItemDto = null;
            userDao.WrapInSession(() =>
            {
                Assert.IsTrue(userDto.Id == 0);
                userDao.CreateUser(userDto);
                Assert.IsTrue(userDto.Id > 0);

                checkListDto = GetNewCheckList(userDto.Id);
                Assert.IsTrue(checkListDto.Id == 0);
                checkListDao.CreateCheckList(checkListDto);
                Assert.IsTrue(checkListDto.Id > 0);

                checkListItemDto = GetNewCheckListItem(checkListDto.Id);
                Assert.IsTrue(checkListItemDto.Id == 0);
                checkListItemDao.CreateCheckListItem(checkListItemDto);
                Assert.IsTrue(checkListItemDto.Id > 0);

                var dbCheckListItemDto = checkListItemDao.GetCheckListItemById(checkListItemDto.Id);
                Assert.IsNotNull(dbCheckListItemDto);
                Assert.AreEqual(checkListItemDto.Id, dbCheckListItemDto.Id);

                dbCheckListItemDto.Active = false;
                checkListItemDao.UpdateCheckListItem(dbCheckListItemDto);

                dbCheckListItemDto = checkListItemDao.GetCheckListItemById(checkListItemDto.Id);
                Assert.IsNotNull(dbCheckListItemDto);
                Assert.AreEqual(checkListItemDto.Id, dbCheckListItemDto.Id);

                Assert.IsFalse(dbCheckListItemDto.Active);
            }, false);
        }

        [Test]
        public void DeleteCheckListItemById()
        {
            var userDao = new UserDao();
            var checkListDao = new CheckListDao();
            var checkListItemDao = new CheckListItemDao();
            var userDto = GetNewUser();

            CheckListDto checkListDto = null;
            CheckListItemDto checkListItemDto = null;
            userDao.WrapInSession(() =>
            {
                Assert.IsTrue(userDto.Id == 0);
                userDao.CreateUser(userDto);
                Assert.IsTrue(userDto.Id > 0);

                checkListDto = GetNewCheckList(userDto.Id);
                Assert.IsTrue(checkListDto.Id == 0);
                checkListDao.CreateCheckList(checkListDto);
                Assert.IsTrue(checkListDto.Id > 0);

                checkListItemDto = GetNewCheckListItem(checkListDto.Id);
                Assert.IsTrue(checkListItemDto.Id == 0);
                checkListItemDao.CreateCheckListItem(checkListItemDto);
                Assert.IsTrue(checkListItemDto.Id > 0);

                var dbCheckListItemDto = checkListItemDao.GetCheckListItemById(checkListItemDto.Id);
                Assert.IsNotNull(dbCheckListItemDto);
                Assert.AreEqual(checkListItemDto.Id, dbCheckListItemDto.Id);

                checkListItemDao.DeleteCheckListItemById(dbCheckListItemDto.Id);

                dbCheckListItemDto = checkListItemDao.GetCheckListItemById(checkListItemDto.Id);
                Assert.IsNotNull(dbCheckListItemDto);
                Assert.AreEqual(checkListItemDto.Id, dbCheckListItemDto.Id);

                Assert.IsFalse(dbCheckListItemDto.Active);
            }, false);
        }
    }
}
