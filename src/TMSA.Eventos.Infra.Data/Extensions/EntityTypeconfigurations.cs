using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TMSA.Eventos.Infra.Data.Extensions
{
    public abstract class EntityTypeconfigurations<TEntity> where TEntity : class
    {
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }
}