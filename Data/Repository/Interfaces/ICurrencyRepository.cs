using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Interfaces
{
    public interface ICurrencyRepository
    {
        IEnumerable<Currency> GetAllCurrencies();
        Currency? GetCurrencyById(int id);
        void AddCurrency(Currency currency);
        void UpdateCurrencyCIById(int id, decimal ci);
        void DeleteCurrencyById(int id);
    }
}
