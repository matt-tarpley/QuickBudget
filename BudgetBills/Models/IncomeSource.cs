using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetBills.Models
{
    public class IncomeSource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //explicitly add a auto-incremented pk
        public int IncomeId { get; set; }

        [Required(ErrorMessage="Please enter income description.")]
        public string Description { get; set;} = string.Empty;


        [Required(ErrorMessage = "Please enter income amount.")]
        public double Amount { get; set; }


        [Required(ErrorMessage = "Please enter pay day.")]
        public DateTime RecieveDate { get; set; }
    }
}
