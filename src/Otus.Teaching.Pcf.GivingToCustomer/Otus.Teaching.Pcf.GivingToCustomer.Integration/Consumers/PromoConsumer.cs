using MassTransit;
using Otus.Teaching.Pcf.GivingToCustomer.Core.Abstractions.Repositories;
using Otus.Teaching.Pcf.GivingToCustomer.Core.Domain;
using Otus.Teaching.Pcf.GivingToCustomer.DataAccess;
using Otus.Teaching.Pcf.GivingToCustomer.DataAccess.Repositories;
using Otus.Teaching.Pcf.GivingToCustomer.Integration.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Otus.Teaching.Pcf.GivingToCustomer.Integration.Consumers
{
    public class PromoConsumer:EfRepository<PromoCode>,IConsumer
    {
        DataContext _dataContext;
        public PromoConsumer(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Consume(ConsumeContext<GivePromoCodeToCustomerDto> context)
        {
            var code = context.Message;
            try
            {
                await _dataContext.AddAsync(code);
            }
            catch(Exception ex) 
            {
                throw(ex);
            }                 
        }        
    }
}
