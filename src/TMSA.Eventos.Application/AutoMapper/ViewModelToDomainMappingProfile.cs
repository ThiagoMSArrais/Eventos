using AutoMapper;
using TMSA.Eventos.Application.ViewModels;
using TMSA.Eventos.Domain.Eventos;
using TMSA.Eventos.Domain.Organizadores;

namespace TMSA.Eventos.Application.AutoMapper
{
    public  class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<EventoViewModel, Evento>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Organizador, OrganizadorViewModel>();
            CreateMap<Evento, EventoEnderecoViewModel>();
            CreateMap<Endereco, EventoEnderecoViewModel>();
        }
    }
}