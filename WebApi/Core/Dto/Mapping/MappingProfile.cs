using AutoMapper;

namespace Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OperationDto, Operation>();
            CreateMap<OperationTypeDto, OperationType>();

            CreateMap<Operation, OperationDto>();
            CreateMap<OperationType, OperationTypeDto>();
        }
    }
}
