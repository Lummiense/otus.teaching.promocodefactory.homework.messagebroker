using MassTransit;
using Otus.Teaching.Pcf.Administration.Core.Domain.Administration;
using Otus.Teaching.Pcf.Administration.WebHost.Service.DTO;
using System.Threading.Tasks;

namespace Otus.Teaching.Pcf.Administration.WebHost.Service.Consumers
{
    public class ManageConsumer : IConsumer<GivePromoCodeToCustomerDto>
    {
        private readonly IAdminPromocodeService _adminService;
        public ManageConsumer(IAdminPromocodeService adminService)
        {
            _adminService = adminService;
        }
        public async Task Consume(ConsumeContext<GivePromoCodeToCustomerDto> context)
        {
            
            await _adminService.UpdateAppliedPromocodesAsync(context.Message);
        }
    }
}
