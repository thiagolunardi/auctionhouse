namespace Auctionata.Domain.Specification.Interfaces
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T entity);
        string ErrorMessage { get; }
    }
}
