using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.CheckLists;
using Service.CheckLists.Interfaces;
using WebLibrary.Areas.CheckLists.Models.CheckListItems;
using WebLibrary.Areas.CheckLists.Models.CheckLists;
using WebLibrary.Controllers;

namespace WebLibrary.Areas.CheckLists.Controllers
{
    /// <summary>
    /// Check list item management API
    /// </summary>
    public class CheckListItemController : BaseApiController
    {
        private readonly ICheckListItemService _checkListItemService;

        /// <summary>
        /// Constructor using IoC
        /// </summary>
        /// <param name="checkListItemService"></param>
        public CheckListItemController(ICheckListItemService checkListItemService)
        {
            _checkListItemService = checkListItemService;
        }

        /// <summary>
        /// Get all active check list items for provided check list id
        /// </summary>
        /// <param name="checkListId"></param>
        /// <returns></returns>
        public IHttpActionResult GetAllCheckListItemsByCheckListId(int checkListId)
        {
            if (checkListId < 1)
                return CreateErrorResponse("checkListId must be greater than 0.");

            List<CheckListItemEntity> checkListItems = _checkListItemService.GetAllCheckListItemsByCheckListId(checkListId);
            List<CheckListItemModel> models = checkListItems.Select(CheckListItemModel.FromDomain).ToList();
            return Ok(models);
        }

        /// <summary>
        /// Get check list item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult GetCheckListItemById(int id)
        {
            if (id < 1)
                return CreateErrorResponse("id must be greater than 0.");

            CheckListItemEntity checkListItem = _checkListItemService.GetCheckListItemById(id);
            CheckListItemModel model = CheckListItemModel.FromDomain(checkListItem);
            return Ok(model);
        }
    }
}
