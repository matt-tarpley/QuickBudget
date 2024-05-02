using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetBills.Models
{
    public class Bill
    {
        public int BillId { get; set; }

        [Required(ErrorMessage = "Please enter a bill description")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter an amount.")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "Please enter a due date")]
        public DateTime DueDate { get; set; }

        //Category Foriegn Key
        [Required(ErrorMessage = "Please enter a category.")]
        public int CategoryId { get; set; } //fk
        public Category? Category { get; set; } //navigation MUST BE NULLABLE


        #region [NotMapped]
        [NotMapped]
        public bool IsPaid { get; set; }

        [NotMapped]
        public string AmountFormatted
        {
            get
            {
                return Amount.ToString("C");
            }
        }

        [NotMapped]
        public DateOnly DateFormatted 
        {
            get
            {
                return DateOnly.FromDateTime(DueDate);
            }
        }
        #endregion [NotMapped]

    }
}
