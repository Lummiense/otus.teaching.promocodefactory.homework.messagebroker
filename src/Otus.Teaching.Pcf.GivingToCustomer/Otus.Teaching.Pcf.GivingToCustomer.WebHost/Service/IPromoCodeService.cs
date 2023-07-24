using Otus.Teaching.Pcf.GivingToCustomer.Integration.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Teaching.Pcf.GivingToCustomer.WebHost.Service
{
    public interface IPromoCodeService
    {
        public Task GivePromoCodesToCustomersWithPreferenceAsync(GivePromoCodeToCustomerDto dto);
    }
}
