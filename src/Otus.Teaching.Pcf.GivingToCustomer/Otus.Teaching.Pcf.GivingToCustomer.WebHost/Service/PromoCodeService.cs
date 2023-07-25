using Microsoft.EntityFrameworkCore.Internal;
using Otus.Teaching.Pcf.GivingToCustomer.Core.Abstractions.Repositories;
using Otus.Teaching.Pcf.GivingToCustomer.Core.Domain;
using Otus.Teaching.Pcf.GivingToCustomer.Integration.DTO;
using Otus.Teaching.Pcf.GivingToCustomer.WebHost.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Teaching.Pcf.GivingToCustomer.WebHost.Service
{
    public class PromoCodeService : IPromoCodeService
    {
        private readonly IRepository<PromoCode> _promoCodesRepository;
        private readonly IRepository<Customer> _customersRepository;
        private readonly IRepository<Preference> _preferencesRepository;
        public PromoCodeService(IRepository<PromoCode> promoCodesRepository, IRepository<Customer> customersRepository, IRepository<Preference> preferencesRepository)
        {
            _promoCodesRepository = promoCodesRepository;
            _customersRepository = customersRepository;
            _preferencesRepository = preferencesRepository;
        }

        public async Task GivePromoCodesToCustomersWithPreferenceAsync(GivePromoCodeToCustomerDto dto)
        {
            //Получаем предпочтение по имени
            var preference = await _preferencesRepository.GetByIdAsync(dto.PreferenceId);

            if (preference == null)
            {
                throw new ArgumentNullException(nameof(preference));
            }

            //  Получаем клиентов с этим предпочтением:
            var customers = await _customersRepository
                .GetWhere(d => d.Preferences.Any(x =>
                    x.Preference.Id == preference.Id));

            PromoCode promoCode = PromoCodeMapper.MapFromDTO(dto, preference, customers);

            await _promoCodesRepository.AddAsync(promoCode);
        }
    }
}
