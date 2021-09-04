using AutoMapper;
using Entities;
using Entities.Dto;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Board, GetBoardsDto>()
                .ReverseMap();
        }
    }
}
