using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class OperationDto
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal Sum { get; set; }

        [Required]
        public int OperationTypeId { get; set; }
    }
}
