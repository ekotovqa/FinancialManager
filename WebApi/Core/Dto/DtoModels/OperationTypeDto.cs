using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class OperationTypeDto
    {       
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsIncome { get; set; }
    }
}
