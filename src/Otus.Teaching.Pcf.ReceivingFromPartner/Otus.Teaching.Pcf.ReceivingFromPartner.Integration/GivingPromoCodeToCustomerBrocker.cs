using MassTransit;
using Newtonsoft.Json;
using Otus.Teaching.Pcf.ReceivingFromPartner.Core.Domain;
using Otus.Teaching.Pcf.ReceivingFromPartner.Integration.Dto;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Teaching.Pcf.ReceivingFromPartner.Integration
{
    public class GivingPromoCodeToCustomerBrocker
    {
        private readonly IBusControl _busControl;

        public GivingPromoCodeToCustomerBrocker(IBusControl busControl)
        {
            _busControl = busControl;
        }

        public async Task GivePromoCodeToCustomer(PromoCode promoCode)
        {
            var dto = new GivePromoCodeToCustomerDto()
            {
                PartnerId = promoCode.Partner.Id,
                BeginDate = promoCode.BeginDate.ToShortDateString(),
                EndDate = promoCode.EndDate.ToShortDateString(),
                PreferenceId = promoCode.PreferenceId,
                PromoCode = promoCode.Code,
                ServiceInfo = promoCode.ServiceInfo,
                PartnerManagerId = promoCode.PartnerManagerId
            };

            await _busControl.Publish<GivePromoCodeToCustomerDto>(dto);
        }
    }
}
