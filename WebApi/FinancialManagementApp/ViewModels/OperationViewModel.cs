
using System.ComponentModel.DataAnnotations;

namespace FinancialManagementApp
{
    public class OperationViewModel : IEntityBase
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]        
        public decimal Sum { get; set; }

        [OperationTypeIdValidation(ErrorMessage = "Select category or create new")]
        public int OperationTypeId { get; set; }
    }
}
