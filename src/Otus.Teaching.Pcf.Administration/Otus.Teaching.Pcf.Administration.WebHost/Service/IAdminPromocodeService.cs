using Otus.Teaching.Pcf.Administration.WebHost.Service.DTO;
using System.Threading.Tasks;

namespace Otus.Teaching.Pcf.Administration.WebHost.Service
{
    public interface IAdminPromocodeService
    {
        public Task UpdateAppliedPromocodesAsync(GivePromoCodeToCustomerDto dto);
    }
}
