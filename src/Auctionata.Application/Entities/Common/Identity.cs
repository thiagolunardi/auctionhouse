using System;

namespace Auctionata.Application.Entities.Common
{
    public abstract class Identity
    {
        /// <summary>
        /// Unique Identifier
        /// </summary>
        public Guid Id { get; protected set; }
    }
}