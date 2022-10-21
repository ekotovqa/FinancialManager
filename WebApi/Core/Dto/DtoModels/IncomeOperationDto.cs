using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class IncomeOperationDto
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal Sum { get; set; }

        [Required]
        public int IncomeTypeId { get; set; }
    }
}
