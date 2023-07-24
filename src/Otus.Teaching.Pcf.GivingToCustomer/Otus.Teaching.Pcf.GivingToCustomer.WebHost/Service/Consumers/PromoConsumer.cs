using MassTransit;
using Otus.Teaching.Pcf.GivingToCustomer.Core.Abstractions.Repositories;
using Otus.Teaching.Pcf.GivingToCustomer.Core.Domain;
using Otus.Teaching.Pcf.GivingToCustomer.DataAccess;
using Otus.Teaching.Pcf.GivingToCustomer.DataAccess.Repositories;
using Otus.Teaching.Pcf.GivingToCustomer.Integration.DTO;
using Otus.Teaching.Pcf.GivingToCustomer.WebHost.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Teaching.Pcf.GivingToCustomer.Integration.Consumers
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
