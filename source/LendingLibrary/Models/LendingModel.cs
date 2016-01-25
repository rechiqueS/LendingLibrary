using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LendingLibrary.Models
{
    public class LendingModel
    {
        [Display(Name ="Item Description")]
        public string ItemDescription { get; set; }
        [Display(Name="Borrower Name")]
        public string BorrowerName { get; set; }
    }
}