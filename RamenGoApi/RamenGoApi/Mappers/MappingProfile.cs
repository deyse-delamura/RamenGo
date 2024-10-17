using AutoMapper;
using RamenGoApi.Application.Commands;
using RamenGoApi.Domain.Entities;
using RamenGoApi.DTOs;

namespace RamenGoApi.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pedido, PedidoResponse>()
                .ForMember(dest => dest.PedidoId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => $"{src.Caldo.Name} and {src.Proteina.Name}"))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.GetTotalPrice()));

            CreateMap<PedidoRequest, CriarPedidoCommand>();
        }
    }
}
