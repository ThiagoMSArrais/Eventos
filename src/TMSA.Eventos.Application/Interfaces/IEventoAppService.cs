using System;
using System.Collections.Generic;
using TMSA.Eventos.Application.ViewModels;

namespace TMSA.Eventos.Application.Interfaces
{
    public interface IEventoAppService : IDisposable
    {
        EventoEnderecoViewModel Adicionar(EventoEnderecoViewModel eventoEndereco);
        void Atualizar(EventoViewModel obj);
        void Remover(Guid id);
        EventoViewModel ObterPorId(Guid id);
        IEnumerable<EventoViewModel> ObterTodos();
    }
}