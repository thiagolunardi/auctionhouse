using System;
using System.Collections.Generic;
using Auctionata.Domain.Validation;

namespace Auctionata.Domain.Entities.Common
{
    public abstract class Identity
    {
        /// <summary>
        /// Unique Identifier
        /// </summary>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Validation error collection filled after IsValid is called
        /// </summary>
        public IEnumerable<ValidationError> ValidationErrors { get; protected set; }

        /// <summary>
        /// Check if this entity has valid data
        /// </summary>
        public virtual bool IsValid { get; }
    }
}