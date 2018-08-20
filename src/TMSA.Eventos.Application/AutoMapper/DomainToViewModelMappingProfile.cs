using AutoMapper;
using TMSA.Eventos.Application.ViewModels;
using TMSA.Eventos.Domain.Eventos;
using TMSA.Eventos.Domain.Organizadores;

namespace TMSA.Eventos.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Evento, EventoViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Organizador, OrganizadorViewModel>();
            CreateMap<Evento, EventoEnderecoViewModel>();
            CreateMap<Endereco, EventoEnderecoViewModel>();
        }
    }
}