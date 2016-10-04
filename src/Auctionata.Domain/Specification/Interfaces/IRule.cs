namespace Auctionata.Domain.Specification.Interfaces
{
    public interface IRule<in TEntity>
    {
        string ErrorMessage { get; }
        bool Valid(TEntity entity);
    }
}
