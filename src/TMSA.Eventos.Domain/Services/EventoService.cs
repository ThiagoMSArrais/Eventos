using System;
using System.Collections.Generic;
using TMSA.Eventos.Domain.Eventos;
using TMSA.Eventos.Domain.Eventos.Interfaces;
using TMSA.Eventos.Domain.Interfaces.service;

namespace TMSA.Eventos.Domain.Services
{
    public class EventoService : IEventoService
    {

        private readonly IEventoRepository _eventoRepository;

        public EventoService(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public void Adicionar(Evento evento)
        {
            _eventoRepository.Adicionar(evento);
        }

        public void Atualizar(Evento obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Evento ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Evento> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
