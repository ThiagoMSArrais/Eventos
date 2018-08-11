using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMSA.Eventos.Domain.Core.Models;

namespace TMSA.Eventos.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        void Adicionar(TEntity obj);
        void Atualizar(TEntity obj);
        void Remover(Guid id);
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }
}