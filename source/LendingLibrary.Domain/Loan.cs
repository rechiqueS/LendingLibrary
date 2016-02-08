using System.ComponentModel.DataAnnotations;

namespace LendingLibrary.Domain
{
    public class Loan
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string BorrowerName { get; set; }
        [Required]
        [MaxLength(200)]
        public string ItemDescription { get; set; }
    }
}