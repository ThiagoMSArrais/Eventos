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

            var eventoCompleto = Evento.EventoFactory.NovoEventoCompleto(evento.Id, evento.Nome, evento.DescricaoCurta, evento.DescricaoLonga,
                                                                         evento.DataInicioDoEvento, evento.DataFimDoEvento, evento.Gratuito, evento.Valor,
                                                                         evento.Online, evento.NomeDaEmpresa, null, endereco);
            _eventoService.Adicionar(eventoCompleto);

            if (Commit())
            {
                //TODO: MENSAGEM DE SUCESSO NO FRONTEND
            }

            return eventoEnderecoViewModel;
        }

        public void Atualizar(EventoViewModel eventoViewModel)
        {
            var evento = _mapper.Map<EventoViewModel, Evento>(eventoViewModel);

            _eventoService.Atualizar(evento);

            if (Commit())
            {
                //TODO: MENSAGEM DE SUCESSO NO FRONTEND
            }
        }

        public EventoViewModel ObterPorId(Guid id)
        {
            var evento = _mapper.Map<Evento, EventoViewModel>(_eventoService.ObterPorId(id));

            return evento;
        }

        public IEnumerable<EventoViewModel> ObterTodos()
        {
            var eventos = _mapper.Map<IEnumerable<Evento>, IEnumerable<EventoViewModel>>(_eventoService.ObterTodos());

            return eventos;
        }

        public void Remover(Guid id)
        {
            _eventoService.Remover(id);
        }

        public void Dispose()
        {

        }
    }
}