using Common.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IConversionService
    {
        IEnumerable<Conversion> GetConversionHistoryByUserId(int userId);
        void AddConversion(int userId, ConversionForCreationDTO conversionDTO);
        decimal ConvertCurrency(int userId, ConversionForCreationDTO conversionDTO);

    }
}
