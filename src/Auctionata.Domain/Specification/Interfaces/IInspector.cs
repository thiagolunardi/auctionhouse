using Auctionata.Domain.Validation;

namespace Auctionata.Domain.Specification.Interfaces
{
    public interface IInspector<in TEntity>
    {
        ValidationResult Valid(TEntity entity);
    }
}
