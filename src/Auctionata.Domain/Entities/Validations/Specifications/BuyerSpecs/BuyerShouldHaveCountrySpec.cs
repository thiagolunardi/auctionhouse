using Auctionata.Domain.Specification.Interfaces;

namespace Auctionata.Domain.Entities.Validations.Specifications.BuyerSpecs
{
    public class BuyerShouldHaveCountrySpec: ISpecification<Buyer>
    {
        public string ErrorMessage { get; private set; }

        public bool IsSatisfiedBy(Buyer buyer)
        {
            var isSatisfiedBy = !string.IsNullOrEmpty(buyer.Country);

            if (!isSatisfiedBy)
                ErrorMessage = string.Format(SpecificationMessages.DataIsRequired, SpecificationMessages.Country);

            return isSatisfiedBy;
        }
    }
}