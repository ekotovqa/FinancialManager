using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class IncomeOperation : IEntityBase
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Sum { get; set; }

        public int IncomeTypeId { get; set; }

        [ForeignKey("IncomeTypeId")]
        public IncomeType IncomeType { get; set; }
    }
}
