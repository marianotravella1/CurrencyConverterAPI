using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class ConversionForCreationDTO
    {
        public string SourceCurrencyCode { get; set; }
        public string TargetCurrencyCode { get; set; }
        public decimal ConvertedAmount { get; set; }

    }
}
