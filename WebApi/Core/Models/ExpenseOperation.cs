using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class ExpenseOperation : IEntityBase
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Sum { get; set; }

        public int ExpenseTypeId { get; set; }

        [ForeignKey("ExpenseTypeId")]
        public ExpenseType ExpenseType { get; set; }

    }
}
