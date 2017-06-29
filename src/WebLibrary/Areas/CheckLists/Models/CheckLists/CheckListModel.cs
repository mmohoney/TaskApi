using System.Collections.Generic;
using Domain.CheckLists;

namespace WebLibrary.Areas.CheckLists.Models.CheckLists
{
    public class CheckListModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public static CheckListModel FromDomain(CheckListEntity domain)
        {
            return new CheckListModel
            {
                Id = domain.Id,
                UserId = domain.UserId,
                Description = domain.Description,
                Active = domain.Active
            };
        }

        public CheckListEntity ToDomain()
        {
            return new CheckListEntity
            {
                Id = Id,
                UserId = UserId,
                Description = Description,
                Active = Active
            };
        }

        public List<string> ValidateCreate()
        {
            List<string> errors = new List<string>();
            if (Id > 0)
                errors.Add("Cannot create new check list when Id is greater than 0.");

            if (UserId < 1)
                errors.Add("Cannot create new check list when UserId is less than 0.");

            if (Active == false)
                errors.Add("Cannot create new check list when Active is false.");

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