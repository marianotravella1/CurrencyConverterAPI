using Common.Models;
using Data.Entities;
using Data.Repository.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;
        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public IEnumerable<CurrenciesForViewDTO> GetAllCurrencies()
        {
            return _currencyRepository.GetAllCurrencies()
                .Select(c => new CurrenciesForViewDTO
                {
                    Code = c.Code,
                    Legend = c.Legend,
                    Symbol = c.Symbol,
                    ConvertibilityIndex = c.ConvertibilityIndex,
                }).ToList();
        }

        public void AddCurrency(Currency currency)
        {

        }
        public Currency? GetCurrencyByCode(string code)
        {
            return _currencyRepository.GetCurrencyByCode(code);
        }
    }
}
