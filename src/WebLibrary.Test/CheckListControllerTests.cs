using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using Domain.CheckLists;
using NUnit.Framework;
using Service.CheckLists.Interfaces;
using WebLibrary.Areas.CheckLists.Controllers;
using WebLibrary.Areas.CheckLists.Models.CheckLists;

namespace WebLibrary.Test
{
    [TestFixture]
    public class CheckListControllerTests
    {
        private readonly CheckListController _controller = new CheckListController(new CheckListServiceTest()) { Configuration = new HttpConfiguration() };

        [Test]
        public void GetAllCheckListsForUser_Invalid()
        {
            var result = _controller.GetAllCheckListsForUser(0);
            var converted = (NegotiatedContentResult<List<string>>)result;
            Assert.IsTrue(converted.StatusCode == HttpStatusCode.BadRequest);
        }

        [Test]
        public void GetAllCheckListsForUser_Valid()
        {
            var result = _controller.GetAllCheckListsForUser(1);
            var converted = (OkNegotiatedContentResult<List<CheckListModel>>)result;
            Assert.IsTrue(converted.Content.Count == 2);
            Assert.IsNotNull(converted.Content.Find(m => m.Id == 1));
            Assert.IsNotNull(converted.Content.Find(m => m.Id == 2));
        }

        [Test]
        public void GetCheckListById_Invalid()
        {
            var result = _controller.GetCheckListById(0);
            var converted = (NegotiatedContentResult<List<string>>)result;
            Assert.IsTrue(converted.StatusCode == HttpStatusCode.BadRequest);
        }

        [Test]
        public void GetCheckListById_Valid()
        {
            var result = _controller.GetCheckListById(1);
            var converted = (OkNegotiatedContentResult<CheckListModel>)result;
            Assert.IsTrue(converted.Content.Id == 3);
        }

        [Test]
        public void CreateCheckList_Invalid()
        {
            var model = new CheckListModel() {Id = 1};
            var result = _controller.CreateCheckList(model);
            var converted = (NegotiatedContentResult<List<string>>)result;
            Assert.IsTrue(converted.StatusCode == HttpStatusCode.BadRequest);
        }

        [Test]
        public void CreateCheckList_Valid()
        {
            var model = new CheckListModel()
            {
                Id = 0,
                UserId = 1,
                Description = "1",
                Active = true
            };
            var result = _controller.CreateCheckList(model);
            var converted = (OkNegotiatedContentResult<CheckListModel>)result;
            Assert.IsTrue(converted.Content.Id == 4);
        }

        [Test]
        public void UpdateCheckList_Invalid()
        {
            var model = new CheckListModel() { Id = 0 };
            var result = _controller.UpdateCheckList(model);
            var converted = (NegotiatedContentResult<List<string>>)result;
            Assert.IsTrue(converted.StatusCode == HttpStatusCode.BadRequest);
        }

        [Test]
        public void UpdateCheckList_Valid()
        {
            var model = new CheckListModel()
            {
                Id = 5,
                UserId = 1,
                Description = "5",
                Active = true
            };
            var result = _controller.UpdateCheckList(model);
            var converted = (OkNegotiatedContentResult<CheckListModel>)result;
            Assert.IsTrue(converted.Content.Id == 5);
        }

        [Test]
        public void DeleteCheckListById_Invalid()
        {
            var result = _controller.DeleteCheckListById(0);
            var converted = (NegotiatedContentResult<List<string>>)result;
            Assert.IsTrue(converted.StatusCode == HttpStatusCode.BadRequest);
        }

        [Test]
        public void DeleteCheckListById_Valid()
        {
            var result = _controller.DeleteCheckListById(1);
            var converted = (OkResult)result;
        }


        class CheckListServiceTest : ICheckListService
        {
            public List<CheckListEntity> GetAllCheckListsForUserId(int userId)
            {
                return new List<CheckListEntity>
                {
                    new CheckListEntity()
                    {
                        Id = 1,
                        UserId = 1,
                        Description = "1",
                        Active = true,
                    },
                    new CheckListEntity()
                    {
                        Id = 2,
                        UserId = 1,
                        Description = "2",
                        Active = true,
                    }
                };
            }

            public CheckListEntity GetCheckListById(int id)
            {
                return new CheckListEntity()
                {
                    Id = 3,
                    UserId = 1,
                    Description = "1",
                    Active = true,
                };
            }

            public CheckListEntity CreateCheckList(CheckListEntity checkList)
            {
                return new CheckListEntity()
                {
                    Id = 4,
                    UserId = 1,
                    Description = "Description",
                    Active = true,
                };
            }

            public CheckListEntity UpdateCheckList(CheckListEntity checkList)
            {
                return new CheckListEntity()
                {
                    Id = 5,
                    UserId = 1,
                    Description = "Description",
                    Active = true,
                };
            }

            public void DeleteCheckListById(int id)
            {

            }
        }
    }
}
