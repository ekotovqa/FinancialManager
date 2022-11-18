using System.ComponentModel.DataAnnotations;

namespace FinancialManagementApp
{
    public class OperationTypeViewModel : IEntityBase
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsIncome { get; set; }
    }
}
