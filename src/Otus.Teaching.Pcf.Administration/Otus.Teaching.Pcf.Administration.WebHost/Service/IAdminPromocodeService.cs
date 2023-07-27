using Otus.Teaching.Pcf.Message;
using System.Threading.Tasks;

namespace Otus.Teaching.Pcf.Administration.WebHost.Service
{
    public interface IAdminPromocodeService
    {
        public Task UpdateAppliedPromocodesAsync(GivePromoCodeToCustomerDto dto);
    }
}
