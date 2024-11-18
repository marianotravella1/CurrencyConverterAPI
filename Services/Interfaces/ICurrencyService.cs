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
        IEnumerable<Currency> GetAllCurrencies();
        void CreateCurrency(CurrencyForCreationDTO currencyDTO);
        Currency? GetCurrencyById(int id);
        void UpdateCurrencyCIById(int id, decimal ci);
        void DeleteCurrencyById(int id);
    }
}
