using TMSA.Eventos.Domain.Interfaces;

namespace TMSA.Eventos.Application
{
    public class ApplicationService
    {
        private readonly IUnitOfWork _uow;

        public ApplicationService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public bool Commit()
        {
           return _uow.Commit();
        }
    }
}