using Common.Enums;
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
            return _context.Currencies.Where(c => c.Status == CurrencyStatus.active).ToList();
        }
        public void AddCurrency(Currency currency)
        {
            _context.Currencies.Add(currency);
            _context.SaveChanges();
        }
        public Currency? GetCurrencyById(int id)
        {
            return _context.Currencies.Single(c => c.CurrencyId == id);
        }

        public void UpdateCurrencyCIById(int id, decimal ci)
        {
            _context.Currencies.Single(c => c.CurrencyId == id).ConvertibilityIndex = ci;
            _context.SaveChanges();
        }

        public void DeleteCurrencyById(int id)
        {
            _context.Currencies.Single(c => c.CurrencyId == id).Status = CurrencyStatus.deleted;
            _context.SaveChanges();
        }
    }
}
