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
        private readonly ApplicationContext _context;
        public CurrencyRepository(ApplicationContext context)
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
    }
}
