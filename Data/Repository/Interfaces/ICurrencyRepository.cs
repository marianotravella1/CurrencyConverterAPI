﻿using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Interfaces
{
    public interface ICurrencyRepository
    {
        IEnumerable<Currency> GetAllCurrencies();
        void AddCurrency(Currency currency);
        Currency? GetCurrencyByCode(string code);
    }
}
