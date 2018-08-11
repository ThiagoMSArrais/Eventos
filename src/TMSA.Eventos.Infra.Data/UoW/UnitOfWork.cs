using TMSA.Eventos.Domain.Interfaces;
using TMSA.Eventos.Infra.Data.Context;

namespace TMSA.Eventos.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EventoContext _context;

        public UnitOfWork(EventoContext contexto)
        {
            _context = contexto;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}