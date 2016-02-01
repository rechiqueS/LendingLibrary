using System.ComponentModel.DataAnnotations;

namespace LendingLibrary.Models
{
    public class DeleteItemModel
    {
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
    }
}