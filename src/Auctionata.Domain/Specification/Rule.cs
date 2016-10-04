using Auctionata.Domain.Specification.Interfaces;

namespace Auctionata.Domain.Specification
{
    public class Rule<TEntity> : IRule<TEntity>
    {
        private readonly ISpecification<TEntity> _specification;

        public Rule(ISpecification<TEntity> specification)
        {
            _specification = specification;
        }

        public string ErrorMessage { get; private set; }
        public bool Valid(TEntity entity)
        {
            var isSatisfiedBy = _specification.IsSatisfiedBy(entity);
            if (!isSatisfiedBy) ErrorMessage = _specification.ErrorMessage;
            return isSatisfiedBy;

        }
    }
}
