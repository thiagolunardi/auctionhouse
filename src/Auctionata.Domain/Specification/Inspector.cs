using System;
using System.Collections.Generic;
using System.Linq;
using Auctionata.Domain.Specification.Interfaces;
using Auctionata.Domain.Validation;

namespace Auctionata.Domain.Specification
{
    public class Inspector<TEntity> : IInspector<TEntity> 
        where TEntity : class
    {
        private readonly Dictionary<string, IRule<TEntity>> _rules;

        public Inspector()
        {
            _rules = new Dictionary<string, IRule<TEntity>>();
        }

        protected void AddSpecification(ISpecification<TEntity> specification)
        {
            var rule = new Rule<TEntity>(specification);
            var ruleName = rule.GetType() + Guid.NewGuid().ToString("D");
            _rules.Add(ruleName, rule);
        }

        public ValidationResult Valid(TEntity entity)
        {
            var result = new ValidationResult();
            _rules.Keys.ToList().ForEach(key =>
            {
                var rule = _rules[key];
                if (!rule.Valid(entity))
                    result.Add(new ValidationError(rule.ErrorMessage));
            });
            return result;
        }
    }
}