using Auctionata.Domain.Specification.Interfaces;

namespace Auctionata.Domain.Entities.Validations.Specifications.BuyerSpecs
{
    public class BuyerShouldHaveNameSpec: ISpecification<Buyer>
    {
        public string ErrorMessage { get; private set; }

        public bool IsSatisfiedBy(Buyer buyer)
        {
            var isSatisfiedBy = !string.IsNullOrEmpty(buyer.Name);

            if (!isSatisfiedBy)
                ErrorMessage = string.Format(SpecificationMessages.DataIsRequired, SpecificationMessages.Name);

            return isSatisfiedBy;
        }
    }
}