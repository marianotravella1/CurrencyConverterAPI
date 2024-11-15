using Common.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICurrencyService
    {
        IEnumerable<CurrenciesForViewDTO> GetAllCurrencies();
        void AddCurrency(Currency currency);
        Currency? GetCurrencyByCode(string code);
    }
}
