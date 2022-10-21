using AutoMapper;

namespace Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<IncomeOperation, IncomeOperationDto>();
            CreateMap<ExpenseOperation, ExpenseOperationDto>();
            CreateMap<IncomeType, IncomeTypeDto>();
            CreateMap<ExpenseType, ExpenseTypeDto>();

            CreateMap<IncomeOperationDto, IncomeOperation>();
            CreateMap<ExpenseOperationDto, ExpenseOperation>();
            CreateMap<IncomeTypeDto, IncomeType>();
            CreateMap<ExpenseTypeDto, ExpenseType>();
        }
    }
}
