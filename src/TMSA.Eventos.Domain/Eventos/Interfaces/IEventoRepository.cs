using TMSA.Eventos.Domain.Interfaces;

namespace TMSA.Eventos.Domain.Eventos.Interfaces
{
    public interface IEventoRepository : IRepository<Evento>
    {
        Evento ObterPorNomeDoEvento(string nomeDoEvento);
    }
}