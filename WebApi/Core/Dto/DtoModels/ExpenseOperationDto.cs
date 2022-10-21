using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class ExpenseOperationDto
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal Sum { get; set; }

        public int ExpenseTypeId { get; set; }
    }
}
