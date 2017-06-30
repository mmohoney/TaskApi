using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Domain.CheckLists;
using Service.CheckLists.Interfaces;
using WebLibrary.Areas.CheckLists.Models.CheckListItems;
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
        [HttpGet]
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
        [HttpGet]
        public IHttpActionResult GetCheckListItemById(int id)
        {
            if (id < 1)
                return CreateErrorResponse("id must be greater than 0.");

            CheckListItemEntity checkListItem = _checkListItemService.GetCheckListItemById(id);
            CheckListItemModel model = CheckListItemModel.FromDomain(checkListItem);
            return Ok(model);
        }

        /// <summary>
        /// Create the provided check list item
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult CreateCheckListItem(CheckListItemModel model)
        {
            List<string> validationMessages = model.ValidateCreate();
            if (validationMessages.Any())
                return CreateErrorResponse(validationMessages);

            CheckListItemEntity checkListItem = _checkListItemService.CreateCheckListItem(model.ToDomain());
            CheckListItemModel resultModel = CheckListItemModel.FromDomain(checkListItem);
            return Ok(resultModel);
        }

        /// <summary>
        /// Update the provided check list item
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult UpdateCheckListItem(CheckListItemModel model)
        {
            List<string> validationMessages = model.ValidateUpdate();
            if (validationMessages.Any())
                return CreateErrorResponse(validationMessages);

            CheckListItemEntity checkList = _checkListItemService.UpdateCheckListItem(model.ToDomain());
            CheckListItemModel resultModel = CheckListItemModel.FromDomain(checkList);
            return Ok(resultModel);
        }

        /// <summary>
        /// Delete the provided check list item by id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        public IHttpActionResult DeleteCheckListItemById(int id)
        {
            if (id < 1)
                return CreateErrorResponse("id must be greater than 0.");

            _checkListItemService.DeleteCheckListItemById(id);

            return Ok();
        }
    }
}
