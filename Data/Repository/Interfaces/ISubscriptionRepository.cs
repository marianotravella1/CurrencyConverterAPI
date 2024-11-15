using Common.Models;
using Data.Entities;
using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Interfaces
{
    public interface ISubscriptionRepository
    {
        IEnumerable<SubscriptionsForViewDTO> GetAllSubscriptions();
        Subscription? GetSubscriptionByName(string name);
    }
}
