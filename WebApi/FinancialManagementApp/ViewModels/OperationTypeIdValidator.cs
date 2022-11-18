using System.ComponentModel.DataAnnotations;

namespace FinancialManagementApp
{
    public class OperationTypeIdValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if ((int)value == 0)
                return false;
            return true;
        }
    }
}
