using System;
using System.Collections.Generic;
using TMSA.Eventos.Application.Interfaces;
using TMSA.Eventos.Application.ViewModels;
using TMSA.Eventos.Domain.Interfaces;
using TMSA.Eventos.Domain.Interfaces.service;

namespace TMSA.Eventos.Application
{
    public class EventoAppService : ApplicationService, IEventoAppService
    {

        private readonly IEventoService _eventoService;

        public EventoAppService(IEventoService eventoService, IUnitOfWork uow) : base(uow)
        {
            _eventoService = eventoService;
        }

        public EventoEnderecoOrganizador Adicionar(EventoEnderecoOrganizador eventoEnderecoOrganizador)
        {
            throw new NotImplementedException();
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
