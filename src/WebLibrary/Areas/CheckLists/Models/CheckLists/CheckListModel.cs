using System;
using Domain.CheckLists;

namespace WebLibrary.Areas.CheckLists.Models.CheckLists
{
    public class CheckListModel
    {
        public int Id { get; set; }
		public int UserId { get; set; }
        public string CreatedUsername { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public string ModifiedUsername { get; set; }
        public DateTime ModifiedDate { get; set; }

        public static CheckListModel FromDomain(CheckListEntity domain)
        {
            return new CheckListModel();
        }
    }
}