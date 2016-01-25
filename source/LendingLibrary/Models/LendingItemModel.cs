using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LendingLibrary.Models
{
    public class LendingItemModel
    {
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
        [Display(Name = "Item Description")]
        public string ItemDescription { get; set; }
    }
}