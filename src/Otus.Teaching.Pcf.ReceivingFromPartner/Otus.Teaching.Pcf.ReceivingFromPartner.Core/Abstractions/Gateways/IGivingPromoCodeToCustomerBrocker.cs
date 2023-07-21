using Otus.Teaching.Pcf.ReceivingFromPartner.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Teaching.Pcf.ReceivingFromPartner.Core.Abstractions.Gateways
{
    public interface IGivingPromoCodeToCustomerBrocker
    {
        Task GivePromoCodeToCustomer(PromoCode promoCode);
    }
}
