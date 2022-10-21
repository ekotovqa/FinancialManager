using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class IncomeTypeDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
