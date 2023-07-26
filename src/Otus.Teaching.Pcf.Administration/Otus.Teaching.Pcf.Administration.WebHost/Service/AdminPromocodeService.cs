using Otus.Teaching.Pcf.Administration.Core.Abstractions.Repositories;
using Otus.Teaching.Pcf.Administration.Core.Domain.Administration;
using Otus.Teaching.Pcf.Administration.WebHost.Service.DTO;
using System;
using System.Threading.Tasks;

namespace Otus.Teaching.Pcf.Administration.WebHost.Service
{
    public class AdminPromocodeService : IAdminPromocodeService
    {
        private readonly IRepository<Employee> _employeeRepository;
        public AdminPromocodeService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task UpdateAppliedPromocodesAsync(GivePromoCodeToCustomerDto dto)
        {
            var employee = await _employeeRepository.GetByIdAsync(dto.PartnerManagerId.Value);
            if (employee == null)    
            {
                throw new ArgumentNullException();
            }                    

            employee.AppliedPromocodesCount++;

            await _employeeRepository.UpdateAsync(employee);
        }
    }
}
