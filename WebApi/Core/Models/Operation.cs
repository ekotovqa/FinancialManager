using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class Operation : IEntityBase
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public DateTime Date { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Sum { get; set; }

        [ForeignKey("OperationTypeId")]
        public OperationType OperationType { get; set; }
        public int OperationTypeId { get; set; }    
    }
}
