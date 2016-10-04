using Auctionata.Domain.Specification.Interfaces;

namespace Auctionata.Domain.Entities.Validations.Specifications.ItemSpecs
{
    public class ItemShouldHavePictureSpec : ISpecification<Item>
    {
        public string ErrorMessage { get; private set; }

        public bool IsSatisfiedBy(Item item)
        {
            var isSatisfiedBy = !string.IsNullOrEmpty(item.Picture);

            if (!isSatisfiedBy)
                ErrorMessage = string.Format(SpecificationMessages.DataIsRequired, SpecificationMessages.Picture);

            return isSatisfiedBy;
        }
    }
}