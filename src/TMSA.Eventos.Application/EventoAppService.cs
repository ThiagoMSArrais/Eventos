using AutoMapper;
using System;
using System.Collections.Generic;
using TMSA.Eventos.Application.Interfaces;
using TMSA.Eventos.Application.ViewModels;
using TMSA.Eventos.Domain.Interfaces;
using TMSA.Eventos.Domain.Interfaces.service;
using TMSA.Eventos.Domain.Eventos;

namespace TMSA.Eventos.Application
{
    public class EventoAppService : ApplicationService, IEventoAppService
    {

        private readonly IEventoService _eventoService;
        private readonly IMapper _mapper;

        public EventoAppService(IEventoService eventoService, IUnitOfWork uow) : base(uow)
        {
            _eventoService = eventoService;
        }

        public EventoEnderecoViewModel Adicionar(EventoEnderecoViewModel eventoEnderecoViewModel)
        {
            var evento = _mapper.Map<EventoEnderecoViewModel, Evento>(eventoEnderecoViewModel);
            var endereco = _mapper.Map<EventoEnderecoViewModel, Endereco>(eventoEnderecoViewModel);

            return eventoEnderecoViewModel;
        }

        public void Atualizar(EventoViewModel obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public EventoViewModel ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventoViewModel> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
