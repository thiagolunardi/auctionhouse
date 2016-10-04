using Auctionata.Application.AutoMapper;

namespace Auctionata.Application.Entities.Extensions
{
    public static class IncrementalRuleExtentions
    {
        public static Domain.Entities.IncrementalRule ToModel(this IncrementalRule vm)
        {
            return Mapper.Map<Domain.Entities.IncrementalRule>(vm);
        }
        public static IncrementalRule ToViewModel(this Domain.Entities.IncrementalRule model)
        {
            return Mapper.Map<IncrementalRule>(model);
        }
    }
}