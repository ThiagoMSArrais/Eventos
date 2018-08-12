using System;
using System.Collections.Generic;
using TMSA.Eventos.Domain.Eventos;

namespace TMSA.Eventos.Domain.Interfaces.service
{
    public interface IEventoService : IDisposable
    {
        Evento Adicionar(Evento evento);
        void Atualizar(Evento obj);
        void Remover(Guid id);
        Evento ObterPorId(Guid id);
        IEnumerable<Evento> ObterTodos();
    }
}