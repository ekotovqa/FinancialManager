using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class ExpenseTypeDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
