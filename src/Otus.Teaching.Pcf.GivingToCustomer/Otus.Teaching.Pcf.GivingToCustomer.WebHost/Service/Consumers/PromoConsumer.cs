using MassTransit;
using Otus.Teaching.Pcf.Message;
using System.Threading.Tasks;

namespace Otus.Teaching.Pcf.GivingToCustomer.WebHost.Service.Consumers
{
    public class PromoConsumer:IConsumer<GivePromoCodeToCustomerDto>
    {
        private readonly IPromoCodeService _promoCodeservice;
        public PromoConsumer(IPromoCodeService promoCodeService)
        {
            _promoCodeservice = promoCodeService;
        }

        public async Task Consume(ConsumeContext<GivePromoCodeToCustomerDto> context)
        {
            await _promoCodeservice.GivePromoCodesToCustomersWithPreferenceAsync(context.Message);     
        }        
    }
}
