using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Interfaces
{
    public interface IConversionRepository
    {
        IEnumerable<Conversion> GetConversionHistoryByUserId(int userId);
        void AddConversion(Conversion conversion);
    }
}
