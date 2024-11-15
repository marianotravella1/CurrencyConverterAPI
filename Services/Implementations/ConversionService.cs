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
    public class ConversionService : IConversionService
    {
        private readonly IConversionRepository _conversionRepository;
        private readonly IUserService _userService;
        private readonly ICurrencyService _currencyService;
        public ConversionService(IConversionRepository conversionRepository, IUserService userService, ICurrencyService currencyService)
        {
            _conversionRepository = conversionRepository;
            _userService = userService;
            _currencyService = currencyService;
        }
        public IEnumerable<Conversion> GetConversionHistoryByUserId(int userId)
        {
            return _conversionRepository.GetConversionHistoryByUserId(userId);
        }
        public void AddConversion(int userId, ConversionForCreationDTO conversionDTO)
        {
            Conversion newConversion = new Conversion
            {
                User = _userService.GetUserById(userId)!,
                SourceCurrency = _currencyService.GetCurrencyByCode(conversionDTO.SourceCurrencyCode)!,
                TargetCurrency = _currencyService.GetCurrencyByCode(conversionDTO.TargetCurrencyCode)!,
                ConvertedAmount = conversionDTO.ConvertedAmount,
            };

            _conversionRepository.AddConversion(newConversion);
        }
        public decimal ConvertCurrency(int userId, ConversionForCreationDTO conversionDTO)
        {
            decimal sourceCurrencyCI = _currencyService.GetCurrencyByCode(conversionDTO.SourceCurrencyCode)!.ConvertibilityIndex;
            decimal targetCurrencyCI = _currencyService.GetCurrencyByCode(conversionDTO.TargetCurrencyCode)!.ConvertibilityIndex;
            decimal amount = conversionDTO.ConvertedAmount;

            decimal convertedResult = amount * (targetCurrencyCI / sourceCurrencyCI);

            AddConversion(userId, conversionDTO);

            return convertedResult;
        }
    }
}
