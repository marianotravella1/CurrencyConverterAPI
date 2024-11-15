﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class ConversionsForViewDTO
    {
        public DateTime Date { get; set; }
        public int SourceCurrencyId { get; set; }
        public int TargetCurrencyId { get; set; }
        public decimal ConvertedAmount { get; set; }
    }
}