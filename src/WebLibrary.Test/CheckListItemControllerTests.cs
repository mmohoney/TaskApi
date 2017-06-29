using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Domain.CheckLists;
using NUnit.Framework;
using Service.CheckLists.Interfaces;
using StructureMap;
using WebLibrary.Areas.CheckLists.Controllers;
using WebLibrary.Areas.CheckLists.Models.CheckListItems;

namespace WebLibrary.Test
{
    [TestFixture]
    public class CheckListItemControllerTests
    {
        private IContainer _container;
        private CheckListItemController _controller;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _container = IoC.Initialize();
            _controller = new CheckListItemController(_container.GetInstance<ICheckListItemService>()) { Configuration = new HttpConfiguration() };
        }

        [Test]
        public void GetAllCheckListItemsByCheckListId_Invalid()
        {
            var result = _controller.GetAllCheckListItemsByCheckListId(0);
            var converted = (NegotiatedContentResult<List<string>>)result;
            Assert.IsTrue(converted.StatusCode == HttpStatusCode.BadRequest);
        }

        [Test]
        public void GetAllCheckListItemsByCheckListId_Valid()
        {
            var result = _controller.GetAllCheckListItemsByCheckListId(1);
            var converted = (OkNegotiatedContentResult<List<CheckListItemModel>>)result;
            Assert.IsTrue(converted.Content.Count == 2);
            Assert.IsNotNull(converted.Content.Find(m => m.Id == 1));
            Assert.IsNotNull(converted.Content.Find(m => m.Id == 2));
        }

        [Test]
        public void GetCheckListItemById_Invalid()
        {
            var result = _controller.GetCheckListItemById(0);
            var converted = (NegotiatedContentResult<List<string>>)result;
            Assert.IsTrue(converted.StatusCode == HttpStatusCode.BadRequest);
        }

        [Test]
        public void GetCheckListItemById_Valid()
        {
            var result = _controller.GetCheckListItemById(1);
            var converted = (OkNegotiatedContentResult<CheckListItemModel>)result;
            Assert.IsTrue(converted.Content.Id == 3);
        }


        public class CheckListItemControllerTestsCheckListItemService : ICheckListItemService
        {
            public List<CheckListItemEntity> GetAllCheckListItemsByCheckListId(int checkListId)
            {
                return new List<CheckListItemEntity>
                {
                    new CheckListItemEntity
                    {
                        Id = 1,
                        CheckListId = 1,
                        IsComplete = false,
                        Description = "1",
                        DueDate = null,
                        Active = true,
                    },
                    new CheckListItemEntity
                    {
                        Id = 2,
                        CheckListId = 1,
                        IsComplete = true,
                        Description = "1",
                        DueDate = null,
                        Active = true,
                    }
                };
            }

            public CheckListItemEntity GetCheckListItemById(int id)
            {
                return new CheckListItemEntity
                {
                    Id = 3,
                    CheckListId = 1,
                    IsComplete = true,
                    Description = "1",
                    DueDate = null,
                    Active = true,
                };
            }

            public CheckListItemEntity CreateCheckListItem(CheckListItemEntity checkListItem)
            {
                throw new NotImplementedException();
            }

            public CheckListItemEntity UpdateCheckList(CheckListItemEntity checkListItem)
            {
                throw new NotImplementedException();
            }

            public void DeleteCheckListItemById(int id)
            {
                throw new NotImplementedException();
            }
        }
    }
}
