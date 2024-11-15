using Data.Entities;
using Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Implementations
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly CurrencyConverterContext _context;
        public CurrencyRepository(CurrencyConverterContext context)
        {
            _context = context;
        }
        public IEnumerable<Currency> GetAllCurrencies()
        {
            return _context.Currencies.ToList();
        }
        public void AddCurrency(Currency currency)
        {
            _context.Currencies.Add(currency);
            _context.SaveChanges();
        }
        public Currency? GetCurrencyByCode(string code)
        {
            return _context.Currencies.FirstOrDefault(c => c.Code == code);
        }
    }
}
