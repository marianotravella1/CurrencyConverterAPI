using Data.Entities;
using Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Implementations
{
    public class ConversionRepository : IConversionRepository
    {
        private readonly CurrencyConverterContext _context;
        public ConversionRepository(CurrencyConverterContext context)
        {
            _context = context;
        }
        public IEnumerable<Conversion> GetConversionHistoryByUserId(int userId)
        {
            return _context.ConversionHistory
                .Where(c => c.User.UserId == userId)
                .Include(u => u.User)
                .Include(c => c.SourceCurrency)
                .Include(c => c.TargetCurrency)
                .OrderByDescending(c => c.ConversionDate);
        }

        public void AddConversion(Conversion conversion)
        {
            _context.ConversionHistory.Add(conversion);
            _context.SaveChanges();
        }

        



    }
}
