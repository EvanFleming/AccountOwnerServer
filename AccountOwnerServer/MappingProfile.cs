using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Owner, OwnerDto>();
        
        var mapOwnerToCreateDto = CreateMap<Owner, OwnerForCreationDto>();

        var mapCreateDtoToOwner = CreateMap<OwnerForCreationDto, Owner>();

        CreateMap<Account, AccountDto>();

    }

    
}