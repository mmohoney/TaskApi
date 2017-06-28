using System.Collections.Generic;
using System.Linq;
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
        /// Constructor
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
        public List<CheckListModel> GetAllCheckListsForUser(int userId)
        {
            List<CheckListEntity> checkLists = _checkListService.GetAllCheckListsForUser(userId);
            List<CheckListModel> models = checkLists.Select(CheckListModel.FromDomain).ToList();
            return models;
        }

        /// <summary>
        /// Get check list by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CheckListModel Get(int id)
        {
            CheckListEntity checkList = _checkListService.GetCheckListById(id);
            CheckListModel model = CheckListModel.FromDomain(checkList);
            return model;
        }

        /// <summary>
        /// Create the provided check list
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CheckListModel Post(CheckListModel model)
        {
            CheckListEntity checkList = _checkListService.CreateCheckList(new CheckListEntity());
            CheckListModel resultModel = CheckListModel.FromDomain(checkList);
            return resultModel;
        }

        /// <summary>
        /// Update the provided check list
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CheckListModel Put(CheckListModel model)
        {
            CheckListEntity checkList = _checkListService.UpdateCheckList(new CheckListEntity());
            CheckListModel resultModel = CheckListModel.FromDomain(checkList);
            return resultModel;
        }

        /// <summary>
        /// Delete the provided check list by id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            _checkListService.DeleteCheckList(id);
        }
    }
}
