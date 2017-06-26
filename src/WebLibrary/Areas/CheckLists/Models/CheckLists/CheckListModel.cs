﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLibrary.Areas.CheckLists.Models.CheckLists
{
    public class CheckListModel
    {
        public int Id { get; set; }
        public string CreatedUsername { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public string ModifiedUsername { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}