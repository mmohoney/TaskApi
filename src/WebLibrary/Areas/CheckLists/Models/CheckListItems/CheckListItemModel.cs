using System;
using System.Collections.Generic;
using Domain.CheckLists;

namespace WebLibrary.Areas.CheckLists.Models.CheckListItems
{
    public class CheckListItemModel
    {
        public int Id { get; set; }
        public int CheckListId { get; set; }
        public bool IsComplete { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool Active { get; set; }

        public static CheckListItemModel FromDomain(CheckListItemEntity domain)
        {
            return new CheckListItemModel
            {
                Id = domain.Id,
                CheckListId = domain.CheckListId,
                IsComplete = domain.IsComplete,
                Description = domain.Description,
                DueDate = domain.DueDate,
                Active = domain.Active
            };
        }

        public CheckListItemEntity ToDomain()
        {
            return new CheckListItemEntity
            {
                Id = Id,
                CheckListId = CheckListId,
                IsComplete = IsComplete,
                Description = Description,
                DueDate = DueDate,
                Active = Active
            };
        }

        public List<string> ValidateCreate()
        {
            List<string> errors = new List<string>();
            if (Id > 0)
                errors.Add("Cannot create new check list item when Id is greater than 0.");

            if (CheckListId < 1)
                errors.Add("Cannot create new check list item when CheckListId is less than 1.");

            if (Active == false)
                errors.Add("Cannot create new check list item when Active is false.");

            return errors;
        }

        public List<string> ValidateUpdate()
        {
            List<string> errors = new List<string>();
            if (Id < 1)
                errors.Add("Cannot update check list when Id is less than 1.");

            return errors;
        }
    }
}