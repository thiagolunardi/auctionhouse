using Auctionata.Application.Interfaces.Common;
using Auctionata.Infra.Data.Context.Interfaces;
using ValidationResult = Auctionata.Application.Validation.ValidationResult;

namespace Auctionata.Application.Common
{
    public class AppService<TContext> : IAppService<TContext>
             where TContext : IDbContext, new()
    {
        private readonly IUnitOfWork<TContext> _uow;

        public AppService(IUnitOfWork<TContext> uow)
        {
            ValidationResult = new ValidationResult();
            _uow = uow;
        }

        protected ValidationResult ValidationResult { get; set; }

        public virtual void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        public virtual void Commit()
        {
            _uow.SaveChanges();
        }
    }
}