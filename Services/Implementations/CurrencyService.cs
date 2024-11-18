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

        public IEnumerable<Currency> GetAllCurrencies()
        {
            return _currencyRepository.GetAllCurrencies();
        }

        public void CreateCurrency(CurrencyForCreationDTO currencyDTO)
        {
            try
            {
                if (_currencyRepository.GetAllCurrencies().All(c => c.Code != currencyDTO.Code))
                {
                    Currency newCurrency = new Currency()
                    {
                        Code = currencyDTO.Code,
                        Legend = currencyDTO.Legend,
                        Symbol = currencyDTO.Symbol,
                        ConvertibilityIndex = currencyDTO.ConvertibilityIndex,
                    };
                    _currencyRepository.AddCurrency(newCurrency);
                }
                else
                {
                    throw new Exception($"There is already a currency with the code '{currencyDTO.Code}'.");
                }
            }
            catch
            {
                throw new Exception("An error occurred while creating a currency");
            }
            
        }
        public Currency? GetCurrencyById(int id)
        {
            return _currencyRepository.GetCurrencyById(id);
        }
        public void UpdateCurrencyCIById(int id, decimal ci)
        {
            _currencyRepository.UpdateCurrencyCIById(id, ci);
        }

        public void DeleteCurrencyById(int id)
        {
            _currencyRepository.DeleteCurrencyById(id);
        }
    }
}
