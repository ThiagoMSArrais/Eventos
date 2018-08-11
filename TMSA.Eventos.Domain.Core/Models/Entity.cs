using System;
using FluentValidation;
using FluentValidation.Results;

namespace TMSA.Eventos.Domain.Core.Models
{
    public abstract class Entity<TEntity> : AbstractValidator<TEntity> where TEntity : Entity<TEntity>
    {

        protected Entity()
        {
            ValidationResult = new ValidationResult();
        }

        public Guid Id { get; protected set; }
        public ValidationResult ValidationResult { get; protected set; }
        public abstract bool EhValido();
        
    }
}