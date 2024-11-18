using Common.Models;
using Data.Entities;
using Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Implementations
{
    public class SubscriptionsRepository : ISubscriptionRepository
    {
        private readonly CurrencyConverterContext _context;
        public SubscriptionsRepository(CurrencyConverterContext context)
        {
            _context = context;
        }

        public IEnumerable<Subscription?> GetAllSubscriptions()
        {
            return _context.Subscriptions;
        }

    }
}
