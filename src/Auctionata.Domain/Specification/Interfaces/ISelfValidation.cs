using System.Collections.Generic;
using Auctionata.Domain.Validation;

namespace Auctionata.Domain.Specification.Interfaces
{
    public interface ISelfValidation
    {
        IEnumerable<ValidationError> ValidationErrors { get; }
        bool IsValid { get; }
    }
}
