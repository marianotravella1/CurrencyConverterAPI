using Common.Models;
using Data.Entities;
using Data.Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public IEnumerable<SubscriptionsForViewDTO> GetAllSubscriptions()
        {
            return _subscriptionRepository.GetAllSubscriptions();
        }
        public Subscription? GetSubscriptionByName(string name)
        {
            return _subscriptionRepository.GetSubscriptionByName(name);
        }
    }
}
