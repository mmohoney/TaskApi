using System;
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
    }
}