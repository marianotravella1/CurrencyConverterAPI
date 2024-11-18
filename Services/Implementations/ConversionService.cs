using Common.Models;
using Data.Entities;
using Data.Repository.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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

        public int GetConversionsNumberById(int id)
        {
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;

            return _conversionRepository.GetConversionHistoryByUserId(id)
                .Where(c => c.ConversionDate.Month == currentMonth && c.ConversionDate.Year == currentYear)
                .Count();
        }
        public bool CanConvert(User user)
        {
            int conversionsMadeThisMonth = GetConversionsNumberById(user.UserId);
            int? maxConversionsPosible = user.Subscription.ConversionLimit;
            
            return (conversionsMadeThisMonth < maxConversionsPosible | maxConversionsPosible == null);
        }
        public decimal? Convert(int userId, ConversionForAddDTO conversionDTO)
        {
            User user = _userService.GetUserById(userId)!;

            if (CanConvert(user))
            {
                Currency sourceCurrency = _currencyService.GetCurrencyById(conversionDTO.SourceCurrencyId)!;
                Currency targetCurrency = _currencyService.GetCurrencyById(conversionDTO.TargetCurrencyId)!;
                decimal convertedAmount = conversionDTO.ConvertedAmount;

                decimal convertedOutput = convertedAmount * (targetCurrency.ConvertibilityIndex / sourceCurrency.ConvertibilityIndex);

                Conversion newConversion = new Conversion
                {
                    User = user,
                    SourceCurrency = sourceCurrency,
                    TargetCurrency = targetCurrency,
                    ConvertedAmount = convertedAmount,
                    ConvertedOutput = convertedOutput,
                };

                _conversionRepository.AddConversion(newConversion);

                return convertedOutput;
            }
            else
            {
                return null;
            }
        }



        
        
    }
}
