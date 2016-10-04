using Auctionata.Domain.Specification.Interfaces;

namespace Auctionata.Domain.Entities.Validations.Specifications.ItemSpecs
{
    public class ItemShouldHaveDetailedInformationSpec : ISpecification<Item>
    {
        public string ErrorMessage { get; private set; }

        public bool IsSatisfiedBy(Item item)
        {
            var isSatisfiedBy = !string.IsNullOrEmpty(item.MoreAboutThisItem);

            if (!isSatisfiedBy)
                ErrorMessage = string.Format(SpecificationMessages.DataIsRequired, SpecificationMessages.Detail);

            return isSatisfiedBy;
        }
    }
}