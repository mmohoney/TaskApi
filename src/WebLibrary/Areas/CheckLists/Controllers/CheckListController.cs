﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.CheckLists;
using Service.CheckLists.Interfaces;
using WebLibrary.Areas.CheckLists.Models.CheckLists;

namespace WebLibrary.Areas.CheckLists.Controllers
{
    /// <summary>
    /// Check list management API
    /// </summary>
    public class CheckListController : ApiController
    {
        private readonly ICheckListService _checkListService;

        /// <summary>
        /// Constructor using IoC
        /// </summary>
        /// <param name="checkListService"></param>
        public CheckListController(ICheckListService checkListService)
        {
            _checkListService = checkListService;
        }

        /// <summary>
        /// Get all check lists for provided user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IHttpActionResult GetAllCheckListsForUser(int userId)
        {
            if (userId < 1)
                return CreateErrorResponse("id must be greater than 0.");

            List<CheckListEntity> checkLists = _checkListService.GetAllCheckListsForUserId(userId);
            List<CheckListModel> models = checkLists.Select(CheckListModel.FromDomain).ToList();
            return Ok(models);
        }

        /// <summary>
        /// Get check list by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult GetCheckListById(int id)
        {
            if (id < 1)
                return CreateErrorResponse("id must be greater than 0.");

            CheckListEntity checkList = _checkListService.GetCheckListById(id);
            CheckListModel model = CheckListModel.FromDomain(checkList);
            return Ok(model);
        }

        /// <summary>
        /// Create the provided check list
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IHttpActionResult CreateCheckList(CheckListModel model)
        {
            List<string> validationMessages = model.ValidateCreate();
            if (validationMessages.Any())
                return CreateErrorResponse(validationMessages);

            CheckListEntity checkList = _checkListService.CreateCheckList(new CheckListEntity());
            CheckListModel resultModel = CheckListModel.FromDomain(checkList);
            return Ok(resultModel);
        }

        /// <summary>
        /// Update the provided check list
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IHttpActionResult UpdateCheckList(CheckListModel model)
        {
            List<string> validationMessages = model.ValidateUpdate();
            if (validationMessages.Any())
                return CreateErrorResponse(validationMessages);

            CheckListEntity checkList = _checkListService.UpdateCheckList(new CheckListEntity());
            CheckListModel resultModel = CheckListModel.FromDomain(checkList);
            return Ok(resultModel);
        }

        /// <summary>
        /// Delete the provided check list by id
        /// </summary>
        /// <param name="id"></param>
        public IHttpActionResult DeleteCheckListById(int id)
        {
            if (id < 1)
                return CreateErrorResponse("id must be greater than 0.");

            _checkListService.DeleteCheckListById(id);

            return Ok();
        }

        private IHttpActionResult CreateErrorResponse(string error)
        {
            return CreateErrorResponse(new List<string> {error});
        }

        private IHttpActionResult CreateErrorResponse(List<string> errors)
        {
            return Content(HttpStatusCode.BadRequest, errors);
        }
    }
}
